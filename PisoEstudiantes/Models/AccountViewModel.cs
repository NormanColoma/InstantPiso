using PisoEstudiantes.Models.DTO;
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
                avm.Password = u.Password;
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

            [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [RegularExpression(@"^[9|6|7][0-9]{8}$", ErrorMessage = "El teléfono introducido no es un teléfono válido")]
            [Display(Name = "Teléfono")]
            public string Phone { get; set; }

            public string Img { get; set; }

            [Required]
            [Display(Name = "Edad")]
            public string Age { get; set; }

            [Required]
            [Display(Name = "Sexo")]
            public string Gender { get; set; }

            [Display(Name = "Soy arrendatario (necesario si quieres poner pisos en alquiler)")]
            public bool Leaseholder { get; set; }
            [Display(Name = "Ciudad")]
            public string City { get; set; }
        }
}