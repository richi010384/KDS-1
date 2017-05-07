using KDS.Domain.Entities;
using KDS.Web.Areas.Kitchen.Models;
using AutoMapper;

namespace KDS.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductoPtoPrep, ProductoPtoPrepViewModel>();
            CreateMap<PtoPreparacion, PtoPreparacionViewModel>();
            CreateMap<TiempoConsumo, TiempoConsumoViewModel>();
            CreateMap<UnidadNegocio, UnidadNegocioViewModel>();
        }
    }
}