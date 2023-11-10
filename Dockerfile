FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY *.sln ./
COPY ./BankApplication.Application/*.csproj ./BankApplication.Application/
COPY ./BankApplication.Domain/*.csproj ./BankApplication.Domain/
COPY ./BankApplication.Infrastructure/*.csproj ./BankApplication.Infrastructure/
COPY ./BankApplication.Presentation/BankApplication.WebApi/*.csproj ./BankApplication.Presentation/BankApplication.WebApi/
COPY ./BankApplication.Presentation/BankApplication.Contracts/*.csproj ./BankApplication.Presentation/BankApplication.Contracts/
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "BankApplication.dll"]
