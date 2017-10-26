Set development environment:
Why: 
1. To show dev-exception page: [Link here](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling#the-developer-exception-page)
2. [More:](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments)

Change code in Startup.cs file:
```
using using Microsoft.AspNetCore.Hosting;

…

public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
    {
         System.Console.WriteLine(“Dev  - enabled ");
        app.UseDeveloperExceptionPage();
    }
    else
    {
        System.Console.WriteLine(“Dev  - disabled");
    }

…
```


```$ docker-compose  - -build ```

Type: `0.0.0.0:5000` in browser -> check console 

Add the following lines in Dockerfile
```
# After MAINTAINER in Dockerfile
ENV ASPNETCORE_ENVIRONMENT=“Development"
```

```$ docker-compose  --build ```

Type: `0.0.0.0:5000` in browser -> check console  -> dev changed 



