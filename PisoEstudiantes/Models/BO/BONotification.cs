using PisoEstudiantes.Models.DAO;
using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PisoEstudiantes.Models.BO
{
    public class BONotification : INotifaction
    {

        private DAONotification dn = new DAONotification();

        public void createNotification(Notification n)
        {
            dn.createNotification(n);
        }

        public void updateNotification(Notification n)
        {
            dn.updateNotification(n);
        }
    }
}