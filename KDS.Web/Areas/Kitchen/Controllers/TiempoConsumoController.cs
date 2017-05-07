//<!-- Autor: RICARDO G. MARTIN BEUERMANN -->

using AutoMapper;
using DataTables.Mvc;
using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Services;
using KDS.Infraestructure.CrossCutting.Entities;
using KDS.Infraestructure.CrossCutting.Enums;
using KDS.Presentation.Seedwork.Extensions;
using KDS.Presentation.Seedwork.Resources;
using KDS.Web.Areas.Kitchen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KDS.Web.Areas.Kitchen.Controllers
{
    public class TiempoConsumoController : Controller
    {
        #region Members

        private readonly ITiempoConsumoService _tconsumoService;

        #endregion

        #region Constructor

        public TiempoConsumoController(ITiempoConsumoService tconsumoService)
        {
            _tconsumoService = tconsumoService;
        }

        #endregion

        #region ProductoController Members

        // GET: Kitchen/TiempoConsumo
        public ActionResult Index()
        {
            var model = new BandejaTiempoConsumoViewModel();

            var subgrupo_grupos = _tconsumoService.ListarGrupos();
            model.SubGrupo_ItemsGrupos = subgrupo_grupos.ToSelectListItems();

            var producto_grupos = _tconsumoService.ListarGrupos();
            model.Producto_ItemsGrupos = producto_grupos.ToSelectListItems();

            var producto_subgrupos = _tconsumoService.ListarSubGrupos("");
            model.Producto_ItemsSubGrupos = producto_subgrupos.ToSelectListItems();

            return View(model);
        }

        // GET: Kitchen/TiempoConsumo/TiempoConsumoPorGrupos
        public string TiempoConsumoPorGrupos([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest request)
        {
            var paginacion = request.ToPagination();
            var data = _tconsumoService.ListarMaestroGrupo(string.Empty, ref paginacion);
            var cad = data.Select(x => new[]
                                       {
                                           //Campos visualizados
                                           string.Empty
                                           , x.CodGrupo
                                           , x.DescGrupo
                                           , string.Empty
                                           //Campos no visualizados
                                       }).ToArray();
            return cad.ToResponse(paginacion);
        }

        // GET: Kitchen/TiempoConsumo/TiempoConsumoPorSubGrupos
        public string TiempoConsumoPorSubGrupos([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest request, string CodGrupo)
        {
            var paginacion = request.ToPagination();
            var data = _tconsumoService.ListarMaestroSubGrupo(string.Empty, CodGrupo, ref paginacion);
            var cad = data.Select(x => new[]
                                       {
                                           //Campos visualizados
                                           string.Empty
                                           , x.CodSubGrupo
                                           , x.DescSubGrupo
                                           , x.DescGrupo
                                           , string.Empty
                                           //Campos no visualizados
                                       }).ToArray();
            return cad.ToResponse(paginacion);
        }

        // GET: Kitchen/TiempoConsumo/TiempoConsumoPorProductos
        public string TiempoConsumoPorProductos([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest request, string CodGrupo, string CodSubGrupo, string DescProducto)
        {
            var paginacion = request.ToPagination();
            var data = _tconsumoService.ListarMaestroProducto(CodGrupo, CodSubGrupo, "", DescProducto, ref paginacion);
            var cad = data.Select(x => new[]
                                       {
                                           //Campos visualizados
                                           string.Empty
                                           , x.CodProducto
                                           , x.DescProducto
                                           , x.DescSubGrupo
                                           , x.DescGrupo
                                           , string.Empty
                                           //Campos no visualizados
                                       }).ToArray();
            return cad.ToResponse(paginacion);
        }

        // GET: Kitchen/TiempoConsumo/SubGrupoListar
        public string SubGruposListar(string CodGrupo)
        {
            var subgrupos = _tconsumoService.ListarSubGrupos(CodGrupo);
            var items = subgrupos.ToSelectListItems();
            var resp = items.ToString();
            resp = SelectListExtensions.ToResponse(items);
            return resp;
        }

        // GET: Kitchen/TiempoConsumo/TiempoConsumoPorProductos
        public string TiempoConsumoPorModalidad([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest request, string Nivel, string CodGrupo, string CodSubGrupo, string CodProducto, string CodPropiedad, int Cantidad)
        {
            Pagination paginacion = new Pagination();
            if (request.Length == -1)
            {
                paginacion.StartIndex = 1;
                paginacion.EndIndex = 100;
            }
            else {
                paginacion = request.ToPagination();
            }
            IEnumerable<TiempoConsumo> data = null;
            switch (Nivel)
            {
                case "GR":
                    data = _tconsumoService.ListarPorGrupos(CodGrupo, CodPropiedad, Cantidad, ref paginacion);
                    break;
                case "SG":
                    data = _tconsumoService.ListarPorSubGrupos(CodSubGrupo, CodGrupo, CodPropiedad, Cantidad, ref paginacion);
                    break;
                case "PR":
                    data = _tconsumoService.ListarPorProductos(CodGrupo, CodSubGrupo, CodProducto, "", CodPropiedad, Cantidad, ref paginacion);
                    break;
            }
            var cad = data.Select(x => new[]
                                            {
                                           //Campos visualizados
                                           x.CodTiempoConsumo.ToString()
                                           , x.Cantidad.ToString()
                                           , x.MinComensales.ToString()
                                           , x.MaxComensales.ToString()
                                           , x.Tiempo.ToString()
                                           , string.Empty
                                           //Campos no visualizados
                                       }).ToArray();
            return cad.ToResponse(paginacion);
        }

        // POST: Kitchen/ProductoTiempo/Guardar
        public ActionResult Guardar(string Codigo, string nivel)
        {
            try
            {
                var model = new TiempoConsumoViewModel();
                model.Nivel = nivel;
                model.CodGrupo = string.Empty;
                model.CodSubGrupo = string.Empty;
                model.CodProducto = string.Empty;

                switch (nivel)
                {
                    case "GR":
                        var grupo = _tconsumoService.ListarGrupos().Where(x => x.CodGrupo == Codigo).First();
                        model.CodGrupo = grupo.CodGrupo;
                        model.DescGrupo = grupo.Desripcion;
                        break;
                    case "SG":
                        var subgrupo = _tconsumoService.ListarSubGrupos("").Where(x => x.CodSubGrupo == Codigo).First();
                        model.CodSubGrupo = subgrupo.CodSubGrupo;
                        model.DescSubGrupo = subgrupo.Nombre;
                        grupo = _tconsumoService.ListarGrupos().Where(x => x.CodGrupo == subgrupo.CodGrupo).First();
                        model.CodGrupo = grupo.CodGrupo;
                        model.DescGrupo = grupo.Desripcion;
                        break;
                    case "PR":
                        var paginacion = new Pagination();
                        paginacion.StartIndex = 0;
                        paginacion.EndIndex = 5;
                        paginacion.SortColumn = "DescProducto";
                        paginacion.SortOrder = "ASC";
                        var producto = _tconsumoService.ListarPorProductos("", "", Codigo, "", "", 0, ref paginacion).First();
                        model.CodGrupo = producto.CodGrupo;
                        model.DescGrupo = producto.DescGrupo;
                        model.CodSubGrupo = producto.CodSubGrupo;
                        model.DescSubGrupo = producto.DescSubGrupo;
                        model.CodProducto = producto.CodProducto;
                        model.DescProducto = producto.DescProducto;
                        break;
                    default:
                        model = null;
                        break;
                }

                var cantplatos = _tconsumoService.ListarParametros(2);
                model.LstCantidad = cantplatos.ToSelectListItems_Nombre();

                var modosconsumo = _tconsumoService.ListarParametros(1);
                model.LstModoConsumo = modosconsumo.ToSelectListItems_Nombre();

                var filtro_cantplatos = _tconsumoService.ListarParametros(2);
                model.Filtro_LstCantidad = filtro_cantplatos.ToSelectListItems_Nombre();

                var filtro_modosconsumo = _tconsumoService.ListarParametros(1).Where(x => x.Nombre != "I"); 
                model.Filtro_LstModoConsumo = filtro_modosconsumo.ToSelectListItems_Nombre();

                return View(model);
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        // POST: Kitchen/ProductoTiempo/Guardar
        [HttpPost]
        public string Guardar(TiempoConsumoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tiempoconsumo = Mapper.Map<TiempoConsumoViewModel, TiempoConsumo>(model);
                var result = _tconsumoService.Guardar(tiempoconsumo);
                return JsonConvert.SerializeObject(result);
            }
            return JsonConvert.SerializeObject(new ValidationResult(TipoResultado.Error, Messages.Error));
        }

        // POST: Kitchen/ProductoTiempo/Eliminar/5
        [HttpPost]
        public string Eliminar(int id)
        {
            var result = _tconsumoService.Eliminar(id);
            return JsonConvert.SerializeObject(result);
        }

        // POST: Kitchen/ProductoTiempo/Editar/5
        [HttpPost]
        public string Editar(int id, int tiempo)
        {                        
            var obj = _tconsumoService.GetById(id);
            obj.Tiempo = tiempo;
            var result = _tconsumoService.Guardar(obj);
            return JsonConvert.SerializeObject(result);
        }

        #endregion
    }
}