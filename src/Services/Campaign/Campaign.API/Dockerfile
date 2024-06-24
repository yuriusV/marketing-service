#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Campaign/Campaign.API/Campaign.API.csproj", "Services/Campaign/Campaign.API/"]
COPY ["BuildingBlocks/Common.Logging/Common.Logging.csproj", "BuildingBlocks/Common.Logging/"]
COPY ["Services/Campaign/Campaign.Application/Campaign.Application.csproj", "Services/Campaign/Campaign.Application/"]
COPY ["Services/Campaign/Campaign.Domain/Campaign.Domain.csproj", "Services/Campaign/Campaign.Domain/"]
COPY ["Services/Campaign/Campaign.Infrastructure/Campaign.Infrastructure.csproj", "Services/Campaign/Campaign.Infrastructure/"]
RUN dotnet restore "./Services/Campaign/Campaign.API/./Campaign.API.csproj"
COPY . .
WORKDIR "/src/Services/Campaign/Campaign.API"
RUN dotnet build "./Campaign.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Campaign.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Campaign.API.dll"]