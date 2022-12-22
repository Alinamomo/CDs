using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using BLL.Models;

namespace BLL.Services
{
    public class ReportService: IReportService
    {
        IDbRepos db;

        public ReportService(IDbRepos repos)
        {
            db = repos;
        }

        public List<OrderModel> Profit(DateTime value)
        {
            return db.Reports.Profit(value).Select(i => new OrderModel(i)).ToList();
        }
    }
}
