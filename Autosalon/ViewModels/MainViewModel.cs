using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Autosalon.ViewModels
{

    public class MainViewModel
    {
        private IDbCrud context;
        private IAutorizationService autorizationService;
        private IOrderService orderService;
        private IReportService reportService;
        private MainWindow mw;

        private RelayCommand tryAut;

        public RelayCommand TryAutCommand
        {
            get
            {
                return tryAut ?? (tryAut = new RelayCommand(obj =>
                {
                    var values = (object[])obj;
                    if (autorizationService.TryEnter((string)values[0], ((PasswordBox)values[1]).Password))
                        ToAdministrationPage(autorizationService.GetCuttentAdmin());
                }));
            }
        }
        public MainViewModel(IReportService rep, IOrderService ord, IDbCrud db, IAutorizationService s, MainWindow mw)
        {
            reportService = rep;
            orderService = ord;
            context = db;
            autorizationService = s;
            this.mw = mw;
        }

        private void ToAdministrationPage(int id)
        {
            mw.Close();
            new AdminisrtationMain(reportService, orderService, context, id).Show();       
        }
    }
}
