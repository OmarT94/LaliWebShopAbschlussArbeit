using LaliWebShop.Api.Data;
using LaliWebShop.Api.Entities;
using LaliWebShop.Api.Repository.Kontrakte;
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
    }
}
