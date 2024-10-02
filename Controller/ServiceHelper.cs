using AuthenCard.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AuthenCard.Controller
{
    public class ServiceHelper
    {
        private static Uri DataBaseAddress {get; set;} = new Uri("http://localhost:8189");
        public async static Task<Cid> GetCid()
        {
            //var param = new Dictionary<string, string>();
            // param.Add("","");
            //var content = new FormUrlEncodedContent(param);

            var client = new HttpClient();
            client.BaseAddress = DataBaseAddress;
            var response = await client.GetAsync("api/smartcard/read-card-only?readImageFlag=false");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                //return  JsonConvert.DeserializeObject<List<Cid>>(json);
                // return JArray.Parse(json).ToObject<List<Cid>>();
                return JsonConvert.DeserializeObject<Cid>(json);
            }
            
            else return new Cid();
        }

        public async static Task<Cid2> GetCidClaim()
        {
            var client = new HttpClient();
            client.BaseAddress = DataBaseAddress;
            var response = await client.GetAsync("api/smartcard/read?readImageFlag=false");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                //return  JsonConvert.DeserializeObject<List<Cid>>(json);
                // return JArray.Parse(json).ToObject<List<Cid>>();
                return JsonConvert.DeserializeObject<Cid2>(json);
            }
            
            else return new Cid2();
        }
    }
}