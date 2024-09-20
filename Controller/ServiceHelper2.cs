using AuthenCard.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AuthenCard.Controller
{
    public class ServiceHelper2
    {
        private static Uri DataBaseAddress {get; set;} = new Uri("http://localhost:5094");
        public async static Task<LoginHos> GetLogin(string username, string password)
        {
            

            var client = new HttpClient();
            client.BaseAddress = DataBaseAddress;
            var response = await client.GetAsync("api/Hos/getUser?uname=" + username+ "&para=" + password);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var json = await response.Content.ReadAsStringAsync();
            //return  JsonConvert.DeserializeObject<List<Cid>>(json);
            // return JArray.Parse(json).ToObject<List<Cid>>();
            return JsonConvert.DeserializeObject<LoginHos>(json);
             

        }
        else return new LoginHos();
        }
    }
}