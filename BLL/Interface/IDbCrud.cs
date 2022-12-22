using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IDbCrud
    {
        List<AdministrationModel> GetAllAdministrations();
        List<AccesouriesModel> GetAllAccesouries();
        List<ClientModel> GetAllClients();
        List<ColourModel> GetAllColours();
        List<ConstructionModel> GetAllConstructions();
        List<ModelModel> GetAllModels();
        List<ModelRangeModel> GetAllModelRanges();
        List<OrderModel> GetAllOrders();
        List<ProductModel> GetAllProducts();
     
        List<StatusModel> GetAllStatuses();

        //OrderModel GetOrder(int id);
        void CreateOrder(OrderModel o);
        int CreateClient(ClientModel c);
        bool Save();
        void UpdateOrder(OrderModel o);
        void UpdateConstruction(ConstructionModel c);
    }
}
