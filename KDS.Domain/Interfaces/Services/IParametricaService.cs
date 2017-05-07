using KDS.Domain.Entities;
using System.Collections.Generic;

namespace KDS.Domain.Interfaces.Services
{
    public interface IParametricaService : IServiceBase<Parametrica>
    {
        IEnumerable<Parametrica> ObtenerxTipoParametrica(int? codTipoParametrica);
    }
}
