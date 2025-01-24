# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KamathResidency/KamathResidency.csproj", "KamathResidency/"]
RUN dotnet restore "KamathResidency/KamathResidency.csproj"
COPY . .
WORKDIR "/KamathResidency"
RUN dotnet build "KamathResidency.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KamathResidency.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KamathResidency.dll"]
