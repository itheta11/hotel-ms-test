# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["KamathResidency/KamathResidency.csproj", "KamathResidency/"]
RUN dotnet restore "./KamathResidency/KamathResidency.csproj"

# Copy all files and build
COPY . .
WORKDIR "/src/KamathResidency"
RUN dotnet build "./KamathResidency.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish image
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./KamathResidency.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app

# Copy published app
COPY --from=publish /app/publish .

# Ensure the /app/Database/ directory exists and set permissions
RUN mkdir -p /app/Database && chmod -R 755 /app/Database

# Copy the SQLite database file to the /app/Database/ directory
COPY KamathResidency/Database/KamathResidency.db /app/Database/KamathResidency.db

ENTRYPOINT ["dotnet", "KamathResidency.dll"]
