using KDS.Domain.Entities;
using KDS.Web.Areas.Kitchen.Models;
using AutoMapper;

namespace KDS.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductoPtoPrepViewModel, ProductoPtoPrep>();
            CreateMap<PtoPreparacionViewModel, PtoPreparacion>();
            CreateMap<TiempoConsumoViewModel, TiempoConsumo>();
            CreateMap<UnidadNegocioViewModel, UnidadNegocio>();
        }
    }
}