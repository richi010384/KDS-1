using KDS.Domain.Entities;
using System.Collections.Generic;

namespace KDS.Domain.Interfaces.Services
{
    public interface IGeneralService
    {
        IEnumerable<UnidadNegocio> ObtenerUnidadesNegocio();

    }
}
