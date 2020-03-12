using AvaliacaoMinutoSeguros.Business.AutoMapper;
using AvaliacaoMinutoSeguros.Business.Servicos;
using AvaliacaoMinutoSeguros.Domain.Interfaces.Repositorio;
using AvaliacaoMinutoSeguros.Domain.Interfaces.Servicos;
using AvaliacaoMinutoSeguros.Infra.Data;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace AvaliacaoMinutoSeguros.Infra.IoC
{
    public class SimpleInjectorContainer
    {
        public Container container;
        /// <summary>
        /// Construtor 
        /// Registra as classes que implementam as interfaces
        /// </summary>
        public SimpleInjectorContainer()
        {
            container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IRepositorioRssFeed, RepositorioRssFeed>();
            container.Register<IServicoRssFeed, ServicoRssFeed>(); 
            
            container.Verify();
        }
    }
}
