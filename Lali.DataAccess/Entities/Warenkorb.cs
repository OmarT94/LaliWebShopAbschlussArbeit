using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lali.DataAccess.Entities
{
    public class Warenkorb
    {
        public int Id { get; set; }
        public int KundenId { get; set; }
        public int BestellungId { get; set; }
    }
}
