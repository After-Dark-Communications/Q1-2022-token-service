#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OneTimeAccessService.csproj", "."]
RUN dotnet restore "./OneTimeAccessService.csproj"
COPY . .
WORKDIR "/src/OneTimeAccessService"
RUN dotnet build "OneTimeAccessService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OneTimeAccessService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OneTimeAccessService.dll"]