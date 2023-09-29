FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["WeatherForecastProcessor/WeatherForecastProcessor.csproj", "WeatherForecastProcessor/"]
RUN dotnet restore "WeatherForecastProcessor/WeatherForecastProcessor.csproj"
COPY . .
WORKDIR "/src/WeatherForecastProcessor"
RUN dotnet build "WeatherForecastProcessor.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "WeatherForecastProcessor.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherForecastProcessor.dll"]
