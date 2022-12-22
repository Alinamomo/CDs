using DAL.Entities;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public partial class ModelRepository : IRepository<Model>
    {
        private CarDealershipEntities db;

        public ModelRepository(CarDealershipEntities dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Model> GetList()
        {
            return db.Model.ToList();
        }

        public Model GetItem(int id)
        {
            return db.Model.Find(id);
        }

        public void Create(Model model)
        {
            db.Model.Add(model);
        }

        public void Update(Model model)
        {
            db.Entry(model).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Model model = db.Model.Find(id);
            if (model != null)
                db.Model.Remove(model);
        }
    }
}
