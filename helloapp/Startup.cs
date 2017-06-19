using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace helloapp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                System.Console.WriteLine("Dev - enabled ");
       
               app.UseDeveloperExceptionPage();
            }
            else
            {
                System.Console.WriteLine("Dev - disabled");
        
            }
            app.Run(async (arg) =>
            {
                System.Console.WriteLine("Got request on machine: " + System.Environment.MachineName);
                await arg.Response.WriteAsync("Hello World! on " + System.Environment.MachineName);
            }); 
        }
    }
}
