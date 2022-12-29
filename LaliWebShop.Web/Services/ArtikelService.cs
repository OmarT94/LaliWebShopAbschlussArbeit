using LaliWebShop.Models;
using LaliWebShop.Models.Dtos;
using LaliWebShop.Web.Services.Kontrakte;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace LaliWebShop.Web.Services
{
    public class ArtikelService: IArtikelService
    {
        private readonly HttpClient httpClient;
        private IConfiguration _configuration;
        private string BaseServerUrl;
        public ArtikelService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this._configuration = configuration;
            BaseServerUrl = _configuration.GetSection("BaseServerUrl").Value;
        }

       

        public async Task<ArtikelDto> GetItem(int artikelId)
        {
            try
            {
                var response = await this.httpClient.GetAsync($"/api/Artikel/{artikelId}");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                   
                    var artikel = JsonConvert.DeserializeObject<ArtikelDto>(content);
                    artikel.ImageURL = BaseServerUrl + artikel.ImageURL;
                    return artikel;
                  
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

        public async Task<IEnumerable<ArtikelDto>> GetItems()
        {
            try
            {
                var response = await this.httpClient.GetAsync("/api/Artikel");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var artikels = JsonConvert.DeserializeObject<IEnumerable<ArtikelDto>>(content);
                    foreach(var art in artikels)
                    {
                        art.ImageURL = BaseServerUrl + art.ImageURL;
                    }
                    return artikels;
                }
                return new List<ArtikelDto>();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        
    }
}
