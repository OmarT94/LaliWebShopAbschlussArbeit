using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lali.DataAccess
{
    public class ApplicationBenutzer:IdentityUser
    {
        //public string Anrede { get; set; }

        public string Name { get; set; }
        public string Vorname { get; set; }

        public string HandyNummer { get; set; }

       

        //public string Strasse { get; set; }

  

        //public string Hausnummer { get; set; }

     

        //public int Plz { get; set; }

      

        //public string Ort { get; set; }

     

        //public string Land { get; set; }

    

        //public string Email { get; set; }

    }
}
