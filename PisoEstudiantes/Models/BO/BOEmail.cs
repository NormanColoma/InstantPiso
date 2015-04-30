using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace PisoEstudiantes.Models.BO
{
    public class BOEmail : IEmailSender
    {

        Email e = new Email();
        public void mannageCenter(User u, string action)
        {
            switch (action)
            {
                case "canceled":
                    accountCanceled(u);
                    break;
                case "created":
                    userRegistered(u);
                    break;
            }
        }
        public void accountCanceled(User u)
        {
            Email.subject = "Cierre de  cuenta InstantPiso";
            Email.message = u.Name + " le informamos de que su cuenta ha sido cerrada.";
            sendEmail(u);
        }
        public void userRegistered(User u)
        {
            Email.subject = "Bienvenido a InstantPiso";
            Email.message = "Hola "+u.Name + " le confirmamos que su cuenta en InstantPiso ha sido creada.";
            sendEmail(u);
        }

        public void sendEmail(User u)
        {

            Email.receiver = u.Email;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(Email.sender, Email.senderPass);

            using (var email = new MailMessage(Email.sender, Email.receiver))
            {
                email.Subject = Email.subject;
                email.Body = Email.message;
                email.IsBodyHtml = true;
                smtp.Send(email);
            }
        }
    }
}