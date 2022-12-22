using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("ModelRange")]
    public partial class ModelRange
    {
        public ModelRange()
        {
            Constructions = new HashSet<Construction>();
        }

        public int Id;
        public string Name;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Construction> Constructions { get; set; }
    }
}
