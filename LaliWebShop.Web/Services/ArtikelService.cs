using LaliWebShop.Models.Dtos;
using LaliWebShop.Web.Services.Kontrakte;
using System.Net.Http.Json;

namespace LaliWebShop.Web.Services
{
    public class ArtikelService: IArtikelService
    {
        private readonly HttpClient httpClient;

        public ArtikelService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //public Task<ArtikelDto> AddArtikel(ArtikeltoAddDto artikel)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ArtikelDto> DeleteArtikel(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<ArtikelDto> GetItem(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Artikel/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ArtikelDto);
                    }
                    return await response.Content.ReadFromJsonAsync<ArtikelDto>();
                }
                else
                {
                    var message= await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ArtikelDto>> GetItems()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Artikel");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ArtikelDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ArtikelDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
                
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public Task<ArtikelDto> UpdateArtikel(ArtikeltoAddDto artikel)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
