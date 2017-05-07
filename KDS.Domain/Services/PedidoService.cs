using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Repositories;
using KDS.Domain.Interfaces.Services;
using KDS.Domain.Seedwork;
using KDS.Infraestructure.CrossCutting.Entities;
using System.Collections.Generic;

namespace KDS.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPedidoProductoRepository _pedidoProductoRepository;

        public PedidoService(IUnitOfWork unitOfWork,
                             IPedidoProductoRepository pedidoProductoRepository)
        {
            _unitOfWork = unitOfWork;
            _pedidoProductoRepository = pedidoProductoRepository;
        }

        public IEnumerable<PedidoProducto> ObtenerPedidosPaginado(int? codPtoPreparacion, ref Pagination paginacion)
        {
            return _pedidoProductoRepository.ObtenerPaginado(codPtoPreparacion, ref paginacion);
        }
    }
}
