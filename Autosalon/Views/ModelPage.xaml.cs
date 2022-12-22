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
    /// Логика взаимодействия для ModelPage.xaml
    /// </summary>
    public partial class ModelPage : Window
    {
        private ViewModels.ConstructionViewModel VM;
        public ModelPage(IDbCrud db, Models models, int id_m)
        {
            VM = new ViewModels.ConstructionViewModel(db, models, this, id_m);
            DataContext = VM;
            InitializeComponent();
        }

    }
}
