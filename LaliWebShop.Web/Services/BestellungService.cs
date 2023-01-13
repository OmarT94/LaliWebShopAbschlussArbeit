using LaliWebShop.Models;
using LaliWebShop.Models.Dtos;
using LaliWebShop.Web.Services.Kontrakte;
using Newtonsoft.Json;
using System.Text;

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

        public async Task<BestellungPosDto> Add(BezahlungDto bezahlungDto)
        {
            var content = JsonConvert.SerializeObject(bezahlungDto);
            var bodyContent = new StringContent(content, Encoding.UTF8,"application/json");
            var response = await httpClient.PostAsync("api/bestellung/Add", bodyContent);
            string responseResult = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<BestellungPosDto>(responseResult);
                return result;
            }
            return new BestellungPosDto();
        }

        public async Task<BestellungDto> BezaglungErfolgreich(BestellungDto bestellungDto)
        {
            var content = JsonConvert.SerializeObject(bestellungDto);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/bestellung/bezahlungerfolgreich", bodyContent);
            string responseResult = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<BestellungDto>(responseResult);
                return result;
            }
            var errorModel = JsonConvert.DeserializeObject<ErrorModelDto>(responseResult);
            throw new Exception(errorModel.ErrorMessage);
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
