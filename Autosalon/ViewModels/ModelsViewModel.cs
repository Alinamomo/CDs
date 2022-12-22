using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosalon.ViewModels
{
    public class ModelsViewModel
    {
        public struct ModelItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string PriceString { get; set; }
            public Uri ModelImageSource { get; set; }
        }

        private RelayCommand toconstructionspage;

        public RelayCommand ToConstructionPageCommand
        {
            get
            {
                return toconstructionspage ?? (toconstructionspage = new RelayCommand(obj =>
                {
                    ToConstructionPage((int)obj);
                }));
            }
        }

        private RelayCommand toautocatalogpage;

        public RelayCommand ToAutoCatalogPageCommand
        {
            get
            {
                return toautocatalogpage ?? (toautocatalogpage = new RelayCommand(obj =>
                {
                    ToCatalogPage();
                }));
            }
        }

        public ObservableCollection<ModelItem> Models { get; set; }

        private Models models;
        private IDbCrud context;
        private int id_modelRange;
        public ModelsViewModel(Models models, IDbCrud db, int id_mr)
        {
            id_modelRange = id_mr;
            this.models = models;
            context = db;
            Models = new ObservableCollection<ModelItem>();

           
            FillModels();
        }

        private void FillModels()
        {
            Models.Clear();

            var mod = context.GetAllModels().Where(i => i.ModelRangeId == id_modelRange).ToList(); ;

            foreach(var m in mod)
            {
                Models.Add(new ModelItem { Id = m.Id, Name = m.Name, ModelImageSource = new Uri(m.ImageSource), PriceString = "От " + m.MinPrice.ToString() + " Руб."});
            }
        }

        public void ToConstructionPage(int id_model)
        {
            models.Hide();
            new Views.ModelPage(context, models, id_model).Show();
        }


        public void ToCatalogPage()
        {
            AutoCatalog auto = new AutoCatalog(context);
            models.Close();
            auto.Show();
        }
    }


}
