using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class AdministrationModel
    {
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public int Experience { get; set; }
        public DateTime Date { get; set; }

        public AdministrationModel(DAL.Administration adm)
        {
            Id = adm.Id_adm;
            FullName = adm.FullName;
            Login = adm.Login;
            Password = adm.Password;
            Email = adm.Email;
            Experience = (int)adm.Experience;
            Date = (DateTime)adm.Date;

        }
    }
}
