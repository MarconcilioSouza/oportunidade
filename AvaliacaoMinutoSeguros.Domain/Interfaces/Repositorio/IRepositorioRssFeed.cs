using AvaliacaoMinutoSeguros.Domain.Entidades;

namespace AvaliacaoMinutoSeguros.Domain.Interfaces.Repositorio
{
    public interface IRepositorioRssFeed
    {
        Rss ObterRssFeed(string uri);
        string ObterHtmlBlog(string urlAddress);
    }
}
