using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BLL.Models
{
    public class ModelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageSource { get; set; }
        public int ModelRangeId { get; set; }
        public decimal MinPrice { get; set; }
        public ModelModel(DAL.Model model)
        {
            MinPrice = decimal.MaxValue;
            var Constructions = model.Construction.ToList();
            foreach(var pr in Constructions)
            {
                decimal p = (decimal) pr.Product.OrderBy(i => i.Price).FirstOrDefault().Price;
                if (p < MinPrice)
                    MinPrice = p;
            }
            Id = model.Id_model;
            Name = model.Name;
            ModelRangeId = (int)model.Id_modelrange;
            ImageSource = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Sources\\Model_" + Name + ".png";
        }
    }
}
