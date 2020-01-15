#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ComedyHub.Host/ComedyHub.Host.csproj", "ComedyHub.Host/"]
COPY ["ComedyHub.Core/ComedyHub.Core.csproj", "ComedyHub.Core/"]
COPY ["ComedyHub.Model/ComedyHub.Model.csproj", "ComedyHub.Model/"]
RUN dotnet restore "ComedyHub.Host/ComedyHub.Host.csproj"
COPY . .
WORKDIR "ComedyHub.Host"
RUN dotnet build "ComedyHub.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ComedyHub.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ComedyHub.Host.dll
