FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY DDLiquid.Domain/DDLiquid.Domain.csproj DDLiquid.Domain/
COPY DDLiquid.DataAccess/DDLiquid.DataAccess.csproj DDLiquid.DataAccess/
COPY DDLiquid.BusinessLogic/DDLiquidBusinessLogic.csproj DDLiquid.BusinessLogic/
COPY Control/DDLiquid.API.csproj Control/
COPY DotnetBackEnd.slnx .

RUN dotnet restore

COPY . .
RUN dotnet publish Control/DDLiquid.API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5131
ENTRYPOINT ["dotnet", "DDLiquid.API.dll"]
