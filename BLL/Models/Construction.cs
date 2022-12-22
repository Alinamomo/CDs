using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class ConstructionModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int HorsePower { get; set; }
        public string Transmission { get; set; }
        public double EngineCapacity { get; set; }
        public string Drive { get; set; }
        public string EngineType { get; set; }

        public int InStock { get; set; }

        public int Id_model { get; set; }
        public int Id_colour { get; set; }

        public ConstructionModel(DAL.Construction constr)
        {
            Id = constr.Id_constr;
            Name = constr.Name;
            HorsePower = (int)constr.HorsePower;
            Transmission = constr.Transmission;
            EngineCapacity = (double)constr.EngineCapacity;
            Drive = constr.Drive;
            EngineType = constr.EngineType;
            Id_model = (int)constr.Id_model;
            Id_colour = (int)constr.Id_color;
            InStock = (int)constr.InStock;

        }
    }
}
