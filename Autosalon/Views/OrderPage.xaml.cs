using BLL.Interface;
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

namespace Autosalon.Views
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Window
    {
        private ViewModels.OrderViewModel VM;
        public OrderPage(IOrderService ord, IDbCrud db,  int id_a)
        {
            InitializeComponent();
            VM = new ViewModels.OrderViewModel(this, db, ord, id_a);
            DataContext = VM;
        }
    }
}
