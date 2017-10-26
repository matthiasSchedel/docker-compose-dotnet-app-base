Dotnet core file Watcher: 

Add the following lines in docker-compose.yml file
```
volumes:
     - ./helloapp/Program.cs:/helloapp/Program.cs
     - ./helloapp/Startup.cs:/helloapp/Startup.cs
```

Add the following lines in helloapp.crproj file
```  
    <ItemGroup>
     <DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="1.0.0" />
```
Add the following lines in Dockerfile
```
# Required for dotnet-watch to detect file changes
ENV DOTNET_USE_POLLING_FILE_WATCHER=1

CMD ["dotnet","watch", "run”] # change the last line
```


