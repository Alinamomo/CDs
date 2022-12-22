using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Id_status { get; set; }
        public int Id_client { get; set; }
        public int Id_adm { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
