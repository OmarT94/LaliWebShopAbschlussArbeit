using LaliWebShop.Models;
using LaliWebShop.Models.Dtos;
using LaliWebShop.Web.Services.Kontrakte;
using Newtonsoft.Json;

namespace LaliWebShop.Web.Services
{
    public class BestellungService : IBestellungService
    {
        private readonly HttpClient httpClient;
        private IConfiguration _configuration;
        private string BaseServerUrl;
        public BestellungService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this._configuration = configuration;
            BaseServerUrl = _configuration.GetSection("BaseServerUrl").Value;
        }



        public async Task<BestellungPosDto> Get(int bestellungId)
        {
            try
            {
                var response = await this.httpClient.GetAsync($"/api/bestellung/{bestellungId}");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {

                    var bestellung = JsonConvert.DeserializeObject<BestellungPosDto>(content);
                    return bestellung;

                }
                else
                {
                    var errorModel = JsonConvert.DeserializeObject<ErrorModelDto>(content);
                    throw new Exception(errorModel.ErrorMessage);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<BestellungPosDto>> GetAll(string? benutzerId=null)
        {
            try
            {
                var response = await this.httpClient.GetAsync("/api/bestellung");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var bestellungs = JsonConvert.DeserializeObject<IEnumerable<BestellungPosDto>>(content);
                    return bestellungs;
                }
                return new List<BestellungPosDto>();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //public Task<IEnumerable<BestellungPosDto>> GetAll(string? benutzerId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
