using System.Windows;
using BLL.Interface;
using BLL;
using Ninject;
using BLL.Util;
using Autosalon.Util;

namespace Autosalon
{
    /// <summary>
    /// Логика взаимодействия для Off.xaml
    /// </summary>
    public partial class Off : Window
    {
        private IDbCrud context;
        private IAutorizationService authServ;
        private IOrderService orderService;
        private IReportService reportService;
        public Off()
        {
            InitializeComponent();

            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule(""));

            orderService = kernel.Get<IOrderService>();
            context = kernel.Get<IDbCrud>();
            authServ = kernel.Get<IAutorizationService>();
            reportService = kernel.Get<IReportService>();
        }

        private void AutoB_Click(object sender, RoutedEventArgs e)
        {
            AutoCatalog auto = new AutoCatalog(context);
            Hide();
            auto.Show();

        }

        private void AdmB_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow(reportService, orderService, context, authServ);
            Hide();
            mainWindow.Show();
        }

        private void AccB_Click(object sender, RoutedEventArgs e)
        {
            AccessCatalog acc = new AccessCatalog(context);
            Hide();
            acc.Show();
        }
    }
}
