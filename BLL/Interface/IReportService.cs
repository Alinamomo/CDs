using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
namespace BLL.Interface
{
    public interface IReportService
    {
        List<OrderModel> Profit(DateTime value);
    }
}
