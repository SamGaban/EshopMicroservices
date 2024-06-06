#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["Services/Catalog/Catalog.API/Catalog.API.csproj", "Services/Catalog/Catalog.API/"]
#COPY ["BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/BuildingBlocks/"]
#RUN dotnet restore "Services/Catalog/Catalog.API/Catalog.API.csproj"
#COPY . .
#WORKDIR "/src/Services/Catalog/Catalog.API"
#RUN dotnet build "Catalog.API.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "Catalog.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Catalog.API.dll"]


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 8443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY Services/Catalog/Catalog.API/Catalog.API.csproj Services/Catalog/Catalog.API/
COPY BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj /BuildingBlocks/BuildingBlocks/
RUN dotnet restore Services/Catalog/Catalog.API/Catalog.API.csproj
COPY . .
WORKDIR /src/Services/Catalog/Catalog.API
RUN dotnet build Catalog.API.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish Catalog.API.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

# Copy SSL certificates from the build context
COPY ssl-certs/your_certificate.pfx /app/ssl-certs/your_certificate.pfx
COPY ssl-certs/your_certificate.crt /app/ssl-certs/your_certificate.crt

# Set environment variables for ASP.NET Core
ENV ASPNETCORE_URLS="https://+:8443;http://+:8080"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path="/app/ssl-certs/your_certificate.pfx"
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="your_certificate_password"

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Catalog.API.dll"]
