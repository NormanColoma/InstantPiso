using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PisoEstudiantes.Models.DTO
{
    public class Date
    {
        public string Date { get; set; }
        public int ID { get; set; }

        public int IDFlat { get; set; }

        public int IDOwner { get; set; }

        public string UserEmail { get; set; }
    }
}