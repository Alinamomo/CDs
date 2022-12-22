using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BLL.Models
{
    public class AccesouriesModel
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public decimal MinimalPrice { get; set; }
        public string ImageSource { get; set; }
        public AccesouriesModel(DAL.Accesouries accesouries)
        {
            Id = accesouries.Id_acc;
            Name = accesouries.Name;
            MinimalPrice =  (decimal)accesouries.Product.OrderBy(i => i.Price).FirstOrDefault().Price;

            ImageSource = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Sources\\Acces_" + Id + ".png";
        }


    }
}
