using System;
using System.Xml.Linq;

namespace System_Integration_A2
{
    public class PhoneCodeSOAPService
    {
        private String url;

        public PhoneCodeSOAPService(String url = "http://webservices.oorsprong.org/websamples.countryinfo/CountryInfoService.wso")
        {
            this.url = url;
        }

        public async Task<String> GetPhoneCodeExtensionByCountryCode(String countryCode)
        {
            var body =
                string.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <CountryIntPhoneCode xmlns=""http://www.oorsprong.org/websamples.countryinfo"">
                      <sCountryISOCode>{0}</sCountryISOCode>
                    </CountryIntPhoneCode>
                  </soap:Body>
                </soap:Envelope>", countryCode);
            var client = new HttpClient();
            var request = new StringContent(body);
            request.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/xml");
            var response = await client.PostAsync(this.url, request);

            return this.Parse(await response.Content.ReadAsStringAsync());
        }

        private String Parse(String response)
        {
            var xdoc = XDocument.Parse(response);
            XNamespace ns = "http://www.oorsprong.org/websamples.countryinfo";
            var element = xdoc.Descendants(ns + "CountryIntPhoneCodeResult").FirstOrDefault()?.Value;
            return element ?? "";
        }
    }
}

