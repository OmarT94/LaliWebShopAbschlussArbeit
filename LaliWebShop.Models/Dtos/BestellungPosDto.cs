using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaliWebShop.Models.Dtos
{
     public class BestellungPosDto
    {
        public BestellungDto Bestellung { get; set; }
        public List<BestellungItemDto> BestellungItems { get; set; }
    }
}
