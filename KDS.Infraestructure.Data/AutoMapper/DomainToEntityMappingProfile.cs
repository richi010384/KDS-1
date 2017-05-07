using AutoMapper;
using KDS.Infraestructure.Data.Entities;

namespace KDS.Infraestructure.Data.AutoMapper
{
    public class DomainToEntityMappingProfile : Profile
    {
        public DomainToEntityMappingProfile()
        {
            //Tables
            CreateMap<Domain.Entities.Parametrica, Parametrica>();
            CreateMap<Domain.Entities.ProductoPtoPrep, ProductoPtoPrep>();
            CreateMap<Domain.Entities.PtoPreparacion, PtoPreparacion>();
            CreateMap<Domain.Entities.TiempoConsumo, TiempoConsumo>();

            //Views
            CreateMap<Domain.Entities.Grupo, vw_Grupo>();
            CreateMap<Domain.Entities.Subgrupo, vw_SubGrupo>();
            CreateMap<Domain.Entities.UnidadNegocio, vw_UnidadNegocio>();


            //Stored Procedures
            CreateMap<Domain.Entities.Grupo, sp_get_grupo_maestro_Result>();
            CreateMap<Domain.Entities.Producto, sp_get_aut_producto_Result>();
            CreateMap<Domain.Entities.Producto, sp_get_producto_maestro_Result>();
            CreateMap<Domain.Entities.ProductoPtoPrep, sp_get_productoptoprep_Result>();
            CreateMap<Domain.Entities.ProductoPtoPrep, sp_get_pag_productoptoprep_Result>();
            CreateMap<Domain.Entities.PtoPreparacion, sp_get_pag_ptopreparacion_Result>();
            CreateMap<Domain.Entities.TiempoConsumo, sp_get_tiempoconsumo_grupo_Result>();
            CreateMap<Domain.Entities.TiempoConsumo, sp_get_tiempoconsumo_subgrupo_Result>();
            CreateMap<Domain.Entities.TiempoConsumo, sp_get_tiempoconsumo_producto_Result>();
            CreateMap<Domain.Entities.Subgrupo, sp_get_subgrupo_maestro_Result>();
        }
    }
}
