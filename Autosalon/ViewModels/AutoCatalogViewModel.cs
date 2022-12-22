using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Interface;

namespace Autosalon.ViewModels
{
    public class AutoCatalogViewModel
    {
        public struct ModelRangeItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Uri ModelRangeImageSource { get; set; }
        }

        private RelayCommand tomodelspage;

        public RelayCommand ToModelPageCommand
        {
            get { return tomodelspage ?? (tomodelspage = new RelayCommand(obj =>
              {
                  ToModelsPage((int)obj);
              }));
            }
        }
        

        private RelayCommand backtooff;

        public RelayCommand BackToOffCommand
        {
            get
            {
                return backtooff ?? (backtooff = new RelayCommand(obj =>
                {
                    BackToOff();
                }));
            }
        }

        private AutoCatalog catalog;
        private IDbCrud context;
        public ObservableCollection<ModelRangeItem> ModelRanges { get; set; }
        public AutoCatalogViewModel(AutoCatalog catalog, IDbCrud db)
        {
            ModelRanges = new ObservableCollection<ModelRangeItem>();
            this.catalog = catalog;

            context = db;

            FillModelRange();

           

        }

        public void FillModelRange()
        {
            var mr = context.GetAllModelRanges();
            ModelRanges.Clear();

            foreach(var m in mr)
            {
                ModelRanges.Add(new ModelRangeItem { Id = m.Id, Name= m.Name, ModelRangeImageSource = new Uri(m.ImageSource) });
            }
        }

        private void ToModelsPage(int id_modelRange)
        {
            catalog.Close();
            new Models(context, id_modelRange).Show();
        }

        private void BackToOff()
        {
            catalog.Close();
            new Off().Show();
        }

    }
}
