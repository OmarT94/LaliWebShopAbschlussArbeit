using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaliWebShop.Models.Dtos
{
    public class BestellungDto
    {
        
        public int Id { get; set; }
        [Required]
        public int BenutzerId { get; set; }
        [Required]

        public DateTime BestelltAm { get; set; }
        [Required]
        [Display(Name ="Bestellung Netto")]
        public decimal SummeNetto { get; set; }
        [Required]
        [Display(Name = "MwSt")]
        public decimal MwSt { get; set; }
        [Required]
        [Display(Name = "Bestellung Brutto")]
        public decimal SummeBrutto { get; set; }

        //für Bezahlung
        [Required]
        public string Status { get; set; }
        [Required]
        public string? BrzahlungId { get; set; }
        [Required]
        public string? SessionId { get; set; }

        [Required]
        [Display(Name = "Anrede")]
        public string Anrede { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Vorname")]
        public string Vorname { get; set; }
        [Required]
        [Display(Name = "Handy")]
        public string HandyNummer { get; set; }
        [Required]
        [Display(Name = "Straße")]
        public string Strasse { get; set; }
        [Required]
        [Display(Name = "HausNummer")]
        public string Hausnummer { get; set; }
        [Required]
        [Display(Name = "PLZ")]
        public int Plz { get; set; }
        [Required]
        [Display(Name = "Ort")]
        public string Ort { get; set; }
        [Required]
        [Display(Name = "Land")]
        public string Land { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }


    }
}
