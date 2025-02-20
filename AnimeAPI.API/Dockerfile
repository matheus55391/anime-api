# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AnimeAPI.API/AnimeAPI.API.csproj", "AnimeAPI.API/"]
COPY ["AnimeAPI.Application/AnimeAPI.Application.csproj", "AnimeAPI.Application/"]
COPY ["AnimeAPI.Domain/AnimeAPI.Domain.csproj", "AnimeAPI.Domain/"]
COPY ["AnimeAPI.Infrastructure/AnimeAPI.Infrastructure.csproj", "AnimeAPI.Infrastructure/"]
RUN dotnet restore "./AnimeAPI.API/AnimeAPI.API.csproj"
COPY . .
WORKDIR "/src/AnimeAPI.API"
RUN dotnet build "./AnimeAPI.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AnimeAPI.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AnimeAPI.API.dll"]