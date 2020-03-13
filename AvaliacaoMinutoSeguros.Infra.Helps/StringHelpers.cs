using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AvaliacaoMinutoSeguros.Infra.Helps
{
    public static class StringHelpers
    {
        public readonly static string[] ARTIGOS_PREPOSICOES =
            {
                " a ", " com ",  " as ", " o ", " os ", " uma ", " um ", " uns ", " em ", " de ", " do ", " como ", " para ", " ao ", " aos ",
                " por ", " à ",  " sem ",   " após ", " até ", " nas ", " num ", " nessa ", " pelo ", " pelas "," contra ", " aonde ", " umas ",
                " desde ", " entre ", " perante ", " sob ", " sobre ", " trás ", " afora ",  " conforme ", " consoante ", " durante ", " exceto ",
                " feito ", " fora ", " mediante ", " menos ", " salvo ", " segundo ", " senão ", " tirante ", " visto ",  " ante ", " duma ",
                " àquele ", " aquele ", " duma ", " disto ",
            };

        public static string RemoverTagsHtml(string texto)
        {
            return Regex.Replace(texto, "<.*?>", string.Empty);
        }

        public static string RemoverPontuacao(string texto)
        {
            return texto.Replace(",", "")
               .Replace(".", "")
               .Replace(";", "")
               .Replace("!", "!")
               .Replace("?", "")
               .Replace(":", "")
               .Replace(@"/", "")
               .Replace(@"\", "")
               .Replace("(", "")
               .Replace(")", "");
        }

        public static string RemoverArtigosEPreposicoes(string texto)
        {
            try
            {
                foreach (string artPrep in ARTIGOS_PREPOSICOES)
                {
                    texto = texto.Replace(artPrep, " ");
                }

                return texto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string RemoverEspacos(string texto)
        {
            try
            {
                while (texto.Contains("  "))
                {
                    texto = texto.Replace("  ", " ");
                }

                return texto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
