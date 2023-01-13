using LaliWebShop.Models.Dtos;

namespace LaliWebShop.Web.Services.Kontrakte
{
    public interface IBestellungService
    {
        public Task<IEnumerable<BestellungPosDto>> GetAll(string? benutzerId);
        public Task<BestellungPosDto> Get(int bestellungId);

        public Task<BestellungPosDto> Add(BezahlungDto bezahlungDto);
        public Task<BestellungDto> BezaglungErfolgreich(BestellungDto bestellungDto);
    }
}
