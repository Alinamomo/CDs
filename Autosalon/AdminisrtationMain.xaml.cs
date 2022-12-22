using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using BLL.Interface;

namespace Autosalon
{
    /// <summary>
    /// Логика взаимодействия для AdminisrtationMain.xaml
    /// </summary>
    public partial class AdminisrtationMain : Window
    {
        private ViewModels.AdministrationViewModel VM;
        public AdminisrtationMain(IReportService reportService, IOrderService ord, IDbCrud db, int id)
        {
            VM = new ViewModels.AdministrationViewModel(reportService, ord, db, id);
            DataContext = VM;
            InitializeComponent();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            VM.UpdateReport((DateTime)date.SelectedDate) ;
        }
    }
}
