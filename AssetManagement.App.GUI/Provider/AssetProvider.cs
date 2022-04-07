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

        public async Task<AssetDetailChoicesDTO> GetAssetDetailChoicesById(int id)
        {
            var choices = await _client.GetAsync($"/api/AssetDetailChoice/api/getassetdetailbyid/{id}");

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

        public async Task<string> CreateAsset(AssetDetailChoicesDTO choices)
        {
            var choicesJson = new StringContent(JsonConvert.SerializeObject(choices));

            choicesJson.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string outcome = "";

            try
            {
                var responseValue = await _client.PostAsync("/api/addasset/AssetDetailChoice", choicesJson);
                if (responseValue.IsSuccessStatusCode)
                {
                    await responseValue.Content.ReadAsStringAsync();
                }
                outcome = "basarili";
            
            }
            catch (Exception)
            {

                throw;
            }
            return outcome;
        }

        public async Task<string> UpdateAsset(AssetDetailChoicesDTO updatedAsset)
        {
            var updatedAssetJson = new StringContent(JsonConvert.SerializeObject(updatedAsset));

            updatedAssetJson.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string outcome = "";

            try
            {
                var responseValue = await _client.PutAsync("/api/updateasset/AssetDetailChoice", updatedAssetJson);
                if (responseValue.IsSuccessStatusCode)
                {
                    await responseValue.Content.ReadAsStringAsync();
                }
                outcome = "basarili";
            
            }
            catch (Exception)
            {

                throw;
            }
            return outcome;
        }

        public async Task<IEnumerable<AssetDTO>> GetAssets()
        {
            var choices = await _client.GetAsync("/api/Asset");

            if (choices.IsSuccessStatusCode)
            {
                var choicesString = await choices.Content.ReadAsStringAsync();
                var choicesJson = JsonConvert.DeserializeObject<IEnumerable<AssetDTO>>(choicesString);
                return choicesJson;
            }
            else
            {

                return null;
            }
        }

        public async Task<AssetDTO> GetAssets(int id)
        {
            var choices = await _client.GetAsync($"/api/asset/api/getassetbyid/?assetID={id}");

            if (choices.IsSuccessStatusCode)
            {
                var choicesString = await choices.Content.ReadAsStringAsync();
                var choicesJson = JsonConvert.DeserializeObject<AssetDTO>(choicesString);
                return choicesJson;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<AssetListDTO>> GetAssetListItems()
        {
            var assets = await _client.GetAsync("/api/getassetlist/Asset");

            if (assets.IsSuccessStatusCode)
            {
                var assetsString = await assets.Content.ReadAsStringAsync();
                var assetsJson = JsonConvert.DeserializeObject<IEnumerable<AssetListDTO>>(assetsString);
                return assetsJson;
            }
            else
            {

                return null;
            }
        }

        public async Task<AssetListDTO> GetAssetListItems(int id)
        {
            var assets = await _client.GetAsync($"/api/getassetlist/Asset/{id}");

            if (assets.IsSuccessStatusCode)
            {
                var assetsString = await assets.Content.ReadAsStringAsync();
                var assetsJson = JsonConvert.DeserializeObject<AssetListDTO>(assetsString);
                return assetsJson;
            }
            else
            {

                return null;
            }
        }


    }
}
