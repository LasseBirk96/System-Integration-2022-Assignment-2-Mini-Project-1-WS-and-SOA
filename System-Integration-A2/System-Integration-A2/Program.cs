using System.Net;
using Tiger;
using GenderTiger;
using System_Integration_A2;


internal class Program
{
    public static async Task<String> GenerateInvitationBasedOnUserInformation(string name, string ip)
    {
            var title = "";
            var api = new GenderApi("LQ3YexQLXBmFjXgU5LvBS5hGBPUjTNAcVqUX");
            var IpData = new IpInfo();
            var countryCode = IpData.GetCountryCodeOnIP(ip);
            var gender = await api.GetGenderByName(name, countryCode);
            if (gender is "male") {
                title = "Mr.";
            }
            if (gender is "female") {
                title = "Ms.";
            }
            if (gender is not "male" or "female") {
            title = "";
            }

            var soapAPI = new PhoneCodeSOAPService();
            var extension = await soapAPI.GetPhoneCodeExtensionByCountryCode(countryCode);
            string invitation = String.Format("Dear {0}{1},\nYou are hereby invited to the annual sales report meeting. " +
            "This year has been great for the company, and attached you can see this years report.\n" +
            "If you can't make it to the event please call this number to cancel: +{2} 1234567.", title, name, extension);
            return invitation;
    }


       static async Task Main(string[] args) {
       // This can then be repeated for a list of people, whoever this is just to provide proof of concept
       var invitation = await GenerateInvitationBasedOnUserInformation("Frank Nielsen", "195.215.220.254");
       Console.WriteLine(invitation);
       }
}