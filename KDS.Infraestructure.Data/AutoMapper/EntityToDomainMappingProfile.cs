using AutoMapper;
using KDS.Infraestructure.Data.Entities;

namespace KDS.Infraestructure.Data.AutoMapper
{
    public class EntityToDomainMappingProfile : Profile
    {
        public EntityToDomainMappingProfile()
        {
            //Tables
            CreateMap<Parametrica, Domain.Entities.Parametrica>();
            CreateMap<ProductoPtoPrep, Domain.Entities.ProductoPtoPrep>();
            CreateMap<PtoPreparacion, Domain.Entities.PtoPreparacion>();
            CreateMap<TiempoConsumo, Domain.Entities.TiempoConsumo>();

            //Views
            CreateMap<vw_Grupo, Domain.Entities.Grupo>();
            CreateMap<vw_SubGrupo, Domain.Entities.Subgrupo>();
            CreateMap<vw_UnidadNegocio, Domain.Entities.UnidadNegocio>();

            //Stored Procedures            
            CreateMap<sp_get_aut_producto_Result, Domain.Entities.Producto>();
            CreateMap<sp_get_grupo_maestro_Result, Domain.Entities.Grupo>();
            CreateMap<sp_get_productoptoprep_Result, Domain.Entities.ProductoPtoPrep>();
            CreateMap<sp_get_pag_pedidoproducto_Result, Domain.Entities.PedidoProducto>();
            CreateMap<sp_get_pag_productoptoprep_Result, Domain.Entities.ProductoPtoPrep>();
            CreateMap<sp_get_pag_ptopreparacion_Result, Domain.Entities.PtoPreparacion>();
            CreateMap<sp_get_producto_maestro_Result, Domain.Entities.Producto>();
            CreateMap<sp_get_tiempoconsumo_grupo_Result, Domain.Entities.TiempoConsumo>();
            CreateMap<sp_get_tiempoconsumo_subgrupo_Result, Domain.Entities.TiempoConsumo>();
            CreateMap<sp_get_tiempoconsumo_producto_Result, Domain.Entities.TiempoConsumo>();
            CreateMap<sp_get_subgrupo_maestro_Result, Domain.Entities.Subgrupo>();
        }
    }
}
