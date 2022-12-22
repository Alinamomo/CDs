using DAL.Entities;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DbReposSQL: IDbRepos
    {
        private CarDealershipEntities db;

        private AccesouriesRepository accesouriesRepository;
        private AdministrationRepository administrationRepository;
        private ClientRepository clientRepository;
        private ColorRepository colorRepository;
        private ConstructionRepository constructionRepository;
        private ModelRepository modelRepository;
        private ModelRangeRepository modelRangeRepository;
        private OrderRepository orderRepository;
        private ProductRepository productRepository;
        private StatusRepository statusRepository;
        private ReportRepository reportRepository;

        public DbReposSQL()
        {
            db = new CarDealershipEntities();

        }

        public IRepository<Accesouries> Accesouriess
        {
            get
            {
                if (accesouriesRepository == null)
                    accesouriesRepository = new AccesouriesRepository(db);
                return accesouriesRepository;
            }
        }

        public IRepository<Administration> Administrations
        {
            get
            {
                if (administrationRepository == null)
                    administrationRepository = new AdministrationRepository(db);
                return administrationRepository;
            }
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(db);
                return clientRepository;
            }
        }
        public IRepository<Colour> Colors
        {
            get
            {
                if (colorRepository == null)
                    colorRepository = new ColorRepository(db);
                return colorRepository;
            }
        }
        public IRepository<Construction> Constructions
        {
            get
            {
                if (constructionRepository == null)
                    constructionRepository = new ConstructionRepository(db);
                return constructionRepository;
            }
        }
        public IRepository<Model> Models
        {
            get
            {
                if (modelRepository == null)
                    modelRepository = new ModelRepository(db);
                return modelRepository;
            }
        }
        public IRepository<ModelRange> ModelsRange
        {
            get
            {
                if (modelRangeRepository == null)
                    modelRangeRepository = new ModelRangeRepository(db);
                return modelRangeRepository;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
      
        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }
        public IRepository<Status> Statuses
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new StatusRepository(db);
                return statusRepository;
            }
        }

        public IReportRepository Reports
        {
            get
            {
                if (reportRepository == null)
                    reportRepository = new ReportRepository(db);
                return reportRepository;
            }
        }

        int IDbRepos.Save()
        {
            return db.SaveChanges();
        }
    }
}
