using KDS.Domain.Entities;
using KDS.Infraestructure.CrossCutting.Entities;
using System.Collections.Generic;

namespace KDS.Domain.Interfaces.Services
{
    public interface ITiempoPreparacionService
    {
        IEnumerable<ProductoPtoPrep> ObtenerProductosPaginado(string codUnidadNegocio, int? codPtoPreparacion, ref Pagination paginacion);
        IEnumerable<PtoPreparacion> ObtenerPuntosxUnidadNegocio(string codUnidadNegocio);
        IEnumerable<Producto> ObtenerProductosAutocompletado(string codUnidadNegocio, string descProducto);        
        ProductoPtoPrep ObtenerProducto(int? codProductoPtoPrep);
        ValidationResult CrearProducto(ProductoPtoPrep productoPtoPrep);
        ValidationResult ActualizarProducto(ProductoPtoPrep productoPtoPrep);
        ValidationResult EliminarProducto(object id);
    }
}
