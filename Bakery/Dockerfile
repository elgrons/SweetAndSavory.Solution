
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /Bakery
COPY *.csproj . 
RUN dotnet restore 
COPY . .
RUN dotnet publish -c Release -o /Bakery

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /WebApi
COPY --from=build-env /Bakery .
EXPOSE 80
ENTRYPOINT ["dotnet", "Bakery.dll"] 