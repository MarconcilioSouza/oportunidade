using AutoMapper;
using AvaliacaoMinutoSeguros.Domain.Entidades;
using AvaliacaoMinutoSeguros.Domain.ViewModel;

namespace AvaliacaoMinutoSeguros.Business.AutoMapper
{
    public class ModelToViewModelMappingProfile : Profile
    {
        public ModelToViewModelMappingProfile()
        {
            CreateMap<Channel, RssFeedViewModel>();
            CreateMap<Item, ItemViewModel>();
        }
    }
}
