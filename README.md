[![dotnet](https://github.com/jimmytsoares/Truck/actions/workflows/dotnet.yml/badge.svg)](https://github.com/jimmytsoares/Truck/actions)

# Truck
A sample project that uses [Clean Architecture](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html). It consists of 4 application projects and 2 test projects.

## Dependencies
- .NET 5

## Applications
- Truck.Core:  The center of the architecture, contains entities, interfaces, DTOs.
- Truck.Infrastructure: Contains dependencies on external resources, such as the database context. It implements interfaces defined in Core.
- Truck.API: An API that uses the interfaces and implementations from the Core and Infrastructure projects.
- Truck.Web: A WebApp that uses Razor Pages to do the same things as the API but with an interface.

## Tests
- Truck.UnitTests
- Truck.IntegrationTests
