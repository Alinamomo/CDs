using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Id_status { get; set; }
        public int Id_client { get; set; }
        public int Id_adm { get; set; }
        public int Id_product { get; set; }
        public string StatusName { get; set; }
        public string ClientName { get; set; }
        public decimal Price { get; set; }
        public string AccessName { get; set; }
        public string ModelName { get; set; }

        public OrderModel() { }
        public OrderModel(DAL.Order order)
        {
            Id = order.Id_order;
            Date = (DateTime)order.OrderDate;
            Id_status = (int)order.Id_status;
            Id_client = (int)order.Id_client;
            Id_adm = (int)order.Id_adm;
            Id_product = (int)order.Id_product;
            AccessName = order.Product.Accesouries == null ? "Нет" : order.Product.Accesouries.Name;
            StatusName = order.Status.Name;
            ClientName = order.Client.FullName;
            Price = (decimal)order.Product.Price;
            ModelName = order.Product.Construction == null ? "Нет" : order.Product.Construction.Name;
        }
    }
}
