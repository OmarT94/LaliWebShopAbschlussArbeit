using AutoMapper;
using Lali.Business.Repository.Kontrakte;
using Lali.DataAccess.Data;
using Lali.DataAccess.Entities;
using LaliWebShop.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Lali.Business.Repository
{
    public class ArtikelRepository : IArtikelRepository
    {
        private readonly ShopDbContext shopDbContext;
        private readonly IMapper _mapper;

        public ArtikelRepository(ShopDbContext shopDbContext, IMapper mapper)
        {
            this.shopDbContext = shopDbContext;
            _mapper = mapper;
        }

     
        public async Task<ArtikelDto> GetItem(int id)
        {

            var obj = await shopDbContext.Artikel.Include(a =>a.Kategorie).FirstOrDefaultAsync(a => a.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Artikel, ArtikelDto>(obj);
            }
            return new ArtikelDto();
        }
        public async Task<IEnumerable<ArtikelDto>> GetItems()
        {
            return _mapper.Map<IEnumerable<Artikel>, IEnumerable<ArtikelDto>>(shopDbContext.Artikel.Include(a => a.Kategorie));
        }
        private Artikel NoContent()
        {
            throw new NotImplementedException();
        }

        public async Task <int>DeleteArtikel(int id)
        {
            var obj = await shopDbContext.Artikel.FirstOrDefaultAsync(a => a.Id == id);
            if (obj != null)
            {
               shopDbContext.Artikel.Remove(obj);
                return await shopDbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<ArtikelDto> AddArtikel(ArtikelDto dto)
        {
            var obj = _mapper.Map<ArtikelDto, Artikel>(dto);
            var addDto =shopDbContext.Artikel.Add(obj);
            await shopDbContext.SaveChangesAsync();

            return _mapper.Map<Artikel, ArtikelDto>(addDto.Entity);
        }

        public async Task<ArtikelDto> UpdateArtikel(ArtikelDto dto)
        {
            var objVonDb = await shopDbContext.Artikel.FirstOrDefaultAsync(a => a.Id == dto.Id);
            if (objVonDb != null)
            {
                objVonDb.Name = dto.Name;
                objVonDb.Artikelnummer = dto.Artikelnummer;
                objVonDb.Bezeichnung = dto.Bezeichnung;
                objVonDb.Menge = dto.Menge;
                objVonDb.PreisSingleNetto = dto.PreisSingleNetto;
                objVonDb.ImageURL = dto.ImageURL;
                objVonDb.KategorieId = dto.KategorieId;
                shopDbContext.Artikel.Update(objVonDb);
                shopDbContext.SaveChanges();
                return _mapper.Map<Artikel, ArtikelDto>(objVonDb);

            }
            return dto;
        }
    }
}
