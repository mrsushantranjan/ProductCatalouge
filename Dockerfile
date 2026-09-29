# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Restore NuGet dependencies
COPY ["ProductCatalogueApp.csproj", "./"]
RUN dotnet restore "ProductCatalogueApp.csproj"

# Copy source and publish release build
COPY . .
RUN dotnet publish "ProductCatalogueApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose standard cloud container port
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "ProductCatalogueApp.dll"]
