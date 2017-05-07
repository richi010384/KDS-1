using KDS.Domain.Entities;
using KDS.Domain.Seedwork;
using KDS.Infraestructure.CrossCutting.Entities;
using System.Collections.Generic;

namespace KDS.Domain.Interfaces.Repositories
{
    public interface IProductoPtoPrepRepository : IRepository<ProductoPtoPrep>
    {
        IEnumerable<ProductoPtoPrep> ObtenerPaginado(string codUnidadNegocio, int? codPtoPreparacion, ref Pagination paginacion);
        ProductoPtoPrep Obtener(int? codProductoPtoPrep);
        void Crear(ProductoPtoPrep productoPtoPrep);
    }
}