using DAL;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public partial class OrderRepository : IRepository<Order>
    {
        private CarDealershipEntities db;

        public OrderRepository(CarDealershipEntities dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Order> GetList()
        {
            return db.Order.ToList();
        }

        public Order GetItem(int id)
        {
            return db.Order.Find(id);
        }

        public void Create(Order order)
        {
            db.Order.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Order order = db.Order.Find(id);
            if (order != null)
                db.Order.Remove(order);
        }
    }
}
