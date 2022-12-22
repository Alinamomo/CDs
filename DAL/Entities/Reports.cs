using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Reports
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }
        public int Id_product { get; set; }
    }
}
