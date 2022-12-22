using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public partial class ModelRangeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ImageSource { get; set; }
        public ModelRangeModel(DAL.ModelRange modelr)
        {
            Id = modelr.Id_modelrange;
            Name = modelr.Name;

            ImageSource = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Sources\\ModelRange_" + Id + ".png";


        }
    }
}
