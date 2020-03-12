using AvaliacaoMinutoSeguros.Domain.Entidades;
using AvaliacaoMinutoSeguros.Domain.Interfaces.Repositorio;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;

namespace AvaliacaoMinutoSeguros.Infra.Data
{
    public class RepositorioRssFeed : IRepositorioRssFeed
    {
        public Rss ObterRssFeed(string uri)
        {
            try
            {
                var client = new HttpClient();
                var rss = client.GetStreamAsync(uri).Result;
                var serializer = new XmlSerializer(typeof(Rss));
                return (Rss)serializer.Deserialize(rss);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ObterHtmlBlog(string urlAddress)
        {
            string data = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                 data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
            return data;
        }
    }
}
