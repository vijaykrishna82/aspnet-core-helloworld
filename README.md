# ASP.NET Core Hello World

A simple ASP.NET Core web application for the [ASP.NET Core buildpack][].


## Run the app locally

1. Install ASP.NET Core by following the [Getting Started][] instructions
+ Clone this app
+ cd into the app directory and then `src/dotnetstarter`
+ Run `dotnet restore`
+ Run `dotnet run`
+ Access the running app in a browser at [http://localhost:5000](http://localhost:5000)

[Getting Started]: http://docs.asp.net/en/latest/getting-started/index.html
[ASP.NET Core buildpack]: https://github.com/cloudfoundry-incubator/dotnet-core-buildpack

## Setting Environment Variables


	### On Windows
		+ Run the following command:
		`set MyKey=<AnyValue>`

		+ Run `dotnet run`


	### On Mac

		+ Run `MyKey=<AnyValue> dotnet run`


+ Go to http://localhost:5000/Movies. 


## Deploying to Cloud Foundry

+ Login to Cloud Foundry `cf login`
+ Change the name of the app <AppName> in manifest.yml
+ Run `cf push`
+ Run `setenv <AppName> MyKey=<AnyValue>`
+ Run `cf restart <AppName>`
+ Find the app url by running `cf app <AppName>`
+ Go to the app url/Movies
