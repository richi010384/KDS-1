using KDS.Application.Interfaces;
using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Repositories;
using KDS.Domain.Interfaces.Services;
using KDS.Domain.Seedwork;

namespace KDS.Application.Services
{
    public class ProductoAppService : AppServiceBase<Producto>, IProductoAppService
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductoRepository _productoRepository;
        private readonly IProductoService _productoService;

        #endregion

        #region Constructors

        public ProductoAppService(IUnitOfWork unitOfWork,
                                  IProductoRepository productoRepository,
                                  IProductoService productoService)
            : base(productoService)
        {
            _unitOfWork = unitOfWork;
            _productoRepository = productoRepository;
            _productoService = productoService;
        }

        #endregion

        #region ProductoAppService Members
        #endregion
    }
}
