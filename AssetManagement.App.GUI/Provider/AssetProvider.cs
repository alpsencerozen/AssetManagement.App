using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AssetManagement.App.GUI.Provider
{
    public class AssetProvider
    {
        private readonly HttpClient _client;

        public AssetProvider(HttpClient client)
        {
            _client = client;
        }


    }
}
