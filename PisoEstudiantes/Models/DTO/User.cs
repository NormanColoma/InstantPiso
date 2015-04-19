using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PisoEstudiantes.Models.DTO
{
    public class User
    {

        #region private properties
        private string email = "";
        private string name = "";
        private string phone = "";
        private string age = "";
        private string leaseholder = "";
        private string surname = "";
        private string password = "";
        private string gender = "";

        #endregion



        #region Public properties

        public User(string email, string name, string phone, string age, string leaseholder, string surname, string password, string gender) {
            this.email = email;
            this.name = name;
            this.phone = phone;
            this.age = age;
            this.leaseholder = leaseholder;
            this.surname = surname;
            this.password = password;
            this.gender = gender;
        
        }
        
        
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        

        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        

        public string Leaseholder
        {
            get { return leaseholder; }
            set { leaseholder = value; }
        }
       

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }


        #endregion
    }
}