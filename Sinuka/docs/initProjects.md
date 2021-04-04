# Inits

## Sinuka.Web
### Requirements
- Dotnet Core
- MySQL
### Steps
1. Run <code>dotnet restore</code> to add packages
2. Add database to you MySQL server
    1. Change the configuration in <code>Sinuka.Core.Infrastructure.Database.SinukaDbContext</code> and <code>Sinuka.Core.Infrastructure.Database.SinukaDbContextFactory</code> if needed
    2. Change the connection string in <code>Sinuka.Core.Infrastructure.Configs.DbConfig</code>
2. Run <code>dotnet run /seed</code> to add migrations and testing data
2. Run <code>dotnet run</code> to start server

## Sinuka.Web.Accounts
### Requirements
- Same as <code>Sinuka.Web</code>
### Steps
- Same as <code>Sinuka.Web</code>

## Sinuka.Web.Admin
### Requirements
- Same as <code>Sinuka.Web</code>
### Steps
- Same as <code>Sinuka.Web</code>

## Sinuka.Web.Admin.UI
### Requirements
- NodeJS
### Steps
1. Run <code>npm install</code> to install dependencies/packages
2. Run <code>npm run start</code> to start the web server
    1. Run this with HTTPS support, check at https://create-react-app.dev/docs/using-https-in-development/
        - Powershell <code>($env:HTTPS="true") -and (npm run start)</code>

#### Notes
Once you've done the setup for <code>Sinuka.Web</code>, then the setup for <code>Sinuka.Web.Accounts</code> and <code>Sinuka.Web.Admin</code> is simply <code>dotnet restore</code>
