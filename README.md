# README

## Abstract

This is a basic implementation of a Rover positioning and control service.

There is a single endpoint implementing the basic movements (F, B, L, R) which returns the new position after processing the command.

For easier viewing this implementation uses Swagger / Swashbuckle so that there is a UI available upon starting the service locally.

## Running the service

Simply press F5 in Visual Studio, or start a terminal and run `dotnet run --project .\src\API\API.csproj`.

## Running the tests

There are both unit tests and end-to-end tests available.

To run the unit tests start a terminal and run `dotnet test`.

To run the end-to-end tests start a terminal and run `dotnet test .\e2e-tests\API.E2ETests\API.E2ETests.sln`.

**Note:** The end-to-end tests only pass once due to the DI registration of the `LocationRepository`

## Deploying the service

Ideally this would contain an azure.yml file with the steps to build, test, and save the artifact.

Due to lack of time this is not possible.

## Notes

There are more assumptions made than is generally advisable due to lack of a PO / Analyst for clarifications, such as:

* there only being a single rover
* slow updates
* no idea about the userbase for this service (caching requirements, # concurrent requests, ...)

The location of the rover is stored as a Stack as this mimics the more applicable event-sourcing approach required when implementing a history.