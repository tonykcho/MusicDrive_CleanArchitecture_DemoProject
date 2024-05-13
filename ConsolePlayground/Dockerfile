FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ConsolePlayground/ConsolePlayground.csproj", "ConsolePlayground/"]
RUN dotnet restore "ConsolePlayground/ConsolePlayground.csproj"
COPY . .
WORKDIR "/src/ConsolePlayground"
RUN dotnet build "ConsolePlayground.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ConsolePlayground.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsolePlayground.dll"]
