using LaliWebShop.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lali.Business.Repository.Kontrakte
{
    public interface IKategorieRepository
    {
        public Task <KategorieDto> Create(KategorieDto dto);
        public Task <KategorieDto> Update(KategorieDto dto);
        public Task <int> Delete(int id);
        public Task <KategorieDto> Get(int id);
        public Task <IEnumerable<KategorieDto>> GetAll();



    }
}
