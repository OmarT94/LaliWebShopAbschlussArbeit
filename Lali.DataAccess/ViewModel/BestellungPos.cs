using Lali.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lali.DataAccess.ViewModel
{
    public class BestellungPos
    {
        public Bestellung Bestellung { get; set; }
        public IEnumerable<BestellungItem> BestellungItems { get; set; } 
    }
}
