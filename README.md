# Godzilla Restaurant Website
## General Infomation
**Godzilla Restaurant Website** is created by [ASP.NET MVC](https://dotnet.microsoft.com/en-us/apps/aspnet/mvc). The website was created as an online information page about restaurants, and also helps simplify ordering and booking tables online. In addition, the restaurant admin can manage information such as menu, online order/booking as well as other information displayed on the website.
Live Demo: https://godzillarestaurant.azurewebsites.net
## Technologies
Project is created with:
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
* [.NET 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
* [PostgreSQL 16.1](https://www.postgresql.org/)
* [Microsoft Azure](https://azure.microsoft.com/en-us)
## Setup
To run this project locally:
* Open Project with [Visual Studio 2022](https://visualstudio.microsoft.com/vs/).
* Create file `appsettings.json` and add `ConnectionString` to Database.
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "AppDBConnection": "<your-connection-string>"
  }
}
```
* Create file `.env` to store email address and password (used for account registration/password change).
```
EMAIL_ADDRESS=<your-email-address>
EMAIL_PASSWORD=<your-email-password>
```
* Build Project.
