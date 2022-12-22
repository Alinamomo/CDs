using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    [Table("Client")]
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Pasport { get; set; }
        public string DriverLicense { get; set; }


        public int Id_order { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
    }
}
