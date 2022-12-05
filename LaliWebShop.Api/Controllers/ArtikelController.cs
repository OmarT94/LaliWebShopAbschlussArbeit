using LaliWebShop.Api.Extension;
using LaliWebShop.Api.Repository.Kontrakte;
using LaliWebShop.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaliWebShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtikelController : ControllerBase
    {
        private readonly IArtikelRepository artikelRepository;

        public ArtikelController(IArtikelRepository artikelRepository)
        {
            this.artikelRepository = artikelRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtikelDto>>> GetItems()
        {
            try
            {
                var artikels = await this.artikelRepository.GetItems();
                var artikelCategorie = await this.artikelRepository.GetKategorien();
                if(artikels== null || artikelCategorie == null)
                {
                    return NotFound();
                }
                else
                {
                    var artikelDto = artikels.KonvertToDto(artikelCategorie);
                    return Ok(artikelDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Fehler beim abrufen die Daten von DB ");
                
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ArtikelDto>> GetItem(int id)
        {
            try
            {
                var artikel = await this.artikelRepository.GetItem(id);
                if (artikel == null )
                {
                    return BadRequest();
                }
                else
                {
                    var artikelKategorie= await this.artikelRepository.GetKategorie(artikel.KategorieId);
                    var artikelDto=artikel.KonvertToDto(artikelKategorie);
                    return Ok(artikelDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Fehler beim abrufen die Daten von DB ");

            }
        }

    }
}
