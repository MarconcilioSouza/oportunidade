using AvaliacaoMinutoSeguros.Infra.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvaliacaoMinutoSeguros.Domain.ViewModel
{
    public class ItemViewModel
    {
        private const string ARTIGOS_PREPOSICOES = "a;as;o;os;uma;umas;um;uns;ante;após;até;com;contra;de;desde;em;entre;para;por;perante;sem;sob;sobre;trás;afora;como;conforme;consoante;durante;exceto;feito;fora;mediante;menos;salvo;segundo;senão;tirante;visto;do;duma;à;àquele;aquele;duma;disto;nas;num;nessa;pelo;pelas;ao;aos;aonde";

        public string Title { get; set; }
        public string Creator { get; set; }
        public List<string> Category { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Encoded { get; set; }
        public int TotalPalavrasBlog { get; set; }
        public List<PalavrasViewModel> Palavras { get; set; }

        public int TotalPalavras(string palavras)
        {
            palavras = " " + StringHelpers.RemoverTagsHtml(palavras);
            palavras = StringHelpers.RemoverPontuacao(palavras);

            foreach (string word in ARTIGOS_PREPOSICOES.Split(';'))
            {
                palavras = palavras.ToLower().Replace(" " + word + " ", " ");
            }
            while (palavras.Contains("  "))
            {
                palavras = palavras.Replace("  ", " ");
            }

            return palavras.Trim().Split(' ').Count();
        }

        public List<PalavrasViewModel> ObterPalavrasRepetidas(string texto)
        {
            texto = StringHelpers.RemoverTagsHtml(texto);
            texto = StringHelpers.RemoverPontuacao(texto);
            texto = texto.ToLower();

            StringBuilder sb = new StringBuilder("");
            int index = 0;
            foreach (string palavra in texto.Split(' '))
            {
                if (!string.IsNullOrEmpty(palavra) && (sb.ToString().ToLower().IndexOf(string.Concat("|", palavra, "|"), StringComparison.CurrentCultureIgnoreCase) == -1)
                    && (!Array.Exists(ARTIGOS_PREPOSICOES.Split(';'), x => x.Equals(palavra, StringComparison.OrdinalIgnoreCase))))
                {
                    sb.AppendLine(string.Concat("|", palavra, "|"));
                    index++;
                }
            }

            List<PalavrasViewModel> palavrasViewModel = new List<PalavrasViewModel>();
            foreach (string palavra in sb.ToString().Split('|'))
            {
                if (!string.IsNullOrWhiteSpace(palavra))
                {
                    palavrasViewModel.Add(new PalavrasViewModel()
                    {
                        Palavra = palavra,
                        TotalVezesUsuada = TotalPalavrasRepetidas(texto, palavra.Replace("|", ""))
                    });
                }
            }
            return palavrasViewModel.OrderByDescending(x => x.TotalVezesUsuada).Take(10).ToList();
        }

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
