using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Entidade
{
    public class Credencial
    {
        private string apiKey;
        public string ApiKey
        {
            get
            {
                return apiKey;
            }
        }
        private string searchEngineID;
        public string CustomSearchId
        {
            get
            {
                return searchEngineID;
            }
        }

        public Credencial(string apiKey, string searchEngineID)
        {
            this.apiKey = apiKey;
            this.searchEngineID = searchEngineID;
        }

        
    }

}
