using DAL.Entities;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class StatusRepository : IRepository<Status>
    {
        private CarDealershipEntities db;

        public StatusRepository(CarDealershipEntities dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Status> GetList()
        {
            return db.Status.ToList();
        }

        public Status GetItem(int id)
        {
            return db.Status.Find(id);
        }

        public void Create(Status status)
        {
            db.Status.Add(status);
        }

        public void Update(Status status)
        {
            db.Entry(status).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Status status = db.Status.Find(id);
            if (status != null)
                db.Status.Remove(status);
        }
    }
}
