using AutoMapper;
using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Repositories;
using KDS.Infraestructure.CrossCutting.Constants;
using System.Collections.Generic;
using System.Linq;

namespace KDS.Infraestructure.Data.Repositories
{
    public class ProductoRepository
        : Repository<Producto, Entities.vw_Producto>, IProductoRepository
    {
        #region Constructor

        public ProductoRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        #endregion

        #region ProductRepository Members

        public IEnumerable<Producto> ObtenerAutocompletado(string codUnidadNegocio, string descProducto)
        {
            var list = this.DataContext.sp_get_aut_producto(
                codUnidadNegocio,
                descProducto,
                App.NroElementosAutocompletar
            ).ToList();
            return Mapper.Map<IEnumerable<Entities.sp_get_aut_producto_Result>, IEnumerable<Producto>>(list);
        }

        #endregion
    }
}