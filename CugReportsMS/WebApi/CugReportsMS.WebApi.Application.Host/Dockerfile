FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ReportingFramework.WebApp.Application.Host/ReportingFramework.WebApp.Application.Host.csproj", "ReportingFramework.WebApp.Application.Host/"]
RUN dotnet restore "ReportingFramework.WebApp.Application.Host/ReportingFramework.WebApp.Application.Host.csproj"
COPY . .
WORKDIR "/src/ReportingFramework.WebApp.Application.Host"
RUN dotnet build "ReportingFramework.WebApp.Application.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReportingFramework.WebApp.Application.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReportingFramework.WebApp.Application.Host.dll"]
