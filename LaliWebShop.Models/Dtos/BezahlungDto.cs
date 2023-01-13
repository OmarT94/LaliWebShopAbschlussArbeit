using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaliWebShop.Models.Dtos
{
    public class BezahlungDto
    {
        public BezahlungDto()
        {
            SuccessUrl = "https://localhost:44340/BestellungConfirmation";
            CancelUrl = "https://localhost:44340/Kasse";
        }
        public BestellungPosDto Bestellung { get; set; }
        public string SuccessUrl { get; set; }
        public string CancelUrl { get; set; }
    }
}
