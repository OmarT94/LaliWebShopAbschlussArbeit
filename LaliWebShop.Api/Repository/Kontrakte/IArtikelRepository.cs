using LaliWebShop.Api.Entities;

namespace LaliWebShop.Api.Repository.Kontrakte
{
    public interface IArtikelRepository
    {
        Task<IEnumerable<Artikel>> GetItems();
        Task<IEnumerable<Kategorie>> GetKategorien();
        Task <Artikel> GetItem(int id);
        Task <Kategorie> GetKategorie(int id);
    }
}
