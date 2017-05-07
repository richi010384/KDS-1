using KDS.Domain.Entities;
using KDS.Domain.Seedwork;
using System.Collections.Generic;

namespace KDS.Domain.Interfaces.Repositories
{
    public interface IUnidadNegocioRepository : IRepository<UnidadNegocio>
    {
        IEnumerable<UnidadNegocio> Listar();
    }
}