using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    [Table("Product")]
    public partial class Product
    {

        public Product()
        {
            Constructions = new HashSet<Construction>();
            Accesouriess = new HashSet<Accesouries>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Id_acc { get; set; }
        public int Id_constr { get; set; }



        public virtual ICollection<Construction> Constructions { get; set; }

        public virtual ICollection<Accesouries> Accesouriess { get; set; }

    }
}
