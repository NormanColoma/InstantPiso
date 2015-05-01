using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace PisoEstudiantes.Models
{
    public class FlatViewModel
    {

    }

    public class AnnouncementViewModel
    {
        public bool inHome { get; set; }

        [Required]
        [RegularExpression(@"^[1-9]\d*(\.\d+)?$", ErrorMessage = "Introduce una cantidad en €")]
        [Display(Name = "Alquiler por mes")]
        public double rentPerMonth { get; set; }

        [Required]
        [Display(Name = "Provincia")]
        public string province { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-ZÁÉÍÓÚáéíóuñÑ''-'\s_ ]*$", ErrorMessage = "Introduce una ciudad válida")]
        [StringLength(70)]
        [Required]
        [Display(Name = "Ciudad")]
        public string city { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Dirección")]
        public string address { get; set; }

        [Required]
        [RegularExpression(@"^([1-9]{2}|[0-9][1-9]|[1-9][0-9])[0-9]{3}$",ErrorMessage= "Introduce un código postal válido")]
        [Display(Name = "Código postal")]
        public string postal_code { get; set; }

        [Required]
        [Display(Name="Disponible desde")]
        public DateTime avialableDate { get; set; }

        
        public int minimum { get; set; }

        public int bedrooms { get; set; }

        public int bathrooms { get; set; }

        public string property_type { get; set; }

        public int bedrooms_availables {get; set;}


        [RegularExpression(@"^[A-Z]+[a-zA-ZÁÉÍÓÚáéíóuñÑ''-'\s_ ]*$", ErrorMessage = "Introduce una títiulo válido")]
        [StringLength(70)]
        public string tittle { get; set; }


        [StringLength(5000)]
        public string description { get; set; }

        
        [Display(Name = "Foto de perfil")]
        public string main_img { get; set; }
    }
}