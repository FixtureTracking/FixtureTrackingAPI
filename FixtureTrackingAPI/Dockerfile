FROM mcr.microsoft.com/dotnet/aspnet:5.0

MAINTAINER Mustafa CEVIK <se.mustafacevik@gmail.com>

COPY bin/Release/net5.0/publish/ app/
WORKDIR /app

ENTRYPOINT ["dotnet", "FixtureTrackingAPI.dll"]