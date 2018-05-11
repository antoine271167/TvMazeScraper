# TvMaze WebAPI Scraper
This is an example project that demonstrates how you can scrape a webapi in C# and store its data in a SQL database.
The webapi we use is 'http://www.tvmaze.com/api'. With this you can request data about TV shows. This example project consists of a Windows Service based on Topshelf. Periodically a job starts that downloads data from the webapi. We store these via the Entity Framework in a sql database.
There is also a MVC WebAPI project that reads out the data and offers paging. Enclosed is a database project from which we can publish the database to an SQL server. The url of the webapi is 'host / api / shows'.
## Architecture
The application is designed 
The application is designed according to DDD architecture with an Application, Domain and Infra layer. The highest level is the application layer. This contains a number of commands to retrieve, store and manipulate data. The domain layer contains a number of poco's that describe the domain structure of the data. Finally, there is the Infra layer that contains storage, web clients and repositories.
