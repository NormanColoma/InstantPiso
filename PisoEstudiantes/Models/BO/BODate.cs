using PisoEstudiantes.Models.DAO;
using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PisoEstudiantes.Models.BO
{
    public class BODate : IDate
    {
        private DAODate dd = new DAODate();

        public bool createDate(Date date)
        {
            return dd.createDate(date);
        }
    }
}