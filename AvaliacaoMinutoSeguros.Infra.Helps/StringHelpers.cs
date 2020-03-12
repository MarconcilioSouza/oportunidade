using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AvaliacaoMinutoSeguros.Infra.Helps
{
    public static class StringHelpers
    {
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
    }
}
