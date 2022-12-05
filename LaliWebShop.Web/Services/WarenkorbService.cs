using LaliWebShop.Models.Dtos;
using LaliWebShop.Web.Services.Kontrakte;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace LaliWebShop.Web.Services
{
    public class WarenkorbService : IWarenkorbService
    {
        public event Action<int> WarenkorbGaendert;

        private readonly HttpClient httpClient;
        public WarenkorbService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        

        public async Task<WarenkorbItemDto> AddItem(WarenkorbItemToAddDto warenkorbItemToAddDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<WarenkorbItemToAddDto>("api/Warenkorb", warenkorbItemToAddDto);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(WarenkorbItemDto);
                    }

                    return await response.Content.ReadFromJsonAsync<WarenkorbItemDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode}Message -{message}");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<WarenkorbItemDto> DeleteItem(int id)
        {
            try
            {
                var resppnse = await httpClient.DeleteAsync($"api/Warenkorb/{id}");
                if (resppnse.IsSuccessStatusCode)
                {
                    return await resppnse.Content.ReadFromJsonAsync <WarenkorbItemDto>();

                }
                return default(WarenkorbItemDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<WarenkorbItemDto>> GetItems(int kundeId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Warenkorb/{kundeId}/GetItems");//????
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<WarenkorbItemDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<WarenkorbItemDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status Code:{response.StatusCode} Message: {message}");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RaiseEventWarenkorbGaendert(int gesamteMenge)
        {
            if(WarenkorbGaendert!= null)
            {
                WarenkorbGaendert.Invoke(gesamteMenge);
            }
        }

        public async  Task<WarenkorbItemDto> UpdateMenge(WarenkorbMengeUpdateDto warenkorbMengeUpdateDto)
        {
            var jsonRequest = JsonConvert.SerializeObject(warenkorbMengeUpdateDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json.patch+json");

            var response = await httpClient.PatchAsync($"api/Warenkorb/{warenkorbMengeUpdateDto.WarenkorbItemId}", content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<WarenkorbItemDto>();
            }
            return null;
        }
    }
}
