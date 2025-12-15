FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app

EXPOSE 8080
EXPOSE 8081
EXPOSE 3000

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Directory.Build.props", "."]
COPY ["TickDone.Core/TickDone.Core.csproj", "TickDone.Core/"]
COPY ["TickDone.Infrastructure/TickDone.Infrastructure.csproj", "TickDone.Infrastructure/"]
COPY ["TickDone.API/TickDone.API.csproj", "TickDone.API/"]
RUN dotnet restore "./TickDone.API/TickDone.API.csproj"
COPY . .
WORKDIR "/src/TickDone.API"
RUN dotnet build "./TickDone.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TickDone.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TickDone.API.dll"]