using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvaliacaoMinutoSeguros.Domain.ViewModel
{
    public class ItemViewModel
    {        
        public string Title { get; set; }
        public string Creator { get; set; }
        public List<string> Category { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Encoded { get; set; }
        public DateTime PubDate { get; set; }

        public int TotalPalavrasBlog { get; set; }
        public List<PalavrasViewModel> Palavras { get; set; }

        /// <summary>
        /// Retorna a quantidade de palavras no texto
        /// </summary>
        /// <param name="texto">testo a ser verificado</param>
        /// <returns>total de palavras</returns>
        public int TotalPalavras(string texto)
        {
            return texto.Trim().Split(' ').Count();
        }

        /// <summary>
        /// Retorna as 10 palavras mais usuadas e a quantidade de vezes que existe no texto
        /// </summary>
        /// <param name="texto">texto a ser verificado</param>
        /// <returns>List<PalavrasViewModel></returns>
        public List<PalavrasViewModel> ObterPalavrasRepetidas(string texto)
        {
            List<PalavrasViewModel> palavrasViewModel = new List<PalavrasViewModel>();

            StringBuilder sb = new StringBuilder("");
            foreach (string palavra in texto.Split(' '))
            {
                if ((sb.ToString().ToLower().IndexOf(string.Concat("|", palavra, "|"), StringComparison.CurrentCultureIgnoreCase) == -1))
                {
                    sb.AppendLine(string.Concat("|", palavra, "|"));
                }
            }

            List<PalavrasViewModel> result = new List<PalavrasViewModel>();
            foreach (string palavra in sb.ToString().Split('|'))
            {
                var _palavra = palavra.Trim();
                if (!string.IsNullOrWhiteSpace(_palavra))
                {
                    palavrasViewModel.Add(new PalavrasViewModel()
                    {
                        Palavra = _palavra,
                        TotalVezesUsuada = TotalPalavrasRepetidas(texto, _palavra),
                    });
                }
            }

            return palavrasViewModel.OrderByDescending(x => x.TotalVezesUsuada).Take(10).ToList();
        }

        /// <summary>
        /// Calcular o total de palavras repetidas
        /// </summary>
        /// <param name="texto">texto a ser usado</param>
        /// <param name="palavra">palavra a ser verificada</param>
        /// <returns></returns>
        private int TotalPalavrasRepetidas(string texto, string palavra)
        {
            string[] palavras = texto.Split(' ');

            int count = 0;
            for (int i = 0; i < palavras.Length; i++)
            {
                if (palavra.Equals(palavras[i]))
                    count++;
            }

            return count;
        }
    }
}
