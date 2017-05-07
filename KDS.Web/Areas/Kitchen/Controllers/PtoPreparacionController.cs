using AutoMapper;
using DataTables.Mvc;
using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Services;
using KDS.Infraestructure.CrossCutting.Entities;
using KDS.Infraestructure.CrossCutting.Enums;
using KDS.Presentation.Seedwork.Extensions;
using KDS.Presentation.Seedwork.Resources;
using KDS.Web.Areas.Kitchen.Models;
using KDS.Web.Controllers;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;

namespace KDS.Web.Areas.Kitchen.Controllers
{
    public class PtoPreparacionController : BaseController
    {
        #region Members

        private readonly IGeneralService _generalService;
        private readonly IPtoPreparacionService _ptoPreparacionService;

        #endregion

        #region Constructor

        public PtoPreparacionController(IGeneralService generalService,
                                        IPtoPreparacionService ptoPreparacionService)
        {
            _generalService = generalService;
            _ptoPreparacionService = ptoPreparacionService;
        }

        #endregion

        #region PtoPreparacionController Members

        // GET: Kitchen/PtoPreparacion
        public ActionResult Index()
        {
            var model = new BandejaPtoPreparacionViewModel();

            var unidadesNegocio = _generalService.ObtenerUnidadesNegocio();
            model.UnidadesNegocio = unidadesNegocio.ToSelectListItems();

            return View(model);
        }

        // GET: Kitchen/PtoPreparacion/ObtenerPuntosPaginadoxUnidadNegocio
        public string ObtenerPaginado([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest request, string codUnidadNegocio)
        {
            var paginacion = request.ToPagination();
            var data = _ptoPreparacionService.ObtenerPaginado(codUnidadNegocio, ref paginacion);
            var cad = data.Select(x => new[]
                                       {
                                           //Campos visualizados
                                           string.Empty
                                           , x.NombreUnidadNegocio
                                           , x.Nombre
                                           , x.Descripcion
                                           //Campos ocultos
                                           , x.CodPtoPreparacion.ToString()
                                       }).ToArray();
            return cad.ToResponse(paginacion);
        }

        // GET: Kitchen/PtoPreparacion/Crear
        public ActionResult Crear()
        {
            var model = new PtoPreparacionViewModel();

            var unidadesNegocio = _generalService.ObtenerUnidadesNegocio();
            model.UnidadesNegocio = unidadesNegocio.ToSelectListItems();

            return View("_Crear", model);
        }

        // POST: Kitchen/PtoPreparacion/Crear
        [HttpPost]        
        public string Crear(PtoPreparacionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ptoPreparacion = Mapper.Map<PtoPreparacionViewModel, PtoPreparacion>(model);                
                var result = _ptoPreparacionService.CrearPunto(ptoPreparacion);
                return JsonConvert.SerializeObject(result);
            }
            return JsonConvert.SerializeObject(new ValidationResult(TipoResultado.Error, Messages.Error));
        }

        // GET: Kitchen/PtoPreparacion/Edit/5
        public ActionResult Editar(int id)
        {
            var ptoPreparacion = _ptoPreparacionService.GetById(id);            
            if (ptoPreparacion == null)
            {
                return HttpNotFound();
            }

            var unidadesNegocio = _generalService.ObtenerUnidadesNegocio();
            var model = Mapper.Map<PtoPreparacion, PtoPreparacionViewModel>(ptoPreparacion);
            model.UnidadesNegocio = unidadesNegocio.ToSelectListItems(ptoPreparacion.CodUnidadNegocio);            
            return View("_Editar", model);
        }

        // POST: Kitchen/PtoPreparacion/Edit/5
        [HttpPost]        
        public string Editar(PtoPreparacionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ptoPreparacion = Mapper.Map<PtoPreparacionViewModel, PtoPreparacion>(model);                
                var result = _ptoPreparacionService.ActualizarPunto(ptoPreparacion);
                return JsonConvert.SerializeObject(result);
            }
            return JsonConvert.SerializeObject(new ValidationResult(TipoResultado.Error, Messages.Error));
        }

        // POST: Kitchen/PtoPreparacion/Eliminar/5
        [HttpPost]
        public string Eliminar(int id)
        {
            var result = _ptoPreparacionService.EliminarPunto(id);
            return JsonConvert.SerializeObject(result);
        }

        // GET: Kitchen/PtoPreparacion/Pedido
        public ActionResult Pedido()
        {
            return View();
        }

        #endregion
    }
}