using DAL.Entities;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repository
{
    public class ReportRepository : IReportRepository
    {
        private CarDealershipEntities db;
        public ReportRepository(CarDealershipEntities dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Order> Profit(DateTime value)
        {

            
            return db.Order.Where(i => i.OrderDate >= value).OrderBy(i => i.OrderDate).ToList();
            
        }
    }
}
