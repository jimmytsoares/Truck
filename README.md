[![dotnet](https://github.com/jimmytsoares/Truck/actions/workflows/dotnet.yml/badge.svg)](https://github.com/jimmytsoares/Truck/actions)

# Truck
A sample project that uses [Clean Architecture](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html). It consists of 4 application projects and 2 test projects.

## Dependencies
- .NET 5

## How to run
### Command line or Powershell
Go to the project folder and type one of the following commands:
```powershell
dotnet test .\Truck.API.sln
dotnet run --project .\src\Truck.API\Truck.API.csproj
dotnet run --project .\src\Truck.Web\Truck.Web.csproj
```
The first will run the tests of the project, the other two will start the web apps.

### Visual Studio
To run the tests, simply open the solution, go to the Test menu and click on 'Run All Tests' or use the shortcut Ctrl+R,A. For the web apps, set the project as the startup project and start the debug.

## Applications
- Truck.Core:  The center of the architecture, contains entities, interfaces, DTOs.
- Truck.Infrastructure: Contains dependencies on external resources, such as the database context. It implements interfaces defined in Core.
- Truck.API: An API that uses the interfaces and implementations from the Core and Infrastructure projects.
- Truck.Web: A WebApp that uses Razor Pages to do the same things as the API but with an interface.

## Tests
- Truck.UnitTests
- Truck.IntegrationTests
