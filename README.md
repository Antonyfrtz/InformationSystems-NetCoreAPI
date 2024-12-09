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

The site supports admin and user roles. Admins can also delete comments made by users on specific stocks. To change the user type created by the register endpoint:

In TokenService (line 27):
```
claims.Add(new Claim(ClaimTypes.Role, "Admin"));
```
And in AccountController:

```
var roleResult = await _userManager.AddToRoleAsync(user, "Admin");
```

![image](https://github.com/user-attachments/assets/0e7e85b6-c682-40b6-b532-d0dd19b39fb6)

![image](https://github.com/user-attachments/assets/38b1d0ca-e764-4e11-9bcc-c40327e0802e)





Special thanks to @teddysmithdev for the excellent tutorial
