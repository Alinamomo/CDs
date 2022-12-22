using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    [Table("Color")]
    public partial class Color
    {
        public Color()
        {
            Constructions = new HashSet<Construction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Construction> Constructions { get; set; }

    }
}
