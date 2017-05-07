using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Repositories;
using KDS.Domain.Interfaces.Services;
using KDS.Domain.Seedwork;
using System.Collections.Generic;

namespace KDS.Domain.Services
{
    public class GeneralService : IGeneralService
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnidadNegocioRepository _unidadNegocioRepository;

        #endregion

        #region Constructor

        public GeneralService(IUnitOfWork unitOfWork,
                              IUnidadNegocioRepository unidadNegocioRepository)
        {
            _unitOfWork = unitOfWork;
            _unidadNegocioRepository = unidadNegocioRepository;
        }

        #endregion

        #region GeneralService Members

        public IEnumerable<UnidadNegocio> ObtenerUnidadesNegocio()
        {
            return _unidadNegocioRepository.Listar();
        }

        #endregion
    }
}