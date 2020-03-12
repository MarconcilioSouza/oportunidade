using AutoMapper;

namespace AvaliacaoMinutoSeguros.Business.AutoMapper
{
    public interface IAutoMapperConfig
    {
        void RegisterMappings();
        IMapper Mapper { get; set; }
    }
}
