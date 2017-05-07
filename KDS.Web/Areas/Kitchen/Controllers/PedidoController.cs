using DataTables.Mvc;
using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Services;
using KDS.Infraestructure.CrossCutting.Entities;
using KDS.Presentation.Seedwork.Extensions;
using KDS.Web.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace KDS.Web.Areas.Kitchen.Controllers
{
    public class PedidoController : BaseController
    {
        #region Members

        private readonly IPedidoService _pedidoService;

        #endregion

        #region Constructor

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        #endregion

        #region PedidoController Members

        // GET: Kitchen/Pedido
        public ActionResult Index()
        {
            return View();
        }

        // GET: Kitchen/Pedido/ObtenerPedidosPaginado
        public string ObtenerPedidosPaginado([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest request)
        {
            var codPtoPreparacion = 1;

            var paginacion = request.ToPagination();
            var data = _pedidoService.ObtenerPedidosPaginado(codPtoPreparacion, ref paginacion);
            var cad = data.Select(x => new[]
                                       {
                                           //Campos visualizados
                                           x.Mesa
                                           , x.PasoServicio.ToString()
                                           , x.Cantidad.ToString()
                                           , x.ImagenProducto.ToImageBase64()
                                           , x.ImagenOperador.ToImageBase64()
                                           , x.ImagenPropiedad.ToImageBase64()
                                           , x.Producto
                                           , x.Observaciones
                                           , x.HoraSalida.ToShortTimeString()
                                           //Campos ocultos
                                           , x.CodPedido
            }).ToArray();
            return cad.ToResponse(paginacion);
        }

        // GET: Kitchen/Pedido/Pedido
        public ActionResult Pedido()
        {
            return View();
        }

        #endregion
    }
}