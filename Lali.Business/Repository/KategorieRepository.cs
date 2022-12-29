using AutoMapper;
using Lali.Business.Repository.Kontrakte;
using Lali.DataAccess.Data;
using Lali.DataAccess.Entities;
using LaliWebShop.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lali.Business.Repository
{
    public class KategorieRepository : IKategorieRepository
    {
        private readonly ShopDbContext dbContext;
        private readonly IMapper _mapper;

        public KategorieRepository(ShopDbContext shopDb,IMapper mapper)
        {
            dbContext = shopDb;
            _mapper = mapper;
        }
        public async Task <KategorieDto> Create(KategorieDto dto)
        {
            var obj = _mapper.Map<KategorieDto, Kategorie>(dto);
            obj.CreatedDate = DateTime.Now;
            var addDto= dbContext.Kategorie.Add(obj);
            await dbContext.SaveChangesAsync();

            return _mapper.Map<Kategorie, KategorieDto>(addDto.Entity);
        }

        public async Task <int> Delete(int id)
        {
            var obj = await dbContext.Kategorie.FirstOrDefaultAsync(a => a.Id == id);
            if (obj != null)
            {
                dbContext.Kategorie.Remove(obj);
                return await dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task <KategorieDto> Get(int id)
        {
            var obj = await  dbContext.Kategorie.FirstOrDefaultAsync(a => a.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Kategorie, KategorieDto>(obj); 
            }
            return new KategorieDto();
        }

        public async Task <IEnumerable<KategorieDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Kategorie>, IEnumerable<KategorieDto>>(dbContext.Kategorie);
        }

        public async Task <KategorieDto> Update(KategorieDto dto)
        {
            var objVonDb = await dbContext.Kategorie.FirstOrDefaultAsync(a => a.Id == dto.Id);
            if (objVonDb != null)
            {
                objVonDb.Name = dto.Name;
                dbContext.Kategorie.Update(objVonDb);
                dbContext.SaveChanges();
                return _mapper.Map<Kategorie, KategorieDto>(objVonDb);

            }
            return dto;
        }
    }
}
