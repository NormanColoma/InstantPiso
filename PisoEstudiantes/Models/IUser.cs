using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PisoEstudiantes.Models
{
    interface IUser
    {
        public bool login(User u);
    }
}
