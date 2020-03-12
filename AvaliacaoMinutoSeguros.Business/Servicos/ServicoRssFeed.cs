using AutoMapper;
using AvaliacaoMinutoSeguros.Domain.Interfaces.Repositorio;
using AvaliacaoMinutoSeguros.Domain.Interfaces.Servicos;
using AvaliacaoMinutoSeguros.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AvaliacaoMinutoSeguros.Business.Servicos
{
    public class ServicoRssFeed : IServicoRssFeed
    {
        private readonly IRepositorioRssFeed repositorioRssFeed;

        public ServicoRssFeed(IRepositorioRssFeed _repositorioRssFeed)
        {
            repositorioRssFeed = _repositorioRssFeed;
        }

        /// <summary>
        /// Processar o XML do blog
        /// </summary>
        /// <param name="uri">URI do blog</param>
        /// <returns>retorna a model com os dados do blog</returns>
        public RssFeedViewModel ProcessarRssFeed(string uri, IMapper mapper)
        {
            try
            {
                var rssFeed = repositorioRssFeed.ObterRssFeed(uri);

                var items = new List<ItemViewModel>();
                var feedModel = mapper.Map<RssFeedViewModel>(rssFeed.Channel);

                foreach (var item in feedModel.Items)
                {
                    var html = repositorioRssFeed.ObterHtmlBlog(item.Link);
                    item.TotalPalavrasBlog = item.TotalPalavras(item.Description);
                    item.Palavras = item.ObterPalavrasRepetidas(item.Description);
                }

                return feedModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
