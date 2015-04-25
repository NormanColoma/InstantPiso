﻿using PisoEstudiantes.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace PisoEstudiantes.Models
{
        public class LoginViewModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Correo electrónico")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [Display(Name = "¿Recordar cuenta?")]
            public bool RememberMe { get; set; }
        }

        public class AccountViewModel
        {

            public AccountViewModel returnAccount(User u)
            {
                AccountViewModel avm = new AccountViewModel();
                avm.Email = u.Email;
                avm.Name = u.Name;
                avm.Surname = u.Surname;
                avm.Phone = u.Phone;
                avm.Img = u.IMG;
                return avm;
            }
            [Required]
            [EmailAddress]
            [Display(Name = "Correo electrónico")]
            public string Email { get; set; }

            [RegularExpression(@"^[A-Z]+[a-zA-ZÁÉÍÓÚáéíóuñÑ''-'\s_ ]*$", ErrorMessage = "Introduce un nombre válido")]
            [Required]
            [StringLength(30)]
            [Display(Name = "Nombre")]
            public string Name { get; set; }

            [RegularExpression(@"^[A-Z]+[a-zA-ZÁÉÍÓÚáéíóuñÑ''-'\s_ ]*$", ErrorMessage = "Introduce un apellido válido")]
            [Required]
            [StringLength(50)]
            [Display(Name = "Apellidos")]
            public string Surname { get; set; }

            [Required]
            [RegularExpression(@"^[9|6|7][0-9]{8}$", ErrorMessage = "El teléfono introducido no es un teléfono válido")]
            [Display(Name = "Teléfono")]
            public string Phone { get; set; }

            public string Img { get; set; }
        }
}