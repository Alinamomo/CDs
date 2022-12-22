using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IReportRepository
    {
        List<Order> Profit(DateTime value);
    }
}
