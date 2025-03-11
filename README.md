I use a JetBrains IDE called Rider to run these.

To run the monolith API, .NET 7 is required:
https://dotnet.microsoft.com/en-us/

To run the microservices, .NET 8 is required:
https://dotnet.microsoft.com/en-us/download/dotnet/8.0
~ specifically preview 3, although the latest version should work fine

To run the frontend, .NET 8 is also required

depending on the Solution, cd into the main project and run it, so for example in the monolith API:
PS \FypAPISolution> cd .\FypAPI\
PS \FypAPISolution\FypAPI> dotnet run --launch-profile https

this will run a version running HTTPS, use http for HTTP, if IIS Express is installed you can press debug on an IDE and it will automatically run it.

if you want to run tests then:
PS \FypAuthenticationSolution> cd .\FypAuthenticationMicroservice.Tests\
PS \FypAuthenticationSolution\FypAuthenticationMicroservice.Tests> dotnet test

the same instructions can be applied for every microservice

for the frontend, it is the same process, dotnet run --launch-profile https in the root of the project.
Inside of the API > NswagConfig folder, the config file will need to be updated with the local version of your local API's endpoint

the line:     "APIBaseUrl": "https://localhost:44376",
will need to be changed within appsettings.Development.json too, to whatever the url of your local API's endpoint
