#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Examples/FluentLocalization.WebApi/FluentLocalization.WebApi.csproj", "Examples/FluentLocalization.WebApi/"]
RUN dotnet restore "Examples/FluentLocalization.WebApi/FluentLocalization.WebApi.csproj"
COPY . .
WORKDIR "/src/Examples/FluentLocalization.WebApi"
RUN dotnet build "FluentLocalization.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FluentLocalization.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluentLocalization.WebApi.dll"]
