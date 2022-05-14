using AssetManagement.App.GUI.Models.APIModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AssetManagement.App.GUI.Provider
{
    public class AssetPropertyProvider
    {
        private readonly HttpClient _client;

        public AssetPropertyProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<BrandModelDTO>> GetModelsByID(int id)
        {
            var models = await _client.GetAsync($"/api/getmodellistbyid/{id}");

            if (models.IsSuccessStatusCode)
            {
                var modelsString = await models.Content.ReadAsStringAsync();
                var modelsJson = JsonConvert.DeserializeObject<List<BrandModelDTO>>(modelsString);
                return modelsJson;
            }
            else
            {

                return null;
            }
        }

    }
}
