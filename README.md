# EA Music Festival Solution

A simple web app that displays band record labels, bands, and music festivals from a third party API providing the data.

At the top level, it displays the band record label, below that it lists out all bands under their management, and below that it displays which festivals they've attended, if any. All entries are sorted alphabetically with the exception of bands belonging to no record label.

## Developer Requirements
- .NET Core 2.2
- Visual Studio or dotnet CLI

## Technology Stack
- ASP.NET Core 2.2 (MVC)

## Design patterns used
- Uses [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- Dependency Injection
- SOLID principles

## Set up with Visual Studio
### Run the project with Visual Studio
- Clone the repository
- In Visual Studio, locate the src folder and open the EA.Festival.Solution.sln file in Visual Studio
- Ensure that the solution builds successfully by rebuilding the solution. selecting  Build > Rebuild.
- Set the startup project to be EA.Festival.Web 
- Run the project (either in debug mode or without). To run in debug mode press F5, otherwise, press Ctrl + F5 to run without debug mode.
- Navigate to the URL: https://localhost:{portNumber}/ where portNumber is the localhost port number i.e. https://localhost:44312/
- All done!

## Set up with dotnet CLI
### Run the project with dotnet command
- open command line, navigate to solution in src/ folder
- build the solution by typing in ``dotnet build``, ensure the build is successful
- Run the Web project by typing in ``dotnet run --project ./EA.Festival.Web``
- You should now see that the application is running on localhost port.
- Navigate to the URL: https://localhost:{portNumber}/ where portNumber is the localhost port number i.e. https://localhost:44312/
- All done!
- For more informaton see the following url: https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-run?tabs=netcore22

## Assumptions
- Bands not belonging to a record label should be displayed as the last entry, after all the other record labels.
- A message "No music festivals attended" will be displayed for any bands that have not played a festival.
- A message "No bands under this record label" will be displayed for a record label with no bands.
- Pagination/Limiting the number of the results from the API is not necessary.

## Extensions
- Logging needs to be added to the solution, this can be added by using a Global exception handler.
- Adding unit tests
- Adding collapsible tree structure or accordions to represent the hierarchy, enabling the user to see the information relevant to them.
- Adding pagination if the API returns large amounts of entry etc.
