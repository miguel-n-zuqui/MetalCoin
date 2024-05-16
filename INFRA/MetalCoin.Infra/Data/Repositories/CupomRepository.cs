using Metalcoin.Core.Domain;
using Metalcoin.Core.Enums;
using Metalcoin.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCoin.Infra.Data.Repositories
{
    public class CupomRepository: Repository<Cupom>,ICuponsRepository
    {
        public CupomRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<Cupom> BuscarCupomAtivos(TipoStatusCupom status)
        {
            var resultado = await DbSet.Where(c => c.statusCupom == status).FirstOrDefaultAsync();
            return resultado;
        }

        public Task<Cupom> BuscarCupomIndisponiveis(TipoStatusCupom status)
        {
            throw new NotImplementedException();
        }
    }
}
