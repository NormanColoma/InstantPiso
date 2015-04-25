using PisoEstudiantes.Models.DAO;
using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PisoEstudiantes.Models.BO
{
    public class BOUser:IUser
    {
        private DAOUser du = new DAOUser();
        public bool login(User u)
        {
            return du.login(u);
        }

        public User getUser(string email)
        {
            return du.getUser(email);
        }
    }
}