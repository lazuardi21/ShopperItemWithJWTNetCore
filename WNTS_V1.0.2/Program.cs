using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace WNTS_V1._0._2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                     .UseUrls("http://192.168.193.60:4000"); 
                });
    }
}
