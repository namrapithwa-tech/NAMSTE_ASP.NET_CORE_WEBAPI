# NAMSTE_ASP.NET_CORE_WEBAPI
First Project of ASP.NET Core WEBAPI 

# Project Name
- CoffeeShopWEBAPI

# This project Include a CRUD Operations
CRUD Operations of Country , State and City Tables

# Database File 
Country_State_City_Tabel_SP_Data.sql file have Create Query of Country , State & City  Tables 
with Dummy Records Insert Query, Also Included All Stored Procedure Like GetAll , GetByID , Insert , Update , Delete of all Tabels.

# Project has Define in 3 folder Sturcture 
- Model
  -> Model has CityModel.cs..., file that represent Model file of City table.
- Controller
  -> Controller has CityController.cs file that handels Swagger API call for all methods Like GetAll(), GetByID()...,
- Data
  -> Data has CityRepositry.cs file has a Configuratons and all methods for CRUD operation Like GetAll() , GetByID() , Insert() , Update() and Delete()

# Run Project 
// Program.cs
//Register CityRepository in the dependency injection container.
  builder.Services.AddScoped<StateRepository>();
-> Testing the Endpoints
  - Run your project.
    - Use Swagger or an API client (like Postman) to test the CityController endpoints:
    - GET /api/City - Retrieve all City.
    - GET /api/City/{id} - Retrieve a specific City by ID.
    - POST /api/City - Add a new country.
    - PUT /api/City/{id} - Update an existing City.
    - DELETE /api/City/{id} - Delete a v by ID.
