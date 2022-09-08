using Newtonsoft.Json.Linq;
using System.Net;

namespace Tiger {
    public class IpInfo
    {
        public string GetCountryCodeOnIP(string IP)
        {
            //var url = "http://freegeoip.net/json/" + IP;
            //var url = "http://freegeoip.net/json/" + IP;
            string url = "http://ip-api.com/json/" + IP;

            var request = WebRequest.Create(url);

            using (WebResponse wrs = request.GetResponse())
            {
                using (Stream stream = wrs.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        var obj = JObject.Parse(json);
                        
                        string CountryCode = (string)obj["countryCode"];
                       

                        return CountryCode;
                    }
                }
            }
        }
    }
}

