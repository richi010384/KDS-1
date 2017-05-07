using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Repositories;
using KDS.Domain.Interfaces.Services;
using KDS.Domain.Seedwork;
using System.Collections.Generic;

namespace KDS.Domain.Services
{
    public class ParametricaService : ServiceBase<Parametrica>, IParametricaService
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IParametricaRepository _parametricaRepository;

        #endregion

        #region Constructor

        public ParametricaService(IUnitOfWork unitOfWork,
                                  IParametricaRepository parametricaRepository)
            : base(parametricaRepository)
        {
            _unitOfWork = unitOfWork;
            _parametricaRepository = parametricaRepository;
        }

        #endregion

        #region ParametricaService Members

        public IEnumerable<Parametrica> ObtenerxTipoParametrica(int? codTipoParametrica)
        {
            return _parametricaRepository.ObtenerxTipoParametrica(codTipoParametrica);
        }

        #endregion
    }
}