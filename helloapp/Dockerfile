#the base image 
FROM microsoft/dotnet:latest

MAINTAINER Matthias Schedel <matze.schedel@gmail.com> 

ENV ASPNETCORE_ENVIRONMENT="Development"

# Required for dotnet-watch to detect file changes
ENV DOTNET_USE_POLLING_FILE_WATCHER=1

#add the content of your local folder to the folder /helloapp in your directory 

ADD . /helloapp/
WORKDIR /helloapp/

# restore the project (load packages referenced in .csproj)  & build the project
RUN ["dotnet", "restore"] 
RUN ["dotnet", "build"] 

# define standard entry point when container boots 
CMD ["dotnet","watch", "run"] 
