using AutoMapper;
using Lali.Business.Repository.Kontrakte;
using Lali.Common;
using Lali.DataAccess.Data;
using Lali.DataAccess.Entities;
using Lali.DataAccess.ViewModel;
using LaliWebShop.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lali.Business.Repository
{
    public class BestellungRepository : IBestellungRepository
    {
        private readonly ShopDbContext _shopDbContext;
        private readonly IMapper _mapper;
        public BestellungRepository( ShopDbContext shopDbContext, IMapper mapper)
        {
            this._shopDbContext = shopDbContext;
            this._mapper = mapper;
        }
        public async Task<BestellungPosDto> Add(BestellungPosDto bestellungPosDto)
        {
            try
            {
                var obj = _mapper.Map<BestellungPosDto, BestellungPos>(bestellungPosDto);
                _shopDbContext.Bestellung.Add(obj.Bestellung);
                await _shopDbContext.SaveChangesAsync();

                foreach (var items in obj.BestellungItems)
                {
                    items.BestellungId = obj.Bestellung.Id;
                    
                }

                _shopDbContext.BestellungItems.AddRange(obj.BestellungItems);
                await _shopDbContext.SaveChangesAsync();

                return new BestellungPosDto()
                {
                    Bestellung = _mapper.Map<Bestellung, BestellungDto>(obj.Bestellung),
                    BestellungItems = _mapper.Map<IEnumerable<BestellungItem>, IEnumerable<BestellungItemDto>>(obj.BestellungItems).ToList()

                };

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return bestellungPosDto;
        }

        public async Task<BestellungDto> BezahlungErfolgreich(int id)
        {
            var data = await _shopDbContext.Bestellung.FindAsync(id);
            if (data == null)
            {
                return new BestellungDto();
            }
            if (data.Status == SD.Status_Bevorstehend)
            {
                data.Status = SD.Status_Bestaetigt;
                await _shopDbContext.SaveChangesAsync();
                return _mapper.Map<Bestellung, BestellungDto>(data);
            }
            return new BestellungDto();
        }

        public async Task<int> Delete(int id)
        {
            var objBestellung = await _shopDbContext.Bestellung.FirstOrDefaultAsync(u => u.Id == id);
            if (objBestellung != null)
            {
                IEnumerable<BestellungItem> bestellungItems = _shopDbContext.BestellungItems.Where(u => u.BestellungId == id);

                _shopDbContext.BestellungItems.RemoveRange(bestellungItems);
                _shopDbContext.Bestellung.Remove(objBestellung);
                return _shopDbContext.SaveChanges();
            }
            return 0;
        }

        public async Task<BestellungPosDto> Get(int id)
        {
            BestellungPos bestellung = new()
            {
                Bestellung = _shopDbContext.Bestellung.FirstOrDefault(u => u.Id == id),
                BestellungItems = _shopDbContext.BestellungItems.Where(u => u.BestellungId == id),
            };
            if (bestellung != null)
            {
                return _mapper.Map<BestellungPos, BestellungPosDto>(bestellung);
            }
            return new BestellungPosDto();
        }

        public async Task<IEnumerable<BestellungPosDto>> GetAll(string? benutzerId = null, string? status = null)
        {
            List<BestellungPos>bestellungFromDb = new List<BestellungPos>();
            IEnumerable<Bestellung> bestellungList = _shopDbContext.Bestellung;
            IEnumerable<BestellungItem> bestellungsItemsList = _shopDbContext.BestellungItems;

            foreach (Bestellung bestellung in bestellungList)
            {
                BestellungPos order = new()
                {
                    Bestellung = bestellung,
                    BestellungItems = bestellungsItemsList.Where(u => u.BestellungId == bestellung.Id),
                };
                bestellungFromDb.Add(order);
            }

            return _mapper.Map<IEnumerable<BestellungPos>, IEnumerable<BestellungPosDto>>(bestellungFromDb);
        }

        public async Task<BestellungDto> Update(BestellungDto bestellungDto)
        {
            if (bestellungDto != null)
            {
                var Bestellung = _mapper.Map<BestellungDto, Bestellung>(bestellungDto);
                _shopDbContext.Bestellung.Update(Bestellung);

                //var bestellungFromDb = _shopDbContext.Bestellung.FirstOrDefault(u => u.Id == bestellungDto.Id);
                //bestellungFromDb.Anrede = bestellungDto.Anrede;
                //bestellungFromDb.Name = bestellungDto.Name;
                //bestellungFromDb.Vorname = bestellungDto.Vorname;
                //bestellungFromDb.HandyNummer = bestellungDto.HandyNummer;
                //bestellungFromDb.Strasse = bestellungDto.Strasse;
                //bestellungFromDb.Hausnummer = bestellungDto.Hausnummer;
                //bestellungFromDb.Ort = bestellungDto.Ort;
                //bestellungFromDb.Plz = bestellungDto.Plz;
                //bestellungFromDb.Land = bestellungDto.Land;
                //bestellungFromDb.Status = bestellungDto.Status;
                await _shopDbContext.SaveChangesAsync();
                return _mapper.Map<Bestellung, BestellungDto>(Bestellung);
            }
            return new BestellungDto();
        }

        public async Task<bool> UpdateBestellungStatus(int bestellungId, string status)
        {
            var data = await _shopDbContext.Bestellung.FindAsync(bestellungId);
            if (data == null)
            {
                return false;
            }
          
            data.Status = status;
            await _shopDbContext.SaveChangesAsync();
            return true;
            
        
        }
    }
}
