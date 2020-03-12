using AutoMapper;
using AvaliacaoMinutoSeguros.Business.AutoMapper;
using AvaliacaoMinutoSeguros.Domain.Interfaces.Servicos;
using AvaliacaoMinutoSeguros.Infra.IoC;
using System.Configuration;

namespace AvaliacaoMinutoSeguros.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var iocInjector = new SimpleInjectorContainer();
            //registra o auto map
            var mapperConfiguration = AutoMapperConfig.RegisterMappings();
            IMapper mapper = mapperConfiguration.CreateMapper();

            string uri = ConfigurationManager.AppSettings["Uri"];

            var servicoRssFeed = iocInjector.container.GetInstance<IServicoRssFeed>();

            var rssFeedViewModel = servicoRssFeed.ProcessarRssFeed(uri, mapper);

           
        }
    }
}
