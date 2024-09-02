FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "CustomerDomainService.csproj"

WORKDIR "/src"
RUN dotnet build "CustomerDomainService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerDomainService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerDomainService.dll"]
