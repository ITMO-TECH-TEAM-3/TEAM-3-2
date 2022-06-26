FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app

COPY ./WebApplication1/ ./
RUN dotnet dev-certs https --trust
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 5000
EXPOSE 5001

ENTRYPOINT ["dotnet", "WebApplication1.dll"]
