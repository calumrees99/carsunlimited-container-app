#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CarsUnlimited.CartAPI/CarsUnlimited.CartAPI.csproj", "CarsUnlimited.CartAPI/"]
COPY ["CarsUnlimited.Shared/CarsUnlimited.Shared.csproj", "CarsUnlimited.Shared/"]
RUN dotnet clean "CarsUnlimited.CartAPI/CarsUnlimited.CartAPI.csproj"
RUN dotnet restore "CarsUnlimited.CartAPI/CarsUnlimited.CartAPI.csproj"
COPY . .
WORKDIR "/src/CarsUnlimited.CartAPI"
RUN dotnet build "CarsUnlimited.CartAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarsUnlimited.CartAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarsUnlimited.CartAPI.dll"]