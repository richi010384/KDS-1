using KDS.Domain.Entities;
using KDS.Domain.Seedwork;
using KDS.Infraestructure.CrossCutting.Entities;
using System.Collections.Generic;

namespace KDS.Domain.Interfaces.Repositories
{
    public interface IPtoPreparacionRepository : IRepository<PtoPreparacion>
    {
        IEnumerable<PtoPreparacion> ObtenerPaginado(string codUnidadNegocio, ref Pagination paginacion);
        void Crear(PtoPreparacion ptoPreparacion);
        IEnumerable<PtoPreparacion> ObtenerxUnidadNegocio(string codUnidadNegocio);
    }
}