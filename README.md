# dotnet-api-connection-four
A `.Net 5.0` WebApi project.

# How to run
1. Use this solution or clone/download to your local workplace.
2. Download the latest .Net SDK and Visual Studio.
3. Go to the ConnectionFour\ConnectionFour.Api folder, run ``dotnet build`` and then ``dotnet run`` or in visual studio set the api project as startup and run as console (not IIS).
4. Visit http://localhost:5000/swagger/index.html or https://localhost:5001/swagger/index.html to access the application's swagger. (You can also use Postman)

# This project contains:
- Swagger/OpenApi
- .Net Dependency Injection
- Unit tests

# Project Structure
1. Api
	- This project stores the apis.
2. Model
	- This project contains enums and response models.
3. Service
	- It contains the business logic. It contains the rules and validations of the game.
4. Tests
	- Contains the unit tests of the tests provided in the vier-gewinnt folder

## Running tests
In the root folder, run ``dotnet test``. This command will try to find all test projects associated with the ConnectionFour Solution file.

## Thanks :)