using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace mlb.Helpers
{
  public class JsonHelpers
  {
    public async Task<JObject> MakeRequestAndParseToJson(HttpClient client, string requestUrl)
    {
      try
      {
        var response = await client.GetAsync(requestUrl);
        var responseString = await response.Content.ReadAsStringAsync();
        var jsonRes = JsonConvert.DeserializeObject(responseString);
        return JObject.Parse(responseString);
      }
      catch (Exception ex)
      {
        throw ex;
      }
     }
  }
}
