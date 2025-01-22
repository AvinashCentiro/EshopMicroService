Domain Analysis:-

1.Determine Domain Models
2.Determine Application Use Cases of Catalog MicroService
   2.1 CRUD Catalog Operation
  
3.Determine REST API EndPoints
4.Underlying DataStructure
  4.1 Document Db in order to store catalog json Data -->we chosen PostgreSQL with Marten Library.
---------------------------------------------------------------------------------------------------------
Technical Analysis:-

-Before Below steps do proper technical analysis like Architecture style,Patterns and principles ,libabries Nuget packages
Project Folder Structure

---------------------------------------------------------------------------------------------------------
Step 1: Create Catalog Folder Under Services and add ASP.NET Core Empty project type for Catalog.API with docker support option 
Step 2: Create Models for this Microservice
Step 3: Create Folder for CatalogEndPoints with proper naming like GetCatalog,DeleteCatalog,..etc
Step 4: Add Endpoint and handler class files using Mediator 