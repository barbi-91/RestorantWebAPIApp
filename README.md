# RestorantWebAPIApp   
 
## Setup
1 Update the connection string:   
   - Open `appsettings.json`
   - Set your SQL Server connection string under `"ConnectionStrings": { "DefaultConnection": "Server=localhost;Database=AbySalto;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;" }"`
   
2 Open Visual Studio - Nuget Package Manager Console
   - run command `update-database` to create database with seed data on your server

## Testing
Open Postman and import request-collection from JSON file `RestaurantWebAPI.postman_collection.json`   
   
## Technologies
- ASP.NET Core (.NET 9)
- Entity Framework Core
- AutoMapper