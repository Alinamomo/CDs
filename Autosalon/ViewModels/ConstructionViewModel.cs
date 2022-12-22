using BLL.Interface;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosalon.ViewModels
{
    public class ConstructionViewModel : INotifyPropertyChanged
    {
        public struct ConstructionItem
        {
            public string Name { get; set; }
            public string TypeString { get; set; }
            public string HorseString { get; set; }
            public string TransmissionString { get; set; }
            public string EngineString { get; set; }
            public string DriveString { get; set; }
            public string EngineTypeString { get; set; }

            public string Colours { get; set; }
            public Uri ConstructionImageSource { get; set; }
        }

        #region Commands

        private RelayCommand tomodelspage;

        public RelayCommand ToModelRangePageCommand
        {
            get
            {
                return tomodelspage ?? (tomodelspage = new RelayCommand(obj =>
                {
                    ToModelsPage();
                }));
            }
        }

        private RelayCommand changeconstruction;

        public RelayCommand ChangeConstructionCommand
        {
            get
            {
                return changeconstruction ?? (changeconstruction = new RelayCommand(obj =>
                {
                    ChangeConstruction((Int32.Parse((string)obj)));
                }));
            }
        }
        #endregion
        public ConstructionItem CurrentConstruction { get; set; }
        private Models models;
        private Views.ModelPage modelPage;
        private IDbCrud context;
        private List<ConstructionModel> constructionModels;
        private int curId;
        private int id_model;
        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotityPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public ConstructionViewModel(IDbCrud db, Models models, Views.ModelPage modelPage, int id_m)
        {
            this.modelPage = modelPage;
            this.models = models;
            context = db;

            id_model = id_m;

            constructionModels = context.GetAllConstructions().Where(i => i.Id_model == id_model).ToList();
            curId = 0;
            SetConstruction();
        }

        private void SetConstruction()
        {
            var c = constructionModels[curId];
            CurrentConstruction = new ConstructionItem
            {
                Name = context.GetAllModels().Where(i => i.Id == c.Id_model).FirstOrDefault().Name,
                DriveString = "Drive: " + c.Drive,
                EngineString = "Engine: " + c.EngineCapacity,
                EngineTypeString = "EngineType: " + c.EngineType,
                HorseString = "Horse: " + c.HorsePower,
                TransmissionString = "Transmission: " + c.Transmission,
                TypeString = "Type: " + c.Name,
                Colours = "Цвета в наличии: \n" + context.GetAllColours().Where(i => i.Id == c.Id_colour).FirstOrDefault().Name,
                ConstructionImageSource = new Uri(context.GetAllModels().Where(i => i.Id == c.Id_model).FirstOrDefault().ImageSource)
            };
        }
        private void ToModelsPage()
        {
            modelPage.Close();
            models.Show();
        }

        private void ChangeConstruction(int m)
        {
            curId += m;
            if (curId < 0)
                curId = constructionModels.Count - 1;
            else if (curId == constructionModels.Count)
                curId = 0;
            SetConstruction();

            NotityPropertyChanged("CurrentConstruction");
        }
    }
}
