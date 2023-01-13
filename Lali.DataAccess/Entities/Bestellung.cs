using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lali.DataAccess.Entities
{
    public class Bestellung
    {
        [Key]
        public int Id { get; set; }
        //public int BestellNummer { get; set; }

        [Required]
        public string BenutzerId { get; set; }

        [Required]

        public DateTime BestelltAm { get; set; }

        [Required]
       
        public decimal SummeNetto { get; set; }

        //[Required]
       
        public decimal MwSt { get; set; }
        //[Required]
    
        public decimal SummeBrutto { get; set; }

        //für Bezahlung
        [Required]
        public string Status { get; set; }
        //[Required]
        public string? BezahlungId { get; set; }
        //[Required]
        public string? SessionId { get; set; }

        [Required]
        
        public string Anrede { get; set; }

        [Required]
       
        public string Name { get; set; }

        [Required]
       
        public string Vorname { get; set; }

        [Required]
      
        public string HandyNummer { get; set; }

        [Required]
 
        public string Strasse { get; set; }

        [Required]
      
        public string Hausnummer { get; set; }

        [Required]
       
        public int Plz { get; set; }

        [Required]
     
        public string Ort { get; set; }

        [Required]
       
        public string Land { get; set; }

        [Required]
      
        public string Email { get; set; }

        public string? Tracking { get; set; }
        public string? Transporter { get; set; }


    }
}
