This code contains the .NET Core Web API backend for the Informations Systems course project. To run in your environment, first create an SQL Server database called 'finance', then
create appsettings.json file as follows:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source={YOURPCNAME}\\SQLEXPRESS;Initial Catalog=finance;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "FMPKey": "{KEY_FROM_FINANCIAL MODELLING PREP}",
  "Jwt": {
    "Issuer": "http://localhost:5173",
    "Audience": "http://localhost:5173",
    "SigningKey": "{CUSTOMLONGSIGNINGKEY123}"
  }
}
```
and replace the {} with your own values. A key for financial modelling prep can be obtained here:

https://site.financialmodelingprep.com/

Special thanks to @teddysmithdev for the excellent tutorial
