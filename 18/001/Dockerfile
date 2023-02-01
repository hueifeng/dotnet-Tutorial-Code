FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS publish
WORKDIR /app
COPY . .

RUN dotnet publish -c Release -o output

FROM base AS final
WORKDIR /app
COPY --from=publish /app/output .
ENTRYPOINT ["dotnet", "app.dll"]
