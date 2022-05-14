using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AssetManagement.App.GUI.Provider
{
    public class AssetWithoutBarcodeProvider
    {
        private readonly HttpClient _client;

        public AssetWithoutBarcodeProvider(HttpClient client)
        {
            _client = client;
        }
    }
}
