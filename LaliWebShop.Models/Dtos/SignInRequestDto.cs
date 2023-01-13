using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaliWebShop.Models.Dtos
{
    public class SignInRequestDto
    {
        [Required(ErrorMessage = "Benutzername ist erforderlich")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Ungültige email address")]
        public string BenutzerName { get; set; }


        [Required(ErrorMessage = "Passwort ist erforderlich.")]
        [DataType(DataType.Password)]
        public string Passwort { get; set; }
    }
}
