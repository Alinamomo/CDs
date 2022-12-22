using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set;  }
        public decimal Price { get; set; }
        public int? id_acc { get; set; }
        public int ?id_constr { get; set; }
        public string ProductName { get; set; }

        public ProductModel(DAL.Product product)
        {
            Id = product.Id_product;
            Name = product.Name;
            Price =(decimal)product.Price;
            id_acc = product.id_acc;
            id_constr = product.id_constr;

            string AccessName = product.Accesouries == null ? "" : ", " + product.Accesouries.Name;
            string ModelName = product.Construction == null ? "" : product.Construction.Name + " " + product.Construction.Model.Name;
            ProductName = ModelName + AccessName;
        }

    }
}
