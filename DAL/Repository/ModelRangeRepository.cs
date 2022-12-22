using DAL.Entities;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public partial class ModelRangeRepository : IRepository<ModelRange>
    {
        private CarDealershipEntities db;

        public ModelRangeRepository(CarDealershipEntities dbcontext)
        {
            this.db = dbcontext;
        }

        public List<ModelRange> GetList()
        {
            return db.ModelRange.ToList();
        }

        public ModelRange GetItem(int id)
        {
            return db.ModelRange.Find(id);
        }

        public void Create(ModelRange modelr)
        {
            db.ModelRange.Add(modelr);
        }

        public void Update(ModelRange modelr)
        {
            db.Entry(modelr).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ModelRange modelr = db.ModelRange.Find(id);
            if (modelr != null)
                db.ModelRange.Remove(modelr);
        }
    }
}
