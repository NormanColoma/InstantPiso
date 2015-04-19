using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PisoEstudiantes.Models.DTO
{
    public class Owner : User
    {
        //TODO
        private List<Renter> lRenters;
        private List<Flat> lFlats;

        

        public List<Flat> LFlats
        {
            get { return lFlats; }
            set { lFlats = value; }
        }

        public List<Renter> LRenters
        {
            get { return lRenters; }
            set { lRenters = value; }
        }
    }
}