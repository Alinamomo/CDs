using DAL.Entities;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class AccesouriesRepository : IRepository<Accesouries>
    {
        private CarDealershipEntities db;

        public AccesouriesRepository(CarDealershipEntities dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Accesouries> GetList()
        {
            return db.Accesouries.ToList();
        }

        public Accesouries GetItem(int id)
        {
            return db.Accesouries.Find(id);
        }

        public void Create(Accesouries accesouries)
        {
            db.Accesouries.Add(accesouries);
        }

        public void Update(Accesouries accesouries)
        {
            db.Entry(accesouries).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Accesouries accesouries = db.Accesouries.Find(id);
            if (accesouries != null)
                db.Accesouries.Remove(accesouries);
        }
    }
}
