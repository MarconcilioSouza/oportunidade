using AutoMapper;
using AvaliacaoMinutoSeguros.Domain.ViewModel;

namespace AvaliacaoMinutoSeguros.Domain.Interfaces.Servicos
{
    public interface IServicoRssFeed
    {
        RssFeedViewModel ProcessarRssFeed(string uri, IMapper mapper);
    }
}
