using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.Shared
{
    public interface IRepository<TRequest, TResponse>
    {
        TResponse AddAsync(TRequest request);
    }
}
