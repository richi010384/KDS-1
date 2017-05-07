using AutoMapper;
using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Repositories;
using KDS.Infraestructure.CrossCutting.Entities;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace KDS.Infraestructure.Data.Repositories
{
    public class PedidoProductoRepository
        : Repository<PedidoProducto, Entities.PedidoProducto>, IPedidoProductoRepository
    {
        #region Constructor

        public PedidoProductoRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        #endregion

        #region PedidoRepository Members

        public IEnumerable<PedidoProducto> ObtenerPaginado(int? codPtoPreparacion, ref Pagination paginacion)
        {
            var totalDisplayRecords = new ObjectParameter("p_TotalDisplayRecords", typeof(int));
            var totalRecords = new ObjectParameter("p_TotalRecords", typeof(int));
            var list = this.DataContext.sp_get_pag_pedidoproducto(
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
            return Mapper.Map<IEnumerable<Entities.sp_get_pag_pedidoproducto_Result>, IEnumerable<PedidoProducto>>(list);
        }

        #endregion
    }
}