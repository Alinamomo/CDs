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
using BLL.Interface;
namespace Autosalon
{
    /// <summary>
    /// Логика взаимодействия для AccessCatalog.xaml
    /// </summary>
    public partial class AccessCatalog : Window
    {
        private ViewModels.AccessViewModel VM;
        public AccessCatalog(IDbCrud db)
        {
            VM = new ViewModels.AccessViewModel(db);
            DataContext = VM;
            InitializeComponent();
        }

        private void exit2b_Click(object sender, RoutedEventArgs e)
        {
            Off off = new Off();
            Close();
            off.Show();
        }
    }
}
