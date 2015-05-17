using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PisoEstudiantes.Models.DTO
{
    public class Notification
    {
        private int id;
        private string message;
        private bool notificacion_checked;
        private User user;
        private int idFlat;

        public Notification(string message, bool check, User user)
        {
            this.message = message;
            this.notificacion_checked = check;
            this.user = user;
        }

        public Notification(int id, string message, bool check, User user)
        {
            this.id = id;
            this.message = message;
            this.notificacion_checked = check;
            this.user = user;
        }


        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public String Message
        {
            get { return message; }
            set { message = value; }
        }

        public bool Check
        {
            get { return notificacion_checked; }
            set { notificacion_checked = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public int IDFlat
        {
            get { return idFlat; }
            set { idFlat = value; }
        }
    }
}