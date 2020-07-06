#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SharesCalculator/SharesCalculator.Api.csproj", "SharesCalculator/"]
COPY ["SharesCalculator.Business/SharesCalculator.Business.csproj", "SharesCalculator.Business/"]
COPY ["SharesCalculator.Data/SharesCalculator.Data.csproj", "SharesCalculator.Data/"]
COPY ["SharesCalculator.Models/SharesCalculator.Models.csproj", "SharesCalculator.Models/"]
RUN dotnet restore "SharesCalculator/SharesCalculator.Api.csproj"
COPY . .
WORKDIR "/src/SharesCalculator"
RUN dotnet build "SharesCalculator.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SharesCalculator.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SharesCalculator.Api.dll"]