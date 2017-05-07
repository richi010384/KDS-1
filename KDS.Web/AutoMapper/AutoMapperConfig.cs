using AutoMapper;
using KDS.Infraestructure.Data.AutoMapper;

namespace KDS.Web.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                //Mappings Infraestructure
                x.AddProfile<DomainToEntityMappingProfile>();
                x.AddProfile<EntityToDomainMappingProfile>();

                //Mappings Presentation
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}