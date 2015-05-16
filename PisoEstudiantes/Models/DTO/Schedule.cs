using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PisoEstudiantes.Models.DTO
{
    public class Schedule
    {
        public string Day { get; set; }
        public string Hour { get; set; }
        public int IDFlat { get; set; }

        public int ID { get; set; }
    }
}