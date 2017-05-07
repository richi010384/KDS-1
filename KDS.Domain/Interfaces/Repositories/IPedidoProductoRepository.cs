using KDS.Domain.Entities;
using KDS.Domain.Seedwork;
using KDS.Infraestructure.CrossCutting.Entities;
using System.Collections.Generic;

namespace KDS.Domain.Interfaces.Repositories
{
    public interface IPedidoProductoRepository : IRepository<PedidoProducto>
    {
        IEnumerable<PedidoProducto> ObtenerPaginado(int? codPtoPreparacion, ref Pagination paginacion);
    }
}