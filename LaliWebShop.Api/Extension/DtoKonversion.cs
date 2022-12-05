using LaliWebShop.Api.Entities;
using LaliWebShop.Models.Dtos;

namespace LaliWebShop.Api.Extension
{
    public static  class DtoKonversion
    {
        public static IEnumerable<ArtikelDto> KonvertToDto(this IEnumerable<Artikel> artikels,
                                                           IEnumerable<Kategorie> kategories)
        {
            return(from artikel in artikels
                   join kategorie in kategories
                   on artikel.KategorieId equals kategorie.Id
                   select new ArtikelDto
                   {
                       Id = artikel.Id,
                       Name=artikel.Name,
                       Bezeichnung=artikel.Bezeichnung,
                       ImageURL=artikel.ImageURL,
                       PreisSingleNetto=artikel.PreisSingleNetto,
                       Menge = artikel.Menge,
                       KategorieId=artikel.KategorieId,
                       KategorieName=kategorie.Name,

                   }).ToList();

        }

        public static ArtikelDto KonvertToDto(this Artikel artikel,
                                                          Kategorie kategorie)
        {
            return new ArtikelDto
            {
                Id = artikel.Id,
                Name = artikel.Name,
                Bezeichnung = artikel.Bezeichnung,
                ImageURL = artikel.ImageURL,
                PreisSingleNetto = artikel.PreisSingleNetto,
                Menge = artikel.Menge,
                KategorieId = artikel.KategorieId,
                KategorieName = kategorie.Name
            };
        }

        public static IEnumerable<WarenkorbItemDto> KonvertToDto(this IEnumerable<WarenkorbItem> warenkorbItems,
                                                            IEnumerable<Artikel> artikels)
        {
            return (from warenkorbItem in warenkorbItems
                    join artikel in artikels
                    on warenkorbItem.ArtikelId equals artikel.Id
                    select new WarenkorbItemDto
                    {
                        Id = warenkorbItem.Id,
                        ArtikelId = warenkorbItem.ArtikelId,
                        KategorieName = artikel.KategorieName,
                        ArtikelNummer = artikel.Artikelnummer,
                        ArtikelName = artikel.Name,
                        ArtikelBezeichnung = artikel.Bezeichnung,
                        ArtikelImage = artikel.ImageURL,
                        ArtikelPreisSingleNetto = artikel.PreisSingleNetto,
                        WarenkorbId = warenkorbItem.WarenkorbId,
                        ArtikelMenge = warenkorbItem.ArtikelMenge,
                        Gesamtpreis = artikel.PreisSingleNetto * warenkorbItem.ArtikelMenge
                        
                        //Mwst=
                        //ArtikelPreisGesamtNetto = artikel.PreisSingleNetto + warenkorbItem.Mwst,
                        

                    }).ToList();

        }

        public static WarenkorbItemDto KonvertToDto(this WarenkorbItem warenkorbItem,
                                                            Artikel artikel)
        {
            return new WarenkorbItemDto
                    {
                        Id = warenkorbItem.Id,
                        ArtikelId = warenkorbItem.ArtikelId,
                        KategorieName = artikel.KategorieName,
                        ArtikelNummer = artikel.Artikelnummer,
                        ArtikelName = artikel.Name,
                        ArtikelBezeichnung = artikel.Bezeichnung,
                        ArtikelImage = artikel.ImageURL,
                        ArtikelPreisSingleNetto = artikel.PreisSingleNetto,
                        WarenkorbId = warenkorbItem.WarenkorbId,
                        ArtikelMenge = warenkorbItem.ArtikelMenge,
                        Gesamtpreis = artikel.PreisSingleNetto * warenkorbItem.ArtikelMenge
                        //Mwst=
                        //ArtikelPreisGesamtNetto = artikel.PreisSingleNetto + warenkorbItem.Mwst,


                    };


        }
    }
}
