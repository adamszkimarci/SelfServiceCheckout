# SelfServiceCheckout

This is a .NET Web API project with the following specifications:

 -  Uses Entity Framework (code-first approach)as ORM
 - The stock of the self-service checkout machine is stored in an MSSQL database.
 - The machine only accepts HUF.
 - The project uses Unit of Work pattern
 
 Packages used:
 
 - Microsoft.EntityFrameworkCore (v6.0.7) - ORM
 - Microsoft.EntityFrameworkCore.Design (v6.0.7) - Supports migrations
 - Microsoft.EntityFrameworkCore.SqlServer (v6.0.7) - Supports MSSQL Server connection
 - Swashbuckle.AspNetCore (v6.2.3) - Swagger
 
 To run the project you will need to:

- Stand in the ./SelfServiceCheckout directory and enter 'dotnet run' / 'dotnet watch run' in the console

OR

- Open the solution in Visual Studio and press the 'Play' button.

