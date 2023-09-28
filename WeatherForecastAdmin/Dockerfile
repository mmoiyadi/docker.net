FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["WeatherForecastAdmin/WeatherForecastAdmin.csproj", "WeatherForecastAdmin/"]
RUN dotnet restore "WeatherForecastAdmin/WeatherForecastAdmin.csproj"
COPY . .
WORKDIR "/src/WeatherForecastAdmin"
RUN dotnet build "WeatherForecastAdmin.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "WeatherForecastAdmin.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherForecastAdmin.dll"]
