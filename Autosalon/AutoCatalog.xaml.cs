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

namespace Autosalon
{
    /// <summary>
    /// Логика взаимодействия для AutoCatalog.xaml
    /// </summary>
    public partial class AutoCatalog : Window
    {
        private ViewModels.AutoCatalogViewModel VM;
        public AutoCatalog(IDbCrud db)
        {
            VM = new ViewModels.AutoCatalogViewModel(this, db);
            DataContext = VM;
            InitializeComponent();
        }

        private void exit1b_Click(object sender, RoutedEventArgs e)
        {
            Off off = new Off();
            Close(); 
            off.Show();
        }

        //private void AClick(object sender, RoutedEventArgs e)
        //{
        //    Models amod = new Models(context);
        //    Hide();
        //    amod.Show();
        //}

    }
}
