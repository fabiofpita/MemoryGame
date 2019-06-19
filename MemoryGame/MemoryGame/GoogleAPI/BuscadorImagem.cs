using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using MemoryGame.Entidade;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MemoryGame.GoogleAPI
{
    class BuscadorImagem
    {
        private static Credencial credenciais;

        public BuscadorImagem()
        {
            using (StreamReader r = new StreamReader(@"credenciais.json"))
            {
                string json = r.ReadToEnd();
                credenciais = JsonConvert.DeserializeObject<Credencial>(json);
            }
        }

        public List<Dictionary<String, String>> Search(string query, int qtdeResultado)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                var service = new CustomsearchService(new BaseClientService.Initializer
                {
                    ApplicationName = "MemoryGame",
                    ApiKey = credenciais.ApiKey,
                });

                var lisRequest = service.Cse.List(query);
                lisRequest.Cx = credenciais.CustomSearchId;
                lisRequest.Num = 10;
                lisRequest.FileType = "jpeg";
                lisRequest.SearchType = CseResource.ListRequest.SearchTypeEnum.Image;
                //lisRequest.ImgSize = CseResource.ListRequest.ImgSizeEnum.Xlarge;
                var results = lisRequest.Execute();

                List<Dictionary<String, String>> imagens = new List<Dictionary<String, String>>();
                foreach (Result item in results.Items)
                {
                    if(imagens.Count >= qtdeResultado)
                    {
                        break;
                    }

                    var aux = new Dictionary<String, String>();
                    string formato = "";

                    if (item.Link.EndsWith(".jpg"))
                    {
                        formato = ".jpg";
                    }
                    else if (item.Link.EndsWith(".jpeg"))
                    {
                        formato = ".jpeg";
                    }
                    else if (item.Link.EndsWith(".png"))
                    {
                        formato = ".png";
                    }
                    else if (item.Link.EndsWith(".bmp"))
                    {
                        formato = ".bmp";
                    }

                    if (!String.IsNullOrWhiteSpace(formato))
                    {
                        aux.Add("Url", item.Link);
                        aux.Add("Formato", formato);
                        imagens.Add(aux);
                    }

                }

                sw.Stop();

                return imagens;
            }
            catch (TimeoutException)
            {
                return null;
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace.ToString());
                return null;
            }

        }
    }
}
