using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    [Table("Construction")]
    public partial class Construction
    {
        public Construction()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public int HorsePower { get; set; }
        public string Transmission { get; set; }
        public double EngineCapacity { get; set; }
        public string Drive { get; set; }
        public string EngineType { get; set; }

        public int InStock { get; set; }
        public int Id_model { get; set; }
        public int Id_color { get; set; }

        public virtual ICollection<Product> Products { get; set; }


    }
}
