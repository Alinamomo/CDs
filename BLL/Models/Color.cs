using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class ColourModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ColourModel(DAL.Colour Colour)
        {
            Id = Colour.Id_colour;
            Name = Colour.Name;

        }
    }
}
