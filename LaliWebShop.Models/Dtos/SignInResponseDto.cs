using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaliWebShop.Models.Dtos
{
    public class SignInResponseDto
    {
        public bool IsAuthErfolgreich { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public BenutzerDto BenutzerDto { get; set; }
    }
}
