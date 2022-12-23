using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Interface;
using BLL.Models;

namespace Autosalon.ViewModels
{
    public class AccessViewModel
    {

        public struct AccessItem
        {
            public string Name { get; set; }
            public string PriceText { get; set; }
            public Uri AccessImageSource { get; set; }
        }

        private IDbCrud context;

        public ObservableCollection<AccessItem> Accessories { get; set; }

        public AccessViewModel(IDbCrud dbCrud)
        {
            context = dbCrud;

            Accessories = new ObservableCollection<AccessItem>();

           
            
            FillAccesses();
        }

        public void FillAccesses()
        {
            Accessories.Clear();

            var ac = context.GetAllAccesouries();

            foreach(var a in ac)
            {
                Accessories.Add(new AccessItem { AccessImageSource = null, Name = a.Name, PriceText = "От " + a.MinimalPrice.ToString() + " Руб." });
            }

            
        }
    }
}
