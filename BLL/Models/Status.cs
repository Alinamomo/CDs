
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class StatusModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StatusModel(DAL.Status status)
        {
            Id = status.id_status;
            Name = status.Name;

        }
    }
}
