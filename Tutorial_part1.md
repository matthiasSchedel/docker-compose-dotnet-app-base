Install Requirements:  
1. Install Docker:[Link here](https://www.docker.com/products/docker-toolbox)
2. Install pip (if not already installed):[Link here](https://pip.pypa.io/en/stable/installing/#do-i-need-to-install-pip)
3. `$ pip install docker-compose`

OR install docker [directly](https://www.docker.com/products/docker-toolbox)


1. Create a new folder (e.g. Desktop/helloDocker): `$ mkdir helloDocker`
2. $ cd helloDocker
3. Create a new folder for your first dotnet app  `$ mkdir helloApp`
4. Create a docker compose configuration file
5. `$ vi docker-compose.yml` ( OR `$ nano docker-compose.yml` )

docker-compose.yml file:
```
#this is a comment 
version: '3.1' #depends on the version of your docker engine -> check: $ docker —version
services: #every services stands for a single container instance 
  helloapp: #the name of our instance (only lowercase!)
    build: ./helloApp #the build directory containing the app and the Dockerfile 
    ports: #list of ports that will be forwarded to local machine 
     - "5000:5000” #port on local machine:port inside docker container 

```
9. Create the docker file in helloApp directory: `$cd helloApp && vi Dockerfile`

Dockerfile:
```
#the base image 
FROM microsoft/dotnet:latest 

MAINTAINER Matthias Schedel matze.schedel@gmail.com 

#add the content of your local folder to the folder /code in your directory 
ADD . /code 
WORKDIR /code 


# restore the project (load packages referenced in .csproj)  & build the project
RUN ["dotnet", "restore"] 
RUN ["dotnet", "build"] 

# define standard entry point when container boots 
CMD ["dotnet", "run"] 
```

10. Create file Program.cs:
```
// Programm.cs 
using Microsoft.AspNetCore.Hosting;

namespace helloapp
{
    public class Program
    {
        public static void Main(string[] args)
        {  
            var host = new WebHostBuilder()
                .UseUrls("http://0.0.0.0:5000")
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }
}
```

the file Startup.cs:
```
// Startup.cs 
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;


namespace helloapp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (arg) =>
            {
                System.Console.WriteLine("Got reqt on machine: " + System.Environment.MachineName);
                await arg.Response.WriteAsync("Hello World! on " + System.Environment.MachineName);
            }); 
        }
    }
}
```

and the helloapp.csproj file:
```
<!— helloapp.csproj —>
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>netcoreapp1.1</TargetFramework>
  </PropertyGroup>

 <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore" Version="1.1.2" />
    <PackageReference Include="Microsoft.AspNetCore.Server.Kestrel" Version="1.1.2" /> 
  </ItemGroup> 
</Project>
```

11. ```$ cd ..```
12. Start docker daemon in Applications or via cmd
13. `$ docker-compose up` (or "`$ docker-compose up —build`" if you want to rebuild your containers)
