using DAL.Entities;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public partial class ColorRepository : IRepository<Colour>
    {
        private CarDealershipEntities db;

        public ColorRepository(CarDealershipEntities dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Colour> GetList()
        {
            return db.Colour.ToList();
        }

        public Colour GetItem(int id)
        {
            return db.Colour.Find(id);
        }

        public void Create(Colour color)
        {
            db.Colour.Add(color);
        }

        public void Update(Colour color)
        {
            db.Entry(color).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Colour color = db.Colour.Find(id);
            if (color != null)
                db.Colour.Remove(color);
        }
    }
}
