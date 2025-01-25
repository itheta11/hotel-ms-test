FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["KamathResidency/KamathResidency.csproj", "KamathResidency/"]
RUN dotnet restore "./KamathResidency/KamathResidency.csproj"
COPY . .
WORKDIR "/src/KamathResidency"
RUN dotnet build "./KamathResidency.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./KamathResidency.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["KamathResidency/Database/KamathResidency.db", "/app/Database/KamathResidency.db"]
RUN mkdir -p /app/Database && chmod -R 777 /app/Database

ENTRYPOINT ["dotnet", "KamathResidency.dll"]