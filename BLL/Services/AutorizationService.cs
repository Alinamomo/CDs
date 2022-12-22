using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;

namespace BLL.Services
{
    public class AutorizationService : IAutorizationService
    {

        private IDbRepos db;
        private int currentAdmin;

        public AutorizationService(IDbRepos db)
        {
            this.db = db;
            currentAdmin = -1;
        }

        public bool TryEnter(string login, string password)
        {
            var a = db.Administrations.GetList().Where(i => i.Login == login && i.Password == password).FirstOrDefault();

            if (a != null)
            {
                currentAdmin = a.Id_adm;
                return true;
            }

            return false;
        }

        public int GetCuttentAdmin()
        {
            return currentAdmin;
        }
    }
}
