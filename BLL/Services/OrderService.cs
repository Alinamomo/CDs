using BLL.Interface;
using DAL;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService: IOrderService
    {
        private IDbRepos db;

        public OrderService(IDbRepos repos)
        {
            db = repos;
        }

        public bool MakeOrder(BLL.Models.OrderModel orderDto)
        {
            int id;
            if (orderDto.Id != -1)
                id = orderDto.Id;
            else
                id = db.Orders.GetList().OrderByDescending(i => i.Id_order).FirstOrDefault() == null ? 0 : db.Orders.GetList().OrderByDescending(i => i.Id_order).FirstOrDefault().Id_order + 1;

            Product p = db.Products.GetItem(orderDto.Id_product);
            Order order = new Order
            {
                Id_order = id,
                OrderDate = orderDto.Date,
                Id_client = orderDto.Id_client,
                Id_status = orderDto.Id_status,
                Id_adm = orderDto.Id_status,
                Id_product = p.Id_product,
                Product = p,
                Status = db.Statuses.GetItem(orderDto.Id_status),
                Administration = db.Administrations.GetItem(orderDto.Id_adm),
                Client = db.Clients.GetItem(orderDto.Id_client),
                Price = p.Price
            };
            db.Orders.Create(order);
            var c = db.Clients.GetItem(orderDto.Id_client);
            c.Id_order = id;
            db.Clients.Update(c);

            if (db.Save() > 0)
                return true;
            return false;
        }
    }
}
