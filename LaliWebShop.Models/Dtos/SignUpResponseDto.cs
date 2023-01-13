using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaliWebShop.Models.Dtos
{
    public class SignUpResponseDto
    {
        public bool IstRegisterationErfolgreich { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
