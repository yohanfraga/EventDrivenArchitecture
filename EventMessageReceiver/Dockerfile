FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EventMessageReceiver/EventMessageReceiver.csproj", "EventMessageReceiver/"]
RUN dotnet restore "EventMessageReceiver/EventMessageReceiver.csproj"
COPY . .
WORKDIR "/src/EventMessageReceiver"
RUN dotnet build "EventMessageReceiver.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EventMessageReceiver.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventMessageReceiver.dll"]
