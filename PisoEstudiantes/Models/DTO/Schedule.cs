using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PisoEstudiantes.Models.DTO
{
    public class Schedule
    {
        private int id;
        private int id_flat;
        private string day;
        private string hour;


        public Schedule(int id, string day, string hour)
        {
            this.id = id;
            this.day = day;
            this.hour = hour;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int IDFlat
        {
            get { return id_flat; }
            set { id_flat = value; }
        }
        public String Day
        {
            get { return day; }
            set { day = value; }
        }

        public String Hour
        {
            get { return hour; }
            set { hour = value; }
        }
    }
}