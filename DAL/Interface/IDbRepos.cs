using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IDbRepos
    {
        IRepository<Accesouries> Accesouriess { get; }
        IRepository<Administration> Administrations { get; }
        IRepository<Client> Clients { get; }
        IRepository<Colour> Colors { get; }
        IRepository<Construction> Constructions { get; }

        IRepository<Model> Models { get; }

        IRepository<ModelRange> ModelsRange { get; }
        IRepository<Order> Orders { get; }
        
        IRepository<Product> Products { get; }
        IRepository<Status> Statuses { get; }

        IReportRepository Reports { get; }
        int Save();
    }
}
