# BaseballApp

The front end part of this project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 8.3.1.
The WebAPI (backend) part of this project was implemented on .net MVC using .net CLI tools as well as .net core 2.2.0. package.

## Tools Used
- Microsoft SQL server 2017 (management tools 2018)
- Visual studio code (make sure dotnet packages are downloaded and installed)
- Angular CLI 8.3.1
- Node v10.16.3
- npm v6.9.0
- Postman

## Setup
- Run the SQL script called BaseballAppDatabase.sql found in "BaseballAppWebAPI" folder. This script will create the database
   along with the table definitions. 
- Create a user that has access to the newly created "BaseballApp" database.
- Once the database is created open the "BaseballAppWebAPI" in visual studio code and go to "appsettings.json". Change the connection string Data source to your corresponding SQL server and the UserID/Password to the user that was created in the previous step.

## Running App

- Open folder "BaseballAppWebAPI" in visual studio code and run `dotnet build` to build the WebAPI.
Once it builds successfully, run the command `dotnet run`. The WebAPI will take 2 - 3 minutes to initialize(seed) the database.

NOTE: If you do come across any errors during the database seeding process, you can use the attached data files to populate the tables. Seeding is only done if either Person, Team or Roster tables are empty.

- Worst case scenario, I've also attached a database backup file so that the database can be restored on your machine.
Once the database has been populated, the API will run on `http://localhost:5000/`. 

- You can use Postman to verify whether the api is running by pulling data using any of the following GET requests:

   - http://localhost:5000/api/position
   - http://localhost:5000/api/venues
   - http://localhost:5000/api/people
   - http://localhost:5000/api/teams   or  http://localhost:5000/api/teams/141
   

- Open folder "BaseballApp" in visual studio code. You'll need to run the following command in order to build the angular app `npm install --save-dev @angular-devkit/build-angular`

- Once that's done, run `ng serve --open`. This command will automatically open your browser and load the app to `http://localhost:4200/` (Make sure Angular CLI tools is installed).
