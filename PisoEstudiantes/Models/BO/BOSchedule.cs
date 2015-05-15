using PisoEstudiantes.Models.DAO;
using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PisoEstudiantes.Models.BO
{
    public class BOSchedule : ISchedule
    {
        private DAOSchedule ds = new DAOSchedule();
        public bool createSchedule(Schedule s)
        {
            return ds.createSchedule(s);
        }

        
    }
}