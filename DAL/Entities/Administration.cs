using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    [Table("Administration")]
    public partial class Administration
    {
        public Administration()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public int Experience { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

