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
    public class TiempoPreparacionController : BaseController
    {
        #region Members

        private readonly IGeneralService _generalService;
        private readonly ITiempoPreparacionService _tiempoPreparacionService;

        #endregion

        #region Constructor

        public TiempoPreparacionController(IGeneralService generalService,
                                           ITiempoPreparacionService tiempoPreparacionService)
        {
            _generalService = generalService;
            _tiempoPreparacionService = tiempoPreparacionService;
        }

        #endregion

        #region PtoPreparacionController Members

        // GET: Kitchen/TiempoPreparacion
        public ActionResult Index()
        {
            var model = new BandejaTiempoPreparacionViewModel();

            var unidadesNegocio = _generalService.ObtenerUnidadesNegocio();
            var ptosPreparacion = Enumerable.Empty<PtoPreparacion>();

            model.UnidadesNegocio = unidadesNegocio.ToSelectListItems();
            model.PtosPreparacion = ptosPreparacion.ToSelectListItems();

            return View(model);
        }

        // GET: Kitchen/TiempoPreparacion/ObtenerPuntosxUnidadNegocio
        public string ObtenerPuntosxUnidadNegocio(string codUnidadNegocio)
        {
            var ptosPreparacion = _tiempoPreparacionService.ObtenerPuntosxUnidadNegocio(codUnidadNegocio);
            var json = ptosPreparacion.ToSelectListItems();
            return JsonConvert.SerializeObject(json);
        }

        // GET: Kitchen/TiempoPreparacion/ObtenerProductosPaginado
        public string ObtenerProductosPaginado([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest request, string codUnidadNegocio, int? codPtoPreparacion)
        {
            var paginacion = request.ToPagination();
            var data = _tiempoPreparacionService.ObtenerProductosPaginado(codUnidadNegocio, codPtoPreparacion, ref paginacion);
            var cad = data.Select(x => new[]
                                       {
                                           //Campos visualizados
                                           string.Empty
                                           , x.DescProducto
                                           , x.TiempoPrepDirecto.ToString()
                                           , x.TiempoPrepSegundo.ToString()
                                           , x.MinCantidad.ToString()
                                           , x.MaxCantidad.ToString()
                                           , x.IndEnsamblado.ToString()
                                           //Campos ocultos
                                           , x.CodProductoPtoPrep.ToString()
                                       }).ToArray();
            return cad.ToResponse(paginacion);
        }

        // GET: Kitchen/TiempoPreparacion/ObtenerProductosAutocompletado
        public string ObtenerProductosAutocompletado(string codUnidadNegocio, string descProducto)
        {
            var lista = _tiempoPreparacionService.ObtenerProductosAutocompletado(codUnidadNegocio, descProducto);
            return JsonConvert.SerializeObject(lista.Select(x => new
            {
                Id = x.CodProducto,
                Name = x.DescProducto
            }));
        }

        // GET: Kitchen/TiempoPreparacion/Crear
        public ActionResult Crear()
        {
            var model = new ProductoPtoPrepViewModel();

            var unidadesNegocio = _generalService.ObtenerUnidadesNegocio();
            var ptosPreparacion = Enumerable.Empty<PtoPreparacion>();

            model.MinCantidad = 1;
            model.MaxCantidad = 4;
            model.UnidadesNegocio = unidadesNegocio.ToSelectListItems();
            model.PtosPreparacion = ptosPreparacion.ToSelectListItems();

            return View("_Crear", model);
        }

        // POST: Kitchen/TiempoPreparacion/Crear
        [HttpPost]        
        public string Crear(ProductoPtoPrepViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productoPtoPrep = Mapper.Map<ProductoPtoPrepViewModel, ProductoPtoPrep>(model);                
                var result = _tiempoPreparacionService.CrearProducto(productoPtoPrep);
                return JsonConvert.SerializeObject(result);
            }
            return JsonConvert.SerializeObject(new ValidationResult(TipoResultado.Error, Messages.Error));
        }

        // GET: Kitchen/TiempoPreparacion/Edit/5
        public ActionResult Editar(int id)
        {
            var productoPtoPrep = _tiempoPreparacionService.ObtenerProducto(id);            
            if (productoPtoPrep == null)
            {
                return HttpNotFound();
            }

            var unidadesNegocio = _generalService.ObtenerUnidadesNegocio();
            var ptosPreparacion = _tiempoPreparacionService.ObtenerPuntosxUnidadNegocio(productoPtoPrep.CodUnidadNegocio);

            var model = Mapper.Map<ProductoPtoPrep, ProductoPtoPrepViewModel>(productoPtoPrep);

            model.UnidadesNegocio = unidadesNegocio.ToSelectListItems(productoPtoPrep.CodUnidadNegocio);
            model.PtosPreparacion = ptosPreparacion.ToSelectListItems(productoPtoPrep.CodPtoPreparacion);

            return View("_Editar", model);
        }

        // POST: Kitchen/TiempoPreparacion/Edit/5
        [HttpPost]        
        public string Editar(ProductoPtoPrepViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productoPtoPrep = Mapper.Map<ProductoPtoPrepViewModel, ProductoPtoPrep>(model);                
                var result = _tiempoPreparacionService.ActualizarProducto(productoPtoPrep);
                return JsonConvert.SerializeObject(result);
            }
            return JsonConvert.SerializeObject(new ValidationResult(TipoResultado.Error, Messages.Error));
        }

        // POST: Kitchen/TiempoPreparacion/Eliminar/5
        [HttpPost]
        public string Eliminar(int id)
        {
            var result = _tiempoPreparacionService.EliminarProducto(id);
            return JsonConvert.SerializeObject(result);
        }

        #endregion
    }
}