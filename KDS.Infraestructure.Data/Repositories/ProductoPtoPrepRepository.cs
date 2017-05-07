using AutoMapper;
using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Repositories;
using KDS.Infraestructure.CrossCutting.Entities;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace KDS.Infraestructure.Data.Repositories
{
    public class ProductoPtoPrepRepository
        : Repository<ProductoPtoPrep, Entities.ProductoPtoPrep>, IProductoPtoPrepRepository
    {
        #region Constructor

        public ProductoPtoPrepRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        #endregion

        #region ProductRepository Members

        public IEnumerable<ProductoPtoPrep> ObtenerPaginado(string codUnidadNegocio, int? codPtoPreparacion, ref Pagination paginacion)
        {
            var totalDisplayRecords = new ObjectParameter("p_TotalDisplayRecords", typeof(int));
            var totalRecords = new ObjectParameter("p_TotalRecords", typeof(int));
            var list = this.DataContext.sp_get_pag_productoptoprep(
                codUnidadNegocio,
                codPtoPreparacion,
                paginacion.StartIndex,
                paginacion.EndIndex,
                paginacion.SortColumn,
                paginacion.SortOrder,
                totalDisplayRecords,
                totalRecords
            ).ToList();
            paginacion.TotalDisplayRecords = (int)totalDisplayRecords.Value;
            paginacion.TotalRecords = (int)totalRecords.Value;
            return Mapper.Map<IEnumerable<Entities.sp_get_pag_productoptoprep_Result>, IEnumerable<ProductoPtoPrep>>(list);
        }

        public ProductoPtoPrep Obtener(int? codProductoPtoPrep)
        {
            var item = this.DataContext.sp_get_productoptoprep(codProductoPtoPrep).SingleOrDefault();
            return Mapper.Map<Entities.sp_get_productoptoprep_Result, ProductoPtoPrep>(item);
        }

        public void Crear(ProductoPtoPrep productoPtoPrep)
        {
            this.DataContext.sp_add_productoptoprep(
                productoPtoPrep.CodPtoPreparacion,
                productoPtoPrep.CodProducto,
                productoPtoPrep.IndEnsamblado,
                productoPtoPrep.TiempoPrepDirecto,
                productoPtoPrep.TiempoPrepSegundo,
                productoPtoPrep.MinCantidad,
                productoPtoPrep.MaxCantidad,
                productoPtoPrep.UsuarioCreacion
            );            
        }

        #endregion
    }
}