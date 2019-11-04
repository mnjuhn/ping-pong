# PingPong


## Dev Environment

This program was edited in Visual Studio 2019 with .NET core installed. As well as AspNetCore.Cors v 2.2.0, AspNetCore.Mvc.NewtonsoftJson v 3.0.0, EntityFrameworkCore.SqlServer v 3.0.0, EntityFrameworkCore.Tools v 3.0.0,
TypeScript.Compiler v 3.1.5, Configuration.ConfigurationManager v 4.6.0, and System.Data.SqlClient.

It used MS-SQL Server 2017 set up with a a grant all system user with no username and password and a database named pingpong.

## Setting up data models via Entity Framework

The data migration files were added to source control and can be run to construct the Ping Pong table by running `Update-Database -v` in Visual Studio's Package manager.

## Running the .Net server and angular client

In the root folder from the command line (using Git Bash) run the following in two different terminals: `dotnet run` and `ng serve`.  This should run the .NET server on
port 5000 and the angular client on port 4200. Navigate to `http://localhost:4200/player` to see a list of players which you can edit or delete.

## Running unit tests

There is only 1 component unit test which tests the total number of users and the first user from the pre-generated data structure. Run `ng test` to accomplish this.

Lastly all files were stored in git with linux style end of line charaters which must be converted to windows on checkout.