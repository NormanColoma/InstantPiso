using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PisoEstudiantes.Models
{
    public interface IEmailSender
    {
        void sendEmail(User u);
        void mannageCenter(User u, string action);
        void accountCanceled(User u);
        void userRegistered(User u);
    }
}
