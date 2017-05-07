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
    public class PtoPreparacionService : ServiceBase<PtoPreparacion>, IPtoPreparacionService
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IPtoPreparacionRepository _ptoPreparacionRepository;

        #endregion

        #region Constructor

        public PtoPreparacionService(IUnitOfWork unitOfWork,
                                     IPtoPreparacionRepository ptoPreparacionRepository)
            : base(ptoPreparacionRepository)
        {
            _unitOfWork = unitOfWork;
            _ptoPreparacionRepository = ptoPreparacionRepository;
        }

        #endregion

        #region PtoPreparacionService Members

        public IEnumerable<PtoPreparacion> ObtenerPaginado(string codUnidadNegocio, ref Pagination paginacion)
        {
            return _ptoPreparacionRepository.ObtenerPaginado(codUnidadNegocio, ref paginacion);
        }

        public ValidationResult CrearPunto(PtoPreparacion ptoPreparacion)
        {
            using (_unitOfWork)
            {
                try
                {
                    ptoPreparacion.UsuarioCreacion = AppContext.Sesion.UserName;
                    _ptoPreparacionRepository.Crear(ptoPreparacion);
                    _unitOfWork.Commit();
                    return new ValidationResult(TipoResultado.Success);
                }
                catch
                {
                    return new ValidationResult(TipoResultado.Error);
                }
            }
        }

        public ValidationResult ActualizarPunto(PtoPreparacion ptoPreparacion)
        {
            using (_unitOfWork)
            {
                try
                {
                    var ptoPreparacionBd = _ptoPreparacionRepository.GetById(ptoPreparacion.CodPtoPreparacion);
                    ptoPreparacionBd.CodUnidadNegocio = ptoPreparacion.CodUnidadNegocio;
                    ptoPreparacionBd.Nombre = ptoPreparacion.Nombre;
                    ptoPreparacionBd.Descripcion = ptoPreparacion.Descripcion;
                    Update(ptoPreparacionBd);
                    _unitOfWork.Commit();
                    return new ValidationResult(TipoResultado.Success);
                }                
                catch
                {
                    return new ValidationResult(TipoResultado.Error);
                }
            }
        }

        public ValidationResult EliminarPunto(object id)
        {
            using (_unitOfWork)
            {
                try
                {
                    Delete(id);
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
