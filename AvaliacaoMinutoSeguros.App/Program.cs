using AutoMapper;
using AvaliacaoMinutoSeguros.Business.AutoMapper;
using AvaliacaoMinutoSeguros.Domain.Interfaces.Servicos;
using AvaliacaoMinutoSeguros.Infra.IoC;
using System;
using System.Configuration;

namespace AvaliacaoMinutoSeguros.App
{
    /// <summary>
    /// Criado por: Marconcilio Souza
    /// Linkedin: 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // registra o contaner de IoC
            var iocInjector = new SimpleInjectorContainer();
            //registra o auto map
            var mapperConfiguration = AutoMapperConfig.RegisterMappings();
            IMapper mapper = mapperConfiguration.CreateMapper();

            string uri = ConfigurationManager.AppSettings["Uri"];

            var servicoRssFeed = iocInjector.container.GetInstance<IServicoRssFeed>();

            var rssFeedViewModel = servicoRssFeed.ProcessarRssFeed(uri, mapper);

            System.Console.WriteLine($"Dados do blog: { rssFeedViewModel.Title }");
            System.Console.WriteLine($"Ultima alteração: { rssFeedViewModel.LastBuildDate }");
            Console.WriteLine();

            foreach (var item in rssFeedViewModel.Items)
            {
                System.Console.WriteLine($"Título do blog: { item.Title }");
                System.Console.WriteLine($"Criado por: { item.Creator }");
                System.Console.WriteLine($"Publicado em: { item.PubDate }");
                Console.WriteLine();

                Console.WriteLine("As 10 dez principais palavras abordadas nesses tópicos são:");
                var index = 1;
                foreach (var palavra in item.Palavras)
                {
                    Console.WriteLine($"{ index }ª) { palavra.Palavra.ToUpper() }, o número de vezes que ela apareceu foi: { palavra.TotalVezesUsuada }!");
                    index++;
                }

                Console.WriteLine($"Total de palavras usuadas no blog { item.TotalPalavrasBlog } palavras");

                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
