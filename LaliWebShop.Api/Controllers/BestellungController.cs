using Lali.Business.Repository.Kontrakte;
using LaliWebShop.Api.Extension;
using LaliWebShop.Models;
using LaliWebShop.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace LaliWebShop.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BestellungController : ControllerBase
    {
        private readonly IBestellungRepository _bestellungRepository;
        private readonly IEmailSender _emailSender;

        public BestellungController(IBestellungRepository bestellungRepository, IEmailSender emailSender)
        {
            this._bestellungRepository = bestellungRepository;
            this._emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bestellungRepository.GetAll());
        }

        [HttpGet("{bestellungId}")]
        public async Task<IActionResult> Get(int? bestellungId)
        {
            if (bestellungId == null || bestellungId == 0)
            {
                return BadRequest(new ErrorModelDto()
                {
                    ErrorMessage = "Ungültige Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var bestellung = await _bestellungRepository.Get(bestellungId.Value);
            if (bestellung == null)
            {
                return BadRequest(new ErrorModelDto()
                {
                    ErrorMessage = "Ungültige Id",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(bestellung);
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add([FromBody] BezahlungDto bezahlungDTO)
        {
            bezahlungDTO.Bestellung.Bestellung.BestelltAm = DateTime.Now;
            var result = await _bestellungRepository.Add(bezahlungDTO.Bestellung);
            return Ok(result);
        }

        [HttpPost]
        [ActionName("bezahlungerfolgreich")]
        public async Task<IActionResult> BezahlungErfolgreich([FromBody] BestellungDto bestellungDTO)
        {

            var service = new SessionService();
            var sessionDetails = service.Get(bestellungDTO.SessionId);
            if (sessionDetails.PaymentStatus == "paid")
            {
                var result = await _bestellungRepository.BezahlungErfolgreich(bestellungDTO.Id,sessionDetails.PaymentIntentId);
                await _emailSender.SendEmailAsync(bestellungDTO.Email, "Lali Bestellung Konfirmation",
                    "Neue Bestellung wurde gegeben:" + bestellungDTO.Id);
                if (result == null)
                {
                    return BadRequest(new ErrorModelDto()
                    {
                        ErrorMessage = "Zahlung kann nicht als erfolgreich markiert werden"
                    });
                }
                return Ok(result);
            }

            return BadRequest();
        }




        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ArtikelDto>>> GetItems()
        //{
        //    try
        //    {
        //        var artikels = await this.artikelRepository.GetItems();
        //        var artikelCategorie = await this.artikelRepository.GetKategorien();
        //        if(artikels== null || artikelCategorie == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            var artikelDto = artikels.KonvertToDto(artikelCategorie);
        //            return Ok(artikelDto);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Fehler beim abrufen die Daten von DB ");

        //    }
        //}

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<ArtikelDto>> GetItem(int id)
        //{
        //    try
        //    {
        //        var artikel = await this.artikelRepository.GetItem(id);
        //        if (artikel == null )
        //        {
        //            return BadRequest();
        //        }
        //        else
        //        {
        //            var artikelKategorie= await this.artikelRepository.GetKategorie(artikel.KategorieId);
        //            var artikelDto=artikel.KonvertToDto(artikelKategorie);
        //            return Ok(artikelDto);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Fehler beim abrufen die Daten von DB ");

        //    }
        //}

        //Creat
        //[HttpPost]
        //public async Task<ActionResult> AddArtikel(ArtikelDto artikel)
        //{
        //    ArtikeltoAddDto result = await artikelRepository.AddArtikel(artikel);
        //    return Ok(result);
        //}

        ////Update
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateArtikel(ArtikelDto artikel)
        //{

        //    ArtikeltoAddDto artikeltoAdd= await artikelRepository.UpdateArtikel(artikel);
        //    return Ok(artikeltoAdd);
        //}

        ////Delete
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteArtikel(int id)
        //{
        //    return Ok(artikelRepository.DeleteArtikel(id));

        //}


    }
}
