using BLL;
using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosalon.ViewModels
{
    public class AdministrationViewModel : INotifyPropertyChanged
    {
     
        public struct OrderItem
        {
            public int Id { get; set; }
            public string ClientName { get; set; }
            public string PriceString { get; set; }
            public string ModelName { get; set; }
            public string AccessName { get; set; }
            public string AdminString { get; set; }
            public string StatusString { get; set; }
            public bool IsActive { get; set; } 
        }

        public struct ConstructionItem
        {
            public int Id { get; set; }
            public string TypeName { get; set; }
            public string ModelName { get; set; }
            public int Count { get; set; }
        }

        #region Commands

        private RelayCommand cancelOrder;

        public RelayCommand CancelOrderCommand
        {
            get
            {
                return cancelOrder ?? (cancelOrder = new RelayCommand(obj =>
                {
                    CancelOrder((int)obj);
                }));
            }
        }

        private RelayCommand completeOrder;

        public RelayCommand CompleteOrderCommand
        {
            get
            {
                return completeOrder ?? (completeOrder = new RelayCommand(obj =>
                {
                    CompleteOrder((int)obj);
                }));
            }
        }

        private RelayCommand openorderform;

        public RelayCommand OpenOrderFormCommand
        {
            get
            {
                return openorderform ?? (openorderform = new RelayCommand(obj =>
                {
                    OpenOrderForm();
                }));
            }
        }

        private RelayCommand addconstruction;

        public RelayCommand AddConstructionCommand
        {
            get
            {
                return addconstruction ?? (addconstruction = new RelayCommand(obj =>
                {
                    var values = (object[])obj;
                    if (((string)values[1]) != "")
                        AddConstruction(Int32.Parse((string)values[0]), Int32.Parse((string)values[1]));
                }));
            }
        }
        private RelayCommand removeconstruction;

        public RelayCommand RemoveConstructionCommand
        {
            get
            {
                return removeconstruction ?? (removeconstruction = new RelayCommand(obj =>
                {
                    var values = (object[])obj;
                    if (((string)values[1]) != "")
                        RemoveConstruction(Int32.Parse((string)values[0]), Int32.Parse((string)values[1]));
                }));
            }
        }
        #endregion

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private decimal _priceText = 0;
        public string PriceText
        {
            get { return _priceText.ToString() + " Руб."; }
            set
            {
                _priceText = Decimal.Parse(value);
                NotifyPropertyChanged("PriceText");
            }
        }
        #endregion

        public ObservableCollection<OrderItem> Orders { get; set; }
        public ObservableCollection<ConstructionItem> Constructions { get; set; }
        public ObservableCollection<OrderItem> ReportOrders { get; set; }

        private IDbCrud context;
        private int id_adm;
        private IOrderService orderService;
        private IReportService reportService;
        public AdministrationViewModel(IReportService reportService, IOrderService orderService, IDbCrud db, int id)
        {
            this.orderService = orderService;
            this.reportService = reportService;
            Orders = new ObservableCollection<OrderItem>();
            Constructions = new ObservableCollection<ConstructionItem>();
            ReportOrders = new ObservableCollection<OrderItem>();
            context = db;
            id_adm = id;
            FillOrders();
            FillConstructions();
        }

        private void FillConstructions()
        {
            Constructions.Clear();

            var con = context.GetAllConstructions();

            foreach(var c in con)
            {
                Constructions.Add(new ConstructionItem 
                {
                    Id = c.Id,
                    Count = c.InStock,
                    TypeName = c.Name,
                    ModelName = context.GetAllModels().Where(i => i.Id == c.Id_model).FirstOrDefault().Name
                });
            }
        }

        private void FillOrders()
        {
            Orders.Clear();
            var ord = context.GetAllOrders().Where(i => i.Id_adm == id_adm).ToList();

            foreach(var o in ord)
            {
                Orders.Add(new OrderItem
                {
                    Id = o.Id,
                    AccessName = o.AccessName,
                    AdminString = context.GetAllAdministrations().Where(i => i.Id == id_adm).FirstOrDefault().FullName,
                    ClientName = o.ClientName,
                    ModelName = o.ModelName,
                    PriceString = o.Price.ToString() + " Руб.",
                    StatusString = o.StatusName,
                    IsActive = o.Id_status == 1
                });
            }      
        }

        private void CancelOrder(int id)
        {
            var o = context.GetAllOrders().Where(i => i.Id == id).FirstOrDefault();

            o.Id_status = 3;
            context.UpdateOrder(o);
            FillOrders();
        }

        private void CompleteOrder(int id)
        {
            var o = context.GetAllOrders().Where(i => i.Id == id).FirstOrDefault();

            o.Id_status = 2;
            context.UpdateOrder(o);
            FillOrders();
        }
        private void AddConstruction(int id, int count) 
        {
            var c = context.GetAllConstructions().Where(i => i.Id == id).FirstOrDefault();
            c.InStock += count;
            context.UpdateConstruction(c);
            FillConstructions();
        }
        private void RemoveConstruction(int id, int count)
        {
            var c = context.GetAllConstructions().Where(i => i.Id == id).FirstOrDefault();
            c.InStock -= count;
            context.UpdateConstruction(c);
            FillConstructions();
        }

        private void OpenOrderForm()
        {
            var op = new Views.OrderPage(orderService, context, id_adm);
            if (op.ShowDialog() != null)
                FillOrders();
        }

        public void UpdateReport(DateTime date)
        {
            

            ReportOrders.Clear();
            var ord = reportService.Profit(date);
            foreach (var o in ord)
            {
                ReportOrders.Add(new OrderItem
                {
                    Id = o.Id,
                    AccessName = o.AccessName,
                    AdminString = context.GetAllAdministrations().Where(i => i.Id == id_adm).FirstOrDefault().FullName,
                    ClientName = o.ClientName,
                    ModelName = o.ModelName,
                    PriceString = o.Price.ToString() + " Руб.",
                    StatusString = o.StatusName,
                    IsActive = o.Id_status == 1
                });
            }

            PriceText = ord.Sum(i => i.Price).ToString();
        }
    }
}
