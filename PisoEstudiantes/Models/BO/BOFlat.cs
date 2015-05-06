using PisoEstudiantes.Models.DAO;
using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PisoEstudiantes.Models.BO
{
    public class BOFlat : IFlat
    {
        private DAOFlat df = new DAOFlat();
        public List<Flat> getFlatsByProvince(string city)
        {
            return df.getFlatsByProvince(city);
        }

        public List<Flat> getLastFlats()
        {
            return df.getLastFlats();
        }

        public bool insertFlat(Flat f)
        {
            return df.insertFlat(f);
        }

        public List<Flat> getFlatsByOwner(string email)
        {
            return df.getFlatsByOwner(email);
        }

        public bool deleteFlat(int id)
        {
            return df.deleteFlat(id);
        }

        public Flat getFlat(int id)
        {
            return df.getFlat(id);
        }

        public bool updateFlat(Flat f)
        {
            return df.updateFlat(f);
        }
    }
}