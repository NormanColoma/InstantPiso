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
        private string type;

        public Notification()
        {

        }
        public Notification(string message, bool check, User user, string type)
        {
            this.message = message;
            this.notificacion_checked = check;
            this.user = user;
            this.type = type;
        }

        public Notification(int id, string message, bool check, User user, string type)
        {
            this.id = id;
            this.message = message;
            this.notificacion_checked = check;
            this.user = user;
            this.type = type;
        }

        public Notification(int id, string message, bool check, User user, int id_flat, string type)
        {
            this.id = id;
            this.message = message;
            this.notificacion_checked = check;
            this.user = user;
            this.idFlat = id_flat;
            this.type = type;
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

        public User NotifiedUser
        {
            get { return user; }
            set { user = value; }
        }

        public int IDFlat
        {
            get { return idFlat; }
            set { idFlat = value; }
        }

        public String Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}