# ==========================
# Etapa base
# ==========================
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS base

WORKDIR /app

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

# ==========================
# Etapa de compilación
# ==========================
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["EmpresaModularAPI.csproj", "./"]

RUN dotnet restore "EmpresaModularAPI.csproj"

COPY . .

RUN dotnet publish "EmpresaModularAPI.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false

# ==========================
# Imagen final
# ==========================
FROM base AS final

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "EmpresaModularAPI.dll"]