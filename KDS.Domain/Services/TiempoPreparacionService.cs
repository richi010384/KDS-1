using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Repositories;
using KDS.Domain.Interfaces.Services;
using KDS.Domain.Seedwork;
using KDS.Infraestructure.CrossCutting.Entities;
using KDS.Infraestructure.CrossCutting.Enums;
using KDS.Infraestructure.CrossCutting.Helpers;
using System.Collections.Generic;

namespace KDS.Domain.Services
{
    public class TiempoPreparacionService : ITiempoPreparacionService
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductoRepository _productoRepository;
        private readonly IProductoPtoPrepRepository _productoPtoPrepRepository;
        private readonly IPtoPreparacionRepository _ptoPreparacionRepository;

        #endregion

        #region Constructor

        public TiempoPreparacionService(IUnitOfWork unitOfWork,
                                        IProductoRepository productoRepository,
                                        IProductoPtoPrepRepository productoPtoPrepRepository,
                                        IPtoPreparacionRepository ptoPreparacionRepository)
        {
            _unitOfWork = unitOfWork;
            _productoRepository = productoRepository;
            _productoPtoPrepRepository = productoPtoPrepRepository;
            _ptoPreparacionRepository = ptoPreparacionRepository;
        }

        #endregion

        #region TiempoPreparacionService Members

        public IEnumerable<PtoPreparacion> ObtenerPuntosxUnidadNegocio(string codUnidadNegocio)
        {
            return _ptoPreparacionRepository.ObtenerxUnidadNegocio(codUnidadNegocio);
        }

        public IEnumerable<Producto> ObtenerProductosAutocompletado(string codUnidadNegocio, string descProducto)
        {
            return _productoRepository.ObtenerAutocompletado(codUnidadNegocio, descProducto);
        }

        public IEnumerable<ProductoPtoPrep> ObtenerProductosPaginado(string codUnidadNegocio, int? codPtoPreparacion, ref Pagination paginacion)
        {
            return _productoPtoPrepRepository.ObtenerPaginado(codUnidadNegocio, codPtoPreparacion, ref paginacion);
        }

        public ProductoPtoPrep ObtenerProducto(int? codProductoPtoPrep)
        {
            return _productoPtoPrepRepository.Obtener(codProductoPtoPrep);
        }

        public ValidationResult CrearProducto(ProductoPtoPrep productoPtoPrep)
        {
            using (_unitOfWork)
            {
                try
                {
                    productoPtoPrep.UsuarioCreacion = AppContext.Sesion.UserName;
                    _productoPtoPrepRepository.Crear(productoPtoPrep);
                    _unitOfWork.Commit();
                    return new ValidationResult(TipoResultado.Success);
                }
                catch
                {
                    return new ValidationResult(TipoResultado.Error);
                }
            }
        }

        public ValidationResult ActualizarProducto(ProductoPtoPrep productoPtoPrep)
        {
            using (_unitOfWork)
            {
                try
                {
                    var productoPtoPrepBd = _productoPtoPrepRepository.GetById(productoPtoPrep.CodProductoPtoPrep);
                    productoPtoPrepBd.CodPtoPreparacion = productoPtoPrep.CodPtoPreparacion;
                    productoPtoPrepBd.CodProducto = productoPtoPrep.CodProducto;
                    productoPtoPrepBd.IndEnsamblado = productoPtoPrep.IndEnsamblado;
                    productoPtoPrepBd.TiempoPrepDirecto = productoPtoPrep.TiempoPrepDirecto;
                    productoPtoPrepBd.TiempoPrepSegundo = productoPtoPrep.TiempoPrepSegundo;
                    productoPtoPrepBd.MinCantidad = productoPtoPrep.MinCantidad;
                    productoPtoPrepBd.MaxCantidad = productoPtoPrep.MaxCantidad;
                    _productoPtoPrepRepository.Update(productoPtoPrepBd);
                    _unitOfWork.Commit();
                    return new ValidationResult(TipoResultado.Success);
                }
                catch
                {
                    return new ValidationResult(TipoResultado.Error);
                }
            }
        }

        public ValidationResult EliminarProducto(object id)
        {
            using (_unitOfWork)
            {
                try
                {
                    _productoPtoPrepRepository.Delete(id);
                    _unitOfWork.Commit();
                    return new ValidationResult(TipoResultado.Success);
                }
                catch
                {
                    return new ValidationResult(TipoResultado.Error);
                }
            }
        }

        #endregion
    }
}