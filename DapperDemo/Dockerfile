FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DapperDemo/DapperDemo.csproj", "DapperDemo/"]
RUN dotnet restore "DapperDemo/DapperDemo.csproj"
COPY . .
WORKDIR "/src/DapperDemo"
RUN dotnet build "DapperDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DapperDemo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DapperDemo.dll"]
