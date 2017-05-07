using KDS.Domain.Entities;
using KDS.Infraestructure.CrossCutting.Entities;
using System.Collections.Generic;

namespace KDS.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        IEnumerable<PedidoProducto> ObtenerPedidosPaginado(int? codPtoPreparacion, ref Pagination paginacion);
    }
}
