
// Pls check video No 60,61,62 in detail for Postgres configuration and
// docker set up for postgres. IMP is video no 62,63,64 these all are for docker and its configuration and commands.
//i have taken SS in OneNOTE sheet under MIcroservice Notes
/*------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------
File: - docker - compose.yml
comment Created  Date: 25 - 12 - 2024


catalog.api:
image: ${ DOCKER_REGISTRY -}
catalogapi
build:
context: .
dockerfile: Services / Catalog / Catalog.API / Dockerfile
commented becoz we are initially debugging locally so will configure this as per our setup/needs.

------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------

File Name:-override.Yaml
In this override.yaml file, we generally set up the environment variables, port mappings, and volume
mappings for our PostgreSQL services or any kind of the services that we define in the docker compose file.


------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------
  File Name:-docker-compose.Override.yml 

catalog.api:
   environment:
     - ASPNETCORE_ENVIRONMENT=Development
     - ASPNETCORE_HTTP_PORTS=8080
     - ASPNETCORE_HTTPS_PORTS=8081
   ports:
     - "8080"
     - "8081"
   volumes:
     - ${APPDATA}/Microsoft/UserSecrets:/home/app/.microsoft/usersecrets:ro
     - ${APPDATA}/ASP.NET/Https:/home/app/.aspnet/https:ro
------------------------------------------------------------------------------------------------------------
So in order to interact with these PostgreSQL database we will use Docker commands to access the containers,
bash shell scripts and connect to the database using the SQL command line interface.   
So for that purpose I'm going to open a command window.
 
------------------------------------------------------------------------------------------------------------------------

Docker Compose:-

Docker Compose is a tool for defining and running multi-container Docker applications. It uses a YAML file (docker-compose.yml) 
to configure the services, networks, and volumes needed for the application. 
With a single command, you can start all the services defined in the configuration, simplifying the management of complex applications.

We can add Containers into our Docker Compose yaml Files.
There are multiple services, including databases on message brokers we can  define in Docker Compose File.
   
   docker-compose.yml file.

Docker Compose Up Command will retrieve containers from Docker Hub  and configure our container with these configurations 


How to add Any Image into Docker compose file for multi Container Docker environment

 */
