using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PisoEstudiantes.Models.DTO
{
    public class Email
    {
        public static string sender { get; set; }
        public static string senderPass { get; set; }
        public static string subject { get; set; }

        public static string message { get; set; }

        public static string receiver { get; set; }

        static Email()
        {
            sender = "ua.norman@gmail.com";
            senderPass = "capulleitor";
        }
    }
}