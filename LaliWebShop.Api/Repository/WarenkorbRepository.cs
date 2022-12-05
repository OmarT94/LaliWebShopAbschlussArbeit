using LaliWebShop.Api.Data;
using LaliWebShop.Api.Entities;
using LaliWebShop.Api.Repository.Kontrakte;
using LaliWebShop.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LaliWebShop.Api.Repository
{
    public class WarenkorbRepository : IWarenkorbRepository
    {
        private readonly ShopDbContext shopDbContext;

        public WarenkorbRepository(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }
        private async Task<bool> WarenKorbsItemExistiert(int warenkorbId, int artikelId)
        {
            return await this.shopDbContext.WarenkorbItem.AnyAsync(c => c.WarenkorbId == warenkorbId && c.ArtikelId == artikelId);


        }
        public async Task<WarenkorbItem> AddItem(WarenkorbItemToAddDto warenkrobItemToAddDto)
        {
            
            if(await WarenKorbsItemExistiert(warenkrobItemToAddDto.WarenkorbId,warenkrobItemToAddDto.ArtikelId) == false)
            {
                var item = await (from artikel in this.shopDbContext.Artikel
                                  where artikel.Id == warenkrobItemToAddDto.ArtikelId
                                  select new WarenkorbItem
                                  {
                                      WarenkorbId = warenkrobItemToAddDto.WarenkorbId,
                                      ArtikelId = artikel.Id,
                                      ArtikelMenge = warenkrobItemToAddDto.ArtikelMenge,
                                      ArtikelName = artikel.Name,
                                      ArtikelBezeichnung = artikel.Bezeichnung,
                                      ArtikelImage = artikel.ImageURL,
                                      ArtikelPreisSingleNetto = artikel.PreisSingleNetto,
                                      ArtikelNummer = artikel.Artikelnummer,

                                  }).SingleOrDefaultAsync();
                if (item != null)
                {
                    var result = await this.shopDbContext.WarenkorbItem.AddAsync(item);
                    await this.shopDbContext.SaveChangesAsync();
                    return result.Entity;

                }
            }
               
            return null;
        }
        
        public async Task<WarenkorbItem> DeleteItem(int id)
        {
            var item = await this.shopDbContext.WarenkorbItem.FindAsync(id);
            if (item != null)
            {
                this.shopDbContext.WarenkorbItem.Remove(item);
                await this.shopDbContext.SaveChangesAsync();
            }
            return item;
        }

        public async Task<IEnumerable<WarenkorbItem>> GetAllItems(int kundeId)
        {
            return await(from warenkorb in this.shopDbContext.Warenkorb
                         join warenkorbItem in this.shopDbContext.WarenkorbItem
                         on warenkorb.Id equals warenkorbItem.WarenkorbId
                         where warenkorb.KundenId== kundeId
                         select new WarenkorbItem
                         {
                             Id = warenkorbItem.Id,
                             ArtikelId = warenkorbItem.ArtikelId,
                             ArtikelMenge = warenkorbItem.ArtikelMenge,
                             KategorielName = warenkorbItem.KategorielName,
                             ArtikelNummer = warenkorbItem.ArtikelNummer,
                             WarenkorbId = warenkorbItem.WarenkorbId,
                             ArtikelName = warenkorbItem.ArtikelName,
                             ArtikelImage= warenkorbItem.ArtikelImage,
                             ArtikelBezeichnung = warenkorbItem.ArtikelBezeichnung,
                             ArtikelPreisSingleNetto = warenkorbItem.ArtikelPreisSingleNetto,
                             
                         }).ToListAsync();
        }

        public async Task<WarenkorbItem> GetItem(int id)
        {
            return await(from warenkorb in this.shopDbContext.Warenkorb
                         join warenkorbItem in this.shopDbContext.WarenkorbItem
                         on warenkorb.Id equals warenkorbItem.WarenkorbId
                         where warenkorbItem.Id == id
                         select new WarenkorbItem
                         {
                             Id = warenkorbItem.Id,
                             ArtikelId = warenkorbItem.ArtikelId,
                             ArtikelMenge = warenkorbItem.ArtikelMenge,
                             WarenkorbId= warenkorbItem.WarenkorbId,
                             ArtikelName = warenkorbItem.ArtikelName,
                             ArtikelImage = warenkorbItem.ArtikelImage,
                             ArtikelBezeichnung = warenkorbItem.ArtikelBezeichnung,
                             ArtikelPreisSingleNetto = warenkorbItem.ArtikelPreisSingleNetto,
                             KategorielName= warenkorbItem.KategorielName,
                             ArtikelNummer=warenkorbItem.ArtikelNummer,
                         }).SingleOrDefaultAsync();
        }

        public async Task<WarenkorbItem> UpdateMenge(int id, WarenkorbMengeUpdateDto warenkorbMengeUpdateDto)
        {
            var item = await this.shopDbContext.WarenkorbItem.FindAsync(id);
            if(item!= null)
            {
                item.ArtikelMenge = warenkorbMengeUpdateDto.WarenkorbItemMenge;
                await this.shopDbContext.SaveChangesAsync();
                return item;
            }
            return null;
        }
    }
}
