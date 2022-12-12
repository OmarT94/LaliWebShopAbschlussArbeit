using LaliWebShop.Api.Data;
using LaliWebShop.Api.Entities;
using LaliWebShop.Api.Repository.Kontrakte;
using LaliWebShop.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LaliWebShop.Api.Repository
{
    public class ArtikelRepository : IArtikelRepository
    {
        private readonly ShopDbContext shopDbContext;

        public ArtikelRepository(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }

        public async Task<ArtikeltoAddDto> AddArtikel(ArtikeltoAddDto dto)
        {
            try
            {
                Artikel neuerArtikel = new();

                neuerArtikel.Name = dto.Name;
                neuerArtikel.Bezeichnung = dto.Bezeichnung;
                neuerArtikel.PreisSingleNetto = dto.PreisSingleNetto;
                neuerArtikel.ImageURL = dto.ImageURL;
                neuerArtikel.Menge = dto.Menge;
                neuerArtikel.KategorieName = dto.KategorieName;
                neuerArtikel.Artikelnummer = dto.Artikelnummer;
                shopDbContext.Add(neuerArtikel);
                await shopDbContext.SaveChangesAsync();
            } catch (Exception ex)
            {
               
            }
            return dto;
        }
        public async Task<ArtikeltoAddDto> UpdateArtikel(ArtikeltoAddDto artikel)
        {
            try
            {
                shopDbContext.Entry(artikel).State = EntityState.Modified;
                Artikel neuerArtikel = new();
                neuerArtikel.Name = artikel.Name;
                neuerArtikel.Bezeichnung = artikel.Bezeichnung;
                neuerArtikel.PreisSingleNetto = artikel.PreisSingleNetto;
                neuerArtikel.ImageURL = artikel.ImageURL;
                neuerArtikel.Menge = artikel.Menge;
                neuerArtikel.KategorieName = artikel.KategorieName;
                neuerArtikel.Artikelnummer = artikel.Artikelnummer;
                shopDbContext.Update(neuerArtikel);
                await shopDbContext.SaveChangesAsync();
               
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public async Task<Artikel> DeleteArtikel(int id)
        {
            var artikel = new Artikel { Id = id };
            shopDbContext.Remove(artikel);
            await shopDbContext.SaveChangesAsync();
            return NoContent();
        }
        public async Task<Artikel> GetItem(int id)
        {
            var artikel= await shopDbContext.Artikel.FindAsync(id);
            return artikel;
        }
        public async Task<IEnumerable<Artikel>> GetItems()
        {
            var artikel = await this.shopDbContext.Artikel.ToListAsync();
            return artikel;
        }

        public async Task<Kategorie> GetKategorie(int id)
        {
            var kategorie = await shopDbContext.Kategorie.SingleOrDefaultAsync(c=> c.Id ==id);
            return kategorie;
        }

        public async Task<IEnumerable<Kategorie>> GetKategorien()
        {
            var kategorie = await this.shopDbContext.Kategorie.ToListAsync();
            return kategorie;
        }

        //public async Task<Artikel> UpdateArtikel(Artikel artikel)
        //{
        //    shopDbContext.Entry(artikel).State = EntityState.Modified;
        //    await shopDbContext.SaveChangesAsync();
        //    return NoContent();
        //}

        private Artikel NoContent()
        {
            throw new NotImplementedException();
        }
    }
}
