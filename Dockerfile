FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /app
COPY Bakery/*.csproj ./Bakery/
RUN dotnet restore Bakery
COPY . .
RUN dotnet publish -c Release -o out Bakery

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "Bakery.dll"]