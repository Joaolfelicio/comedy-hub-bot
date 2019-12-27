using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using ComedyHub.Core.Infrastructure.NineGagModels.Models;
using ComedyHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ComedyHub.Core.Infrastructure.Gateway
{
    public class NineGagGateway : INineGagGateway
    {
        public async Task<NineGagModel> GetMeme()
        {
            NineGagModel jsonModel = new NineGagModel();
            jsonModel = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://9gag.com/v1/group-posts/group/funny/type/trend");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("https://9gag.com/v1/group-posts/group/funny/type/trend");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    jsonModel = JsonConvert.DeserializeObject<NineGagModel>(data);

                    return jsonModel;
                }
            }
            return jsonModel;
        }
    }
}
