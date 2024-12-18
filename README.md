# NAMSTE_ASP.NET_CORE_WEBAPI
First Project of ASP.NET Core WEBAPI 

# Project Name
- **CoffeeShopWEBAPI**

# This project Include a CRUD Operations
CRUD Operations of Country , State and City Tables

# Database File 
Country_State_City_Tabel_SP_Data.sql file have Create Query of Country , State & City  Tables 
with Dummy Records Insert Query, Also Included All Stored Procedure Like GetAll , GetByID , Insert , Update , Delete of all Tabels.

# Project has Define in 3 folder Sturcture 
- **Model**
  -> Model has CityModel.cs..., file that represent Model file of City table.
- **Controller**
  -> Controller has CityController.cs file that handels Swagger API call for all methods Like GetAll(), GetByID()...,
- **Data**
  -> Data has CityRepositry.cs file has a Configuratons and all methods for CRUD operation Like GetAll() , GetByID() , Insert() , Update() and Delete()
- **Validation**
  -> The project uses **FluentValidation** for validating **Country**, **State**, and **City** models.
  - Validators are defined in the `Validation` folder.
  - FluentValidation is configured in `Program.cs` for dependency injection:
  
  ```csharp
  // Program.cs
  using FluentValidation;
  using FluentValidation.AspNetCore;
  using System.Reflection;
  
  builder.Services.AddControllers()
      .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
  ```


## Running the Project
1. Open the project in your IDE.
2. **Register Repositories**:
   - `builder.Services.AddScoped<StateRepository>();`
   - `builder.Services.AddScoped<CityRepository>();`
   - `builder.Services.AddScoped<CountryRepository>();`
3. Build and run the project.
   
5. **Testing Endpoints**:
   - Use Swagger or an API client (e.g., Postman) to test the endpoints.
  - **-> Testing the Endpoints**
  - Run your project.
    - Use Swagger or an API client (like Postman) to test the CityController endpoints:
    - GET /api/City - Retrieve all City.
    - GET /api/City/{id} - Retrieve a specific City by ID.
    - POST /api/City - Add a new country.
    - PUT /api/City/{id} - Update an existing City.
    - DELETE /api/City/{id} - Delete a v by ID.

#### StateController
- Similar endpoints for **State** CRUD operations.

#### CountryController
- Similar endpoints for **Country** CRUD operations.



