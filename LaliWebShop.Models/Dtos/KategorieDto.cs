using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaliWebShop.Models.Dtos
{
    public class KategorieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Bitte Name eingeben!")]
        public string Name { get; set; }
    }
}
