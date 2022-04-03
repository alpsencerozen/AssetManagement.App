using AssetManagement.App.GUI.Models.APIModels;
using Newtonsoft.Json;
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

        public async Task<AssetDetailChoicesDTO> GetAssetDetailChoices()
        {
            var choices = await _client.GetAsync("AssetDetailChoice");

            if (choices.IsSuccessStatusCode)
            {
                var choicesString = await choices.Content.ReadAsStringAsync();
                var choicesJson = JsonConvert.DeserializeObject<AssetDetailChoicesDTO>(choicesString);
                return choicesJson;
            }
            else
            {

                return null;
            }
        }


    }
}
