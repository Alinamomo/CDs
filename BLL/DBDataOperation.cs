using BLL.Models;
using DAL;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface;

namespace BLL
{
    public class DBDataOperation : IDbCrud
    {
        private IDbRepos db;
        public DBDataOperation(IDbRepos repos)
        {
            db = repos;
        }

        public DBDataOperation()
        {
        }

        public List<AccesouriesModel> GetAllAccesouries()
        {
            return db.Accesouriess.GetList().Select(i => new Models.AccesouriesModel(i)).ToList();
        }

        public List<AdministrationModel> GetAllAdministrations()
        {
            return db.Administrations.GetList().Select(i => new Models.AdministrationModel(i)).ToList();
        }

        public List<ClientModel> GetAllClients()
        {
            return db.Clients.GetList().Select(i => new Models.ClientModel(i)).ToList();
        }

        public List<ColourModel> GelAllColors()
        {
            return db.Colors.GetList().Select(i => new Models.ColourModel(i)).ToList();
        }

        public List<ConstructionModel> GetAllConstructions()
        {
            return db.Constructions.GetList().Select(i => new Models.ConstructionModel(i)).ToList();
        }

        public List<ModelModel> GetAllModels()
        {
            return db.Models.GetList().Select(i => new Models.ModelModel(i)).ToList();
        }

        public List<ModelRangeModel> GetAllModelRanges()
        {
            return db.ModelsRange.GetList().Select(i => new Models.ModelRangeModel(i)).ToList();
        }


        public List<OrderModel> GetAllOrders()
        {
            return db.Orders.GetList().Select(i => new Models.OrderModel(i)).ToList();
        }

        public List<ProductModel> GetAllProducts()
        {
            return db.Products.GetList().Select(i => new Models.ProductModel(i)).ToList();
        }

        public List<StatusModel> GetAllStatuses()
        {
            return db.Statuses.GetList().Select(i => new Models.StatusModel(i)).ToList();
        }

        public List<ColourModel> GetAllColours()
        {
            return db.Colors.GetList().Select(i => new Models.ColourModel(i)).ToList();
        }
        public void CreateOrder(OrderModel o)
        {
            Client c = db.Clients.GetList().Where(i => i.Id_client == o.Id_client).FirstOrDefault();
            Administration a = db.Administrations.GetList().Where(i => i.Id_adm == o.Id_adm).FirstOrDefault();
            Status s = db.Statuses.GetList().Where(i => i.id_status == o.Id_status).FirstOrDefault();

            db.Orders.Create(new Order() { Id_order = o.Id, Id_client = o.Id_client, OrderDate = o.Date, Id_adm = o.Id_adm, Client = c, Administration = a, Status = s });
            Save();

        }
        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }

        public void UpdateOrder(OrderModel o)
        {
            Order ord = db.Orders.GetItem(o.Id);
            ord.Id_adm = o.Id_adm;
            ord.Id_client = o.Id_client;
            ord.Id_status = o.Id_status;
            ord.OrderDate = o.Date;
            Save();
        }

        public void UpdateConstruction(ConstructionModel c)
        {
            Construction con = db.Constructions.GetItem(c.Id);
            con.InStock = c.InStock < 0 ? 0 : c.InStock;

            Save();
        }
        public void DeleteOrder(int id)
        {
            Order o = db.Orders.GetItem(id);
            if (o != null)
            {
                db.Orders.Delete(id);
                Save();
            }
        }

        public int CreateClient(ClientModel c)
        {
            Client client = new Client
            {
                FullName = c.FullName,
                DriverLicense = c.DriverLicense,
                Pasport = c.Pasport,
                Id_client = db.Clients.GetList().OrderByDescending(i => i.Id_client).FirstOrDefault().Id_client + 1
            };

            db.Clients.Create(client);
            Save();

            return client.Id_client;
        }
    }
}