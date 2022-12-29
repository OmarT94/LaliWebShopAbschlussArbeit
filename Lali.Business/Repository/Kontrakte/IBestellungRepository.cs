using LaliWebShop.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lali.Business.Repository.Kontrakte
{
    public interface IBestellungRepository
    {
        public Task<BestellungPosDto> Get(int id);
        public Task<IEnumerable<BestellungPosDto>> GetAll(string?benutzerId=null, string? status=null);
        public Task<BestellungPosDto> Add(BestellungPosDto bestellungPosDto);
        public Task<int> Delete(int id);

        public Task<BestellungDto> Update(BestellungDto bestellungDto);
        public Task<BestellungDto> BezahlungErfolgreich(int id);
        public Task<bool> UpdateBestellungStatus(int bestellungId, string status);


    }
}
