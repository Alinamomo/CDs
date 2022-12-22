using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Interface;
using BLL.Services;
using Ninject.Modules;

namespace Autosalon.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbCrud>().To<DBDataOperation>();
            Bind<IAutorizationService>().To<AutorizationService>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IReportService>().To<ReportService>();
        }
    }
}
