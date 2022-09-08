
using System.Net;
using Webserver;
using Tiger;
using GenderTiger;
using System_Integration_A2.Entities;



internal class Program {

    public static string SendResponse(HttpListenerRequest request)
    {
        return string.Format("<HTML><BODY>wrgoerbgrihriuhgb.<br>{0}</BODY></HTML>", DateTime.Now);
    }

    
    static async Task Main(string[] args)
    {
        /*
        var person = new Person("Lars", "lars@gmail.com", "194.62.169.90");
        var getIp = new IpInfo();
        var personCountryCode= getIp.GetCountryCodeOnIP(person.IP);*/

        // LQ3YexQLXBmFjXgU5LvBS5hGBPUjTNAcVqUX

        var api = new GenderApi("LQ3YexQLXBmFjXgU5LvBS5hGBPUjTNAcVqUX");
        Console.WriteLine(await api.GetGenderByName("Frank Nielsen"));
        /*
        var ws = new WebServer(SendResponse, "http://localhost:8080/test/");
        ws.Run();
        Console.WriteLine("A simple webserver. Press a key to quit.");
        Console.ReadKey();
        ws.Stop();*/
    }
}


/*
 Liste af dudes via SOAP
   
*/