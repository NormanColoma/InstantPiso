﻿using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PisoEstudiantes.Models
{
    interface IUser
    {
        //TODO (A completar en el siguiente sprint, para este solo necesitamos la operación login);
        public bool login(User u);
    }
}
