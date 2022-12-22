using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Interface;
using BLL.Models;

namespace Autosalon.ViewModels
{
    public class OrderViewModel
    {
        private IDbCrud context;
        private IOrderService orderService;
        private int id_adm;
        private Views.OrderPage OrderPage;
        public List<ProductModel> Products { get; set; }
        private RelayCommand makeOrder;

        public RelayCommand MakeOrderCommand
        {
            get
            {
                return makeOrder ?? (makeOrder = new RelayCommand(obj =>
                {
                    var values = (object[])obj;
                    string name = (string)values[0] + " " + (string)values[1] + " " + (string)values[2];
                    string passport = (string)values[3];
                    string driver = (string)values[4];
                    int selectedProd = ((ProductModel)values[5]).Id;
                    MakeOrder(name, passport, driver, selectedProd);
                }));
            }
        }

        public OrderViewModel(Views.OrderPage op, IDbCrud db,  IOrderService orderService, int id_adm)
        {
            OrderPage = op;
            context = db;

            var pr = db.GetAllProducts();

            Products = new List<ProductModel>();

            foreach(var p in pr)
            {
                if (p.id_acc != null)
                    Products.Add(p);
                else if (p.id_constr != null && db.GetAllConstructions().Where(i => i.Id == p.id_constr).FirstOrDefault().InStock == 0)
                    Products.Add(p);
            }

            this.orderService = orderService;
            this.id_adm = id_adm;
        }

        private void MakeOrder(string name, string passport, string driver, int selected_id)
        {
            var prod = context.GetAllProducts().Where(i => i.Id == selected_id).FirstOrDefault();

            ClientModel client = new ClientModel();
            client.Id = -1;
            client.FullName = name;
            client.Pasport = passport;
            client.DriverLicense = driver;
            int id_client = context.CreateClient(client);

            OrderModel order = new OrderModel
            {
                Id = -1,
                Date = DateTime.Now,
                ClientName = name,
                Id_adm = id_adm,
                Id_client = id_client,
                Id_status = 1,
                Id_product = selected_id
            };

            orderService.MakeOrder(order);

            OrderPage.DialogResult = true;
            OrderPage.Close();
        }
    }
}
