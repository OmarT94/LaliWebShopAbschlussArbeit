using LaliWebShop.Models;
using LaliWebShop.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace LaliWebShop.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BezahlungMethodeController : Controller
    {
        private readonly IConfiguration _configuration;


        public BezahlungMethodeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        [Authorize]
        [ActionName("Create")]
        public async Task<IActionResult> Create([FromBody] BezahlungDto bezahlungDto)
        {
            try
            {

                //var domain = _configuration.GetValue<string>("Lali_Client_UR"); //Sessions stripe.net   Stripe session demo

                var options = new SessionCreateOptions
                {
                    SuccessUrl = bezahlungDto.SuccessUrl,
                    CancelUrl = bezahlungDto.CancelUrl,
                     LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                    PaymentMethodTypes = new List<string> { "klarna","card", "sepa_debit","sofort" }
                    

                };


                foreach (var item in bezahlungDto.Bestellung.BestellungItems)
                {
                    var sessionLineItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)(item.ArtikelPreisSingleNetto * 100), //20.00 -> 2000
                            Currency = "eur",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Artikel.Name
                            }
                        },
                        Quantity = item.Menge
                    };
                    options.LineItems.Add(sessionLineItem);
                }

                var service = new SessionService();
                Session session = service.Create(options);
                return Ok(new SuccessModelDto()
                {
                    Data = session.Id 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModelDto()
                {
                    ErrorMessage = ex.Message
                });
            }
        }
    }
}
