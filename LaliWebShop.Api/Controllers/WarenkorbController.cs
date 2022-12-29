using Lali.Business.Repository.Kontrakte;
using LaliWebShop.Api.Extension;
using LaliWebShop.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaliWebShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarenkorbController : ControllerBase
    {
        private readonly IWarenkorbRepository warenkorbRepository;
        private readonly IArtikelRepository artikelRepository;

        public WarenkorbController(IWarenkorbRepository warenkorbRepository,
                                   IArtikelRepository artikelRepository)
        {
            this.warenkorbRepository = warenkorbRepository;
            this.artikelRepository = artikelRepository;
        }

        //[HttpGet]
        //[Route("{kundeId}/GetItems")]
        //public async Task<ActionResult<IEnumerable<WarenkorbItemDto>>> GetItems(int kundeId)
        //{
        //    try
        //    {
        //        var warenkorbItems = await this.warenkorbRepository.GetAllItems(kundeId);
        //        if (warenkorbItems == null)
        //        {
        //            return NoContent();
        //        }
        //        var artikels = await this.artikelRepository.GetItems();
        //        if (artikels == null)
        //        {
        //            throw new Exception("kein existierter Artikel in System");
        //        }

        //        var warenkorbItemsDto = warenkorbItems.KonvertToDto(artikels);
        //        return Ok(warenkorbItemsDto);

        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<WarenkorbItemDto>> GetItem(int id)
        //{
        //    try
        //    {
        //        var warenkorbItem = await this.warenkorbRepository.GetItem(id);
        //        if (warenkorbItem == null)
        //        {
        //            return NotFound();
        //        }
        //        var artikel = await artikelRepository.GetItem(warenkorbItem.ArtikelId);
        //        if (artikel == null)
        //        {
        //            return NotFound();
        //        }
        //        var warenkorbItemDto = warenkorbItem.KonvertToDto(artikel);

        //        return Ok(warenkorbItemDto);

        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        //[HttpPost]
        //public async Task<ActionResult<WarenkorbItemDto>> PostItem([FromBody] WarenkorbItemToAddDto warenkorbItemToAddDto)
        //{
        //    try
        //    {
        //        var newWarenkorbItem = await this.warenkorbRepository.AddItem(warenkorbItemToAddDto);
        //        if (newWarenkorbItem == null)
        //        {
        //            return NoContent();
        //        }
        //        var artikel = await artikelRepository.GetItem(newWarenkorbItem.ArtikelId);
        //        if (artikel == null)
        //        {
        //            throw new Exception($"Irgendwas ist Schief gelaufen (productId:({warenkorbItemToAddDto.ArtikelId})");
        //        }

        //        var newWarenkorbItemDto = newWarenkorbItem.KonvertToDto(artikel);
        //        return CreatedAtAction(nameof(GetItem), new { id = newWarenkorbItemDto.Id }, newWarenkorbItemDto);


        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        //[HttpDelete("{id:int}")]
        // public async Task<ActionResult<WarenkorbItemDto>>DeleteItem(int id)
        // {
        //    try
        //    {
        //        var warenkorbItem = await this.warenkorbRepository.DeleteItem(id);
        //        if(warenkorbItem== null)
        //        {
        //            return NotFound();
        //        }
        //        var arrikel = await this.artikelRepository.GetItem(warenkorbItem.ArtikelId);
        //        if (arrikel == null)
        //            return NotFound();

        //        var warenkorbItemDto = warenkorbItem.KonvertToDto(arrikel);
        //        return Ok(warenkorbItemDto);
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        // }

        //[HttpPatch("{id:int}")]
        //public async Task<ActionResult<WarenkorbItemDto>> UpdateMenge(int id, WarenkorbMengeUpdateDto warenkorbMengeUpdateDto)
        //{
        //    try
        //    {
        //        var warenkorbItem = await this.warenkorbRepository.UpdateMenge(id, warenkorbMengeUpdateDto);
        //        if(warenkorbItem == null)
        //        {
        //            return NotFound();
        //        }
        //        var artikel = await this.artikelRepository.GetItem(warenkorbItem.ArtikelId);
        //        var warenkorbItemDto = warenkorbItem.KonvertToDto(artikel);
        //        return Ok(warenkorbItemDto);
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

        //    }
        //}

    }
}
