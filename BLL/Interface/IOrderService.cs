using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IOrderService
    {
        bool MakeOrder(BLL.Models.OrderModel orderDto);

    }
}
