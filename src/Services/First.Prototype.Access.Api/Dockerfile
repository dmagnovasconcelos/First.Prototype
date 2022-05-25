#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/First.Prototype.Access.Api/First.Prototype.Access.Api.csproj", "src/Services/First.Prototype.Access.Api/"]
RUN dotnet restore "src/Services/First.Prototype.Access.Api/First.Prototype.Access.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/First.Prototype.Access.Api"
RUN dotnet build "First.Prototype.Access.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "First.Prototype.Access.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "First.Prototype.Access.Api.dll"]