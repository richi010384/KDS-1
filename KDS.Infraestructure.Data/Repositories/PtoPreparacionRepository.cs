using AutoMapper;
using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Repositories;
using KDS.Infraestructure.CrossCutting.Entities;
using KDS.Infraestructure.CrossCutting.Helpers;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace KDS.Infraestructure.Data.Repositories
{
    public class PtoPreparacionRepository
        : Repository<PtoPreparacion, Entities.PtoPreparacion>, IPtoPreparacionRepository
    {
        #region Constructor

        public PtoPreparacionRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        #endregion

        #region ProductRepository Members

        public IEnumerable<PtoPreparacion> ObtenerPaginado(string codUnidadNegocio, ref Pagination paginacion)
        {
            var totalDisplayRecords = new ObjectParameter("p_TotalDisplayRecords", typeof(int));
            var totalRecords = new ObjectParameter("p_TotalRecords", typeof(int));
            var list = this.DataContext.sp_get_pag_ptopreparacion(
                codUnidadNegocio,
                paginacion.StartIndex,
                paginacion.EndIndex,
                paginacion.SortColumn,
                paginacion.SortOrder,
                totalDisplayRecords,
                totalRecords
            ).ToList();
            paginacion.TotalDisplayRecords = (int)totalDisplayRecords.Value;
            paginacion.TotalRecords = (int)totalRecords.Value;
            return Mapper.Map<IEnumerable<Entities.sp_get_pag_ptopreparacion_Result>, IEnumerable<PtoPreparacion>>(list);
        }

        public void Crear(PtoPreparacion ptoPreparacion)
        {
            this.DataContext.sp_add_ptopreparacion(
                ptoPreparacion.CodUnidadNegocio,
                ptoPreparacion.Nombre,
                ptoPreparacion.Descripcion,
                ptoPreparacion.UsuarioCreacion
            );            
        }

        public IEnumerable<PtoPreparacion> ObtenerxUnidadNegocio(string codUnidadNegocio)
        {
            return Mapper.Map<IEnumerable<Entities.PtoPreparacion>, IEnumerable<PtoPreparacion>>(this.DataContext.PtoPreparacion.Where(x => x.CodUnidadNegocio == codUnidadNegocio));
        }

        #endregion
    }
}