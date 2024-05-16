using Metalcoin.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Interfaces.Repositories
{
    public interface ICuponsRepository:IRepository<Cupom>
    {
        Task<Cupom> BuscarCupomAtivos(int status);
        Task<Cupom>BuscarCupomIndisponiveis(int status);
    }
}
