using AutoMapper;
namespace GEA.AvaliacaoTecnica.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
            });
        }

    }
}
