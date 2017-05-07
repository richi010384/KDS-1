using KDS.Domain.Entities;
using KDS.Infraestructure.CrossCutting.Entities;
using System.Collections.Generic;

namespace KDS.Domain.Interfaces.Services
{
    public interface IPtoPreparacionService : IServiceBase<PtoPreparacion>
    {
        IEnumerable<PtoPreparacion> ObtenerPaginado(string codUnidadNegocio, ref Pagination paginacion);
        ValidationResult CrearPunto(PtoPreparacion ptoPreparacion);
        ValidationResult ActualizarPunto(PtoPreparacion ptoPreparacion);
        ValidationResult EliminarPunto(object id);
    }
}
