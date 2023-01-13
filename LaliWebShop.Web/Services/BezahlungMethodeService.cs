using LaliWebShop.Models;
using LaliWebShop.Models.Dtos;
using LaliWebShop.Web.Services.Kontrakte;
using Newtonsoft.Json;
using System.Text;

namespace LaliWebShop.Web.Services
{
    public class BezahlungMethodeService : IBezahlungMethodeService
    {
        private readonly HttpClient httpClient;
      
        public BezahlungMethodeService(HttpClient httpClient)
        {
            //httpClient.Timeout = Timeout.InfiniteTimeSpan;
            this.httpClient = httpClient;
            

        }

       

        public async Task<SuccessModelDto> Checkout(BezahlungDto bezahlungDtoModel)
        {
            try
            {

                var content = JsonConvert.SerializeObject(bezahlungDtoModel);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("api/bezahlungmethode/create", bodyContent);
                string responseResult = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<SuccessModelDto>(responseResult);
                    return result;
                }
                else
                {
                    var errorModel = JsonConvert.DeserializeObject<ErrorModelDto>(responseResult);
                    throw new Exception(errorModel.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
    }
}
