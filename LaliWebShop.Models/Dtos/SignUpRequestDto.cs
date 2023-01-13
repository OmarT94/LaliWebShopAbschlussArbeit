using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaliWebShop.Models.Dtos
{
    public class SignUpRequestDto
    {
        [Required(ErrorMessage = "Name ist erforderlich")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vorname ist erforderlich")]
        public string Vorname { get; set; }

        [Required(ErrorMessage = "Email ist erforderlich")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "ungültige email address")]
        public string Email { get; set; }

        public string HandyNummer { get; set; }


        [Required(ErrorMessage = "Passwort ist erforderlich.")]
        [DataType(DataType.Password)]
        public string Passwort { get; set; }

        [Required(ErrorMessage = "Passwort bestätigen ")]
        [DataType(DataType.Password)]
        [Compare("Passwort", ErrorMessage = "Passwort and Passwort bestätigen passen nicht zusammen")]
        public string PasswortBestaetigen { get; set; }
    }
}
