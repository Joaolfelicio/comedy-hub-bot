using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ComedyHub.Core.Configuration.Contracts;
using ComedyHub.Core.Infrastructure.Gateway.Models.NineGagModels;

namespace ComedyHub.Core.Infrastructure.Gateway
{
    public class NineGagGateway : INineGagGateway
    {
        private readonly INineGagApiSettings _nineGagApiSettings;

        public NineGagGateway(INineGagApiSettings nineGagApiSettings)
        {
            _nineGagApiSettings = nineGagApiSettings;
        }
        public async Task<NineGagModel> GetMeme()
        {
            NineGagModel memeModel = new NineGagModel();
            memeModel = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_nineGagApiSettings.Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(_nineGagApiSettings.Url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    memeModel = JsonConvert.DeserializeObject<NineGagModel>(data);

                    return memeModel;
                }
            }
            return memeModel;
        }
    }
}
