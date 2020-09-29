#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN curl -sL https://deb.nodesource.com/setup_12.x |  bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN curl -sL https://deb.nodesource.com/setup_12.x |  bash -
RUN apt-get install -y nodejs
WORKDIR /src
COPY ["Merchants.Web/Merchants.Web.csproj", "Merchants.Web/"]
RUN dotnet restore "Merchants.Web/Merchants.Web.csproj"
COPY . .
WORKDIR "/src/Merchants.Web"
RUN dotnet build "Merchants.Web.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS migration
WORKDIR /src
COPY . .
RUN dotnet restore "Merchants.Migration/Merchants.Migration.csproj"
COPY . .
WORKDIR "/src/Merchants.Migration"
RUN dotnet build "Merchants.Migration.csproj" -c Release -o /app/migration

FROM build AS publish
RUN dotnet publish "Merchants.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /migration
COPY --from=migration /app/migration .

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Merchants.Web.dll"]