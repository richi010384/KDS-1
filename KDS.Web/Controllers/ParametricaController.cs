using KDS.Domain.Interfaces.Services;
using System.Web.Mvc;

namespace KDS.Web.Controllers
{
    public class ParametricaController : BaseController
    {
        #region Members

        private readonly IParametricaService _parametricaService;
        private readonly IPtoPreparacionService _ptoPreparacionService;

        #endregion

        #region Constructor

        public ParametricaController(IParametricaService parametricaService,
                                     IPtoPreparacionService ptoPreparacionService)
        {
            _parametricaService = parametricaService;
            _ptoPreparacionService = ptoPreparacionService;
        }

        #endregion

        #region ParametricaController Members

        // GET: Kitchen/Parametrica/


        #endregion
    }
}