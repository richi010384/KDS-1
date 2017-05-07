using KDS.Domain.Entities;
using KDS.Domain.Seedwork;
using System.Collections.Generic;

namespace KDS.Domain.Interfaces.Repositories
{
    public interface IParametricaRepository : IRepository<Parametrica>
    {
        IEnumerable<Parametrica> ObtenerxTipoParametrica(int? codTipoParametrica);
    }
}