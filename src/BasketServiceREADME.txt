Domain Analysis:-

1.Determine Domain Models
2.Determine Application Use Cases of Basket MicroService
   2.1 CRUD Basket Operation
   2.2 gRPC Basket Operations--> we can add discounts to items using gRPC ,deduct discount coupon from item price
   2.3 Async Basket Operation-> checkout basket and publish event to RabbitMQ
   
3.Determine REST API EndPoints
4.Underlying DataStructure
  4.1 basket Microservice has 2 datastore  1. Marten Document DB  2. Redis distributed Cache 
---------------------------------------------------------------------------------------------------------
Technical Analysis:-

-Before Below steps do proper technical analysis like Architecture style,Patterns and principles ,libabries Nuget packages
Project Folder Structure

---------------------------------------------------------------------------------------------------------
Step 1: Create Basket Folder Under Services and add ASP.NET Core Empty project type for Basket.API with docker support option 
Step 2: Create Models for this Microservice
Step 3: Create Folder for BasketEndPoints with proper naming like GetBasket,DeleteBansket,..etc
Step 4: Add Endpoint and handler class files using Mediator 
Step 5: Add dependencies like mediator,Carten in program.cs 