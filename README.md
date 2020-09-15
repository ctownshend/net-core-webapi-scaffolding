# ASP.NET Core WebAPI scaffolding

This is a scaffolding for creating an ASP.NET Core WebAPI with a Microsoft SQL Server database. It comes with my preferred dependencies:
- EntityFramework
- Automapper
- Swagger

This tutorial will walk you through the steps to install docker and load an SQLServer, create a database and connect it to use with the WebAPI.

## 1- Installing Docker

- For [Mac](https://store.docker.com/editions/community/docker-ce-desktop-mac)
- For [Windows](https://hub.docker.com/editions/community/docker-ce-desktop-windows)
- For [Linux and others](https://hub.docker.com/search?q=&type=edition&offering=community)

## 2- Pulling the SQLServer container 
``` 
docker pull microsoft/mssql-server-linux:2017-latest
```

## 3- Creating an SQL Server instance 
```
docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Password123' -p
1401:1433 --name sqlserver1 -d microsoft/mssql-server-linux:2017-latest
```
This will create an instance called sqlserver1, with user 'sa' and password 'Password123' running in localhost port 1401.
Connect to it with your favourite database manager. In this case we will use [Azure Data Studio](https://github.com/microsoft/azuredatastudio). Download the version for your OS.

## 4- Creating the database
Connect to the database with Azure Data Studio using the server as localhost, username 'sa', password 'Password123' and port 1401. 
Open a new query and copy paste the following:

```
CREATE DATABASE MyMiscelaneousDatabase;
GO
USE MyMiscelaneousDatabase
-- Create a new table called '[Thing]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Thing]', 'U') IS NOT NULL
DROP TABLE [dbo].[Thing]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Thing]
(
    [Id] INT NOT NULL PRIMARY KEY, -- Primary Key column
    [Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(200),
    [Price] Decimal(10,2)
);
GO
``` 

## 5a- Running the project (in Visual Studio)
You are all set to start, just set the WebAPI project as the "start up project" and start debugging.
Once it opens the browser, go to 
```
https://localhost:40890/swagger/index.html
```

## 5b- Running the project (using Docker)
--work in progress-- I still need to define how to access the SQL Server from one container to the other.
To run this project in a container, we need to first build the docker image.  
Open a terminal/command line and go to the root folder of the project, where the Dockerfile is.
Enter the following
```
docker build -t webapiapp .
```
Once the image is built, we need to run it:
```
docker run -d -p 8080:80 --name mynewwebapi webapiapp
```
This will let us access web api running from the container in this address
```
http:\\localhost:8080
```

## *optional: Regenerating the db model
If you need to regenerate the db model, open a terminal and go to the DAL project folder. Execute this command:
```
dotnet ef dbcontext Scaffold "Server=localhost,1401;Initial Catalog=MyMiscelaneousDatabase;
Persist Security Info=False;User ID=sa;Password=Password123;
MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;"
Microsoft.EntityFrameworkCore.SqlServer -o Models
```
This will create the new model classes and database context with updated details from the database.

## License
[MIT](https://choosealicense.com/licenses/mit/)
