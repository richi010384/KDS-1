//<!-- Autor: RICARDO G. MARTIN BEUERMANN -->

using AutoMapper;
using KDS.Domain.Entities;
using KDS.Domain.Interfaces.Repositories;
using KDS.Infraestructure.CrossCutting.Entities;
using KDS.Infraestructure.CrossCutting.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace KDS.Infraestructure.Data.Repositories
{
    public class TiempoConsumoRepository
        : Repository<TiempoConsumo, Entities.TiempoConsumo>, ITiempoConsumoRepository
    {
        #region Constructor

        public TiempoConsumoRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        #endregion

        #region ProductRepository Members
        public IEnumerable<TiempoConsumo> ListarPorGrupos(string CodGrupo, string CodPropiedad, int Cantidad, ref Pagination paginacion) {
            var totalDisplayRecords = new ObjectParameter("p_TotalDisplayRecords", typeof(int));
            var totalRecords = new ObjectParameter("p_TotalRecords", typeof(int));
            var list = this.DataContext.sp_get_tiempoconsumo_grupo(CodGrupo, CodPropiedad, Cantidad,
                paginacion.StartIndex,
                paginacion.EndIndex,
                paginacion.SortColumn,
                paginacion.SortOrder,
                totalDisplayRecords,
                totalRecords
            ).ToList();
            paginacion.TotalDisplayRecords = (int)totalDisplayRecords.Value;
            paginacion.TotalRecords = (int)totalRecords.Value;
            return Mapper.Map<IEnumerable<Entities.sp_get_tiempoconsumo_grupo_Result>, IEnumerable<TiempoConsumo>>(list);
        }

        public IEnumerable<TiempoConsumo> ListarPorSubGrupos(string CodSubGrupo, string CodGrupo, string CodPropiedad, int Cantidad, ref Pagination paginacion) {
            var totalDisplayRecords = new ObjectParameter("p_TotalDisplayRecords", typeof(int));
            var totalRecords = new ObjectParameter("p_TotalRecords", typeof(int));
            var list = this.DataContext.sp_get_tiempoconsumo_subgrupo(CodSubGrupo, CodGrupo, CodPropiedad, Cantidad,
                paginacion.StartIndex,
                paginacion.EndIndex,
                paginacion.SortColumn,
                paginacion.SortOrder,
                totalDisplayRecords,
                totalRecords
            ).ToList();
            paginacion.TotalDisplayRecords = (int)totalDisplayRecords.Value;
            paginacion.TotalRecords = (int)totalRecords.Value;
            return Mapper.Map<IEnumerable<Entities.sp_get_tiempoconsumo_subgrupo_Result>, IEnumerable<TiempoConsumo>>(list);
        }

        public IEnumerable<TiempoConsumo> ListarPorProductos(string CodGrupo, string CodSubGrupo, string CodProducto, string DescProducto, string CodPropiedad, int Cantidad, ref Pagination paginacion)
        {
            var totalDisplayRecords = new ObjectParameter("p_TotalDisplayRecords", typeof(int));
            var totalRecords = new ObjectParameter("p_TotalRecords", typeof(int));
            var list = this.DataContext.sp_get_tiempoconsumo_producto(CodGrupo, CodSubGrupo, CodPropiedad, CodProducto, DescProducto, Cantidad,
                paginacion.StartIndex,
                paginacion.EndIndex,
                paginacion.SortColumn,
                paginacion.SortOrder,
                totalDisplayRecords,
                totalRecords
            ).ToList();
            paginacion.TotalDisplayRecords = (int)totalDisplayRecords.Value;
            paginacion.TotalRecords = (int)totalRecords.Value;
            return Mapper.Map<IEnumerable<Entities.sp_get_tiempoconsumo_producto_Result>, IEnumerable<TiempoConsumo>>(list);
        }

        public IEnumerable<Grupo> ListarMaestroGrupo(string CodGrupo, ref Pagination paginacion)
        {
            var totalDisplayRecords = new ObjectParameter("p_TotalDisplayRecords", typeof(int));
            var totalRecords = new ObjectParameter("p_TotalRecords", typeof(int));
            var list = this.DataContext.sp_get_grupo_maestro(CodGrupo, 
                paginacion.StartIndex,
                paginacion.EndIndex,
                paginacion.SortColumn,
                paginacion.SortOrder,
                totalDisplayRecords,
                totalRecords
            ).ToList();
            paginacion.TotalDisplayRecords = (int)totalDisplayRecords.Value;
            paginacion.TotalRecords = (int)totalRecords.Value;
            return Mapper.Map<IEnumerable<Entities.sp_get_grupo_maestro_Result>, IEnumerable<Grupo>>(list);
        }

        public IEnumerable<Subgrupo> ListarMaestroSubGrupo(string CodSubGrupo, string CodGrupo, ref Pagination paginacion)
        {
            var totalDisplayRecords = new ObjectParameter("p_TotalDisplayRecords", typeof(int));
            var totalRecords = new ObjectParameter("p_TotalRecords", typeof(int));
            var list = this.DataContext.sp_get_subgrupo_maestro(CodGrupo, CodSubGrupo, 
                paginacion.StartIndex,
                paginacion.EndIndex,
                paginacion.SortColumn,
                paginacion.SortOrder,
                totalDisplayRecords,
                totalRecords
            ).ToList();
            paginacion.TotalDisplayRecords = (int)totalDisplayRecords.Value;
            paginacion.TotalRecords = (int)totalRecords.Value;
            return Mapper.Map<IEnumerable<Entities.sp_get_subgrupo_maestro_Result>, IEnumerable<Subgrupo>>(list);
        }

        public IEnumerable<Producto> ListarMaestroProducto(string CodGrupo, string CodSubGrupo, string CodProducto, string DescProducto, ref Pagination paginacion)
        {
            var totalDisplayRecords = new ObjectParameter("p_TotalDisplayRecords", typeof(int));
            var totalRecords = new ObjectParameter("p_TotalRecords", typeof(int));
            var list = this.DataContext.sp_get_producto_maestro(CodGrupo, CodSubGrupo, CodProducto, DescProducto,
                paginacion.StartIndex,
                paginacion.EndIndex,
                paginacion.SortColumn,
                paginacion.SortOrder,
                totalDisplayRecords,
                totalRecords
            ).ToList();
            paginacion.TotalDisplayRecords = (int)totalDisplayRecords.Value;
            paginacion.TotalRecords = (int)totalRecords.Value;
            return Mapper.Map<IEnumerable<Entities.sp_get_producto_maestro_Result>, IEnumerable<Producto>>(list);
        }

        public IEnumerable<Grupo> ListarGrupos()
        {
            return Mapper.Map<IEnumerable<Entities.vw_Grupo>, IEnumerable<Grupo>>(DataContext.vw_Grupo);
        }

        public IEnumerable<Subgrupo> ListarSubGrupos(string CodGrupo)
        {
            var list = Mapper.Map<IEnumerable<Entities.vw_SubGrupo>, IEnumerable<Subgrupo>>(DataContext.vw_SubGrupo);
            return list.Where(x => x.CodGrupo == CodGrupo || string.IsNullOrWhiteSpace(CodGrupo));
        }

        public IEnumerable<Parametrica> ListarParametros(int CodTipoParametro)
        {
            var list = Mapper.Map<IEnumerable<Entities.Parametrica>, IEnumerable<Parametrica>>(DataContext.Parametrica);
            return list.Where(x => x.CodTipoParametrica == CodTipoParametro && x.Estado == true);
        }

        public void Guardar(TiempoConsumo tconsumo)
        {
            this.DataContext.sp_add_tiempoconsumo(
                tconsumo.CodTiempoConsumo,
                tconsumo.CodGrupo,
                tconsumo.CodSubGrupo,
                tconsumo.CodProducto,
                tconsumo.CodPropiedad,
                tconsumo.Cantidad,
                tconsumo.MinComensales,
                tconsumo.MaxComensales,
                tconsumo.Tiempo,
                AppContext.Sesion.UserName
            );
        }

        #endregion
    }
}