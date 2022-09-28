#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Challenge.API/Challenge.API.csproj", "src/Challenge.API/"]
COPY ["src/Challenge.Application/Challenge.Application.csproj", "src/Challenge.Application/"]
COPY ["src/Challenge.Infra.Data/Challenge.Infra.Data.csproj", "src/Challenge.Infra.Data/"]
COPY ["src/Challenge.Domain/Challenge.Domain.csproj", "src/Challenge.Domain/"]
RUN dotnet restore "src/Challenge.API/Challenge.API.csproj"
COPY . .
WORKDIR "/src/src/Challenge.API"
RUN dotnet build "Challenge.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Challenge.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Challenge.API.dll"]
