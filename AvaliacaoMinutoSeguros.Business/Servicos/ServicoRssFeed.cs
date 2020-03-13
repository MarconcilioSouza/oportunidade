using AutoMapper;
using AvaliacaoMinutoSeguros.Domain.Interfaces.Repositorio;
using AvaliacaoMinutoSeguros.Domain.Interfaces.Servicos;
using AvaliacaoMinutoSeguros.Domain.ViewModel;
using AvaliacaoMinutoSeguros.Infra.Helps;
using System;
using System.Collections.Generic;

namespace AvaliacaoMinutoSeguros.Business.Servicos
{
    public class ServicoRssFeed : IServicoRssFeed
    {
        private readonly IRepositorioRssFeed repositorioRssFeed;

        /// <summary>
        /// Construtor, injeta o repositorio via IoC.
        /// </summary>
        /// <param name="_repositorioRssFeed"></param>
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
                    string texto = TratarTexto(item);

                    item.TotalPalavrasBlog = item.TotalPalavras(texto);
                    item.Palavras = item.ObterPalavrasRepetidas(texto);
                }

                return feedModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Remover as tags html, pontuação, os artigos, preposições e espaços desnecessarios do texto
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static string TratarTexto(ItemViewModel item)
        {
            try
            {
                string texto = string.Concat(item.Title, " ", item.Description, " ", item.Encoded);
                texto = StringHelpers.RemoverTagsHtml(texto);
                texto = StringHelpers.RemoverPontuacao(texto);
                texto = texto.ToLower();
                texto = StringHelpers.RemoverArtigosEPreposicoes(texto);
                texto = StringHelpers.RemoverEspacos(texto);
                return texto;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
