using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PisoEstudiantes.Models.DTO
{
    public class Renter
    {
        private Flat flat;
        private double rent_price;

        public Renter()
        {

        }
        public Renter(Flat flat, double rent_price)
        {
            this.flat = flat;
            this.rent_price = rent_price;
        }

        public Flat Flat
        {
            get { return flat; }
            set { flat = value; }
        }

        public double Rent_price
        {
            get { return rent_price; }
            set { rent_price = value; }
        }
    }
}