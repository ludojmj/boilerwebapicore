# [boilerwebapicore](https://github.com/ludojmj/boilerwebapicore)
## .NET Core 2.0 WebApi
  - Self Hosted: BoilerWebApiCore project
```
$ git clone https://github.com/ludojmj/boilerwebapicore.git
```
Architecture:
```
$ dotnet new webapi -n MyApp
$ dotnet new xunit -n MyApp.UnitTest
```

Visual Studio Code:
```
$ code boilerwebapicore
```
Restore packages when asked by vscode then F5 to debug.

Alternatively with the command line:
```
$ cd BoilerWebApiCore.UnitTest
$ dotnet restore
$ dotnet build
$ dotnet test

$ cd ../BoilerWebApiCore
$ export ASPNETCORE_ENVIRONMENT=Development
$ dotnet run
```

* Front-end code:
  * BoilerWebApiCore/wwwroot/index.html + index.js + index.css

* Back-end code:
  * BoilerWebApiCore/Controllers/ProductController.cs
  * BoilerWebApiCore/Controllers/OtherProductController.cs

* Automatic logs settings:
  * BoilerWebApiCore/appsettings.json

## Swagger
* Launch the http server:
  * dotnet bin/Debug/netcoreapp2.0/**BoilerWebApiCore.dll**

* Open the url:
  * http://localhost:5000/swagger

## Layers

#### BoilerWebApiCore/wwwroot

* index.html
* index.js
* index.css


#### BoilerWebApiCore/Controllers

* ProductController businessError=1 => KO
  * **api/product**?businessError=1
    >  ==> GET KO (intentional BoilerWebApiCore.BusinessException)

  * **api/product/async**?businessError=1
    >  ==> GET KO (intentional BoilerWebApiCore.BusinessException)

* ProductController businessError=0 => OK
  * **api/product**?businessError=0
    >  ==> GET OK

  * **api/product/async**?businessError=0
    >  ==> GET OK

* OtherProductController input.Name="1" => KO
  * **api/otherproduct** { Name = "1", ... }
    >  ==> POSTT KO (unintentional System.DivideByZeroException)

  * **api/product/async**  { Name = "1", ... }
    >  ==> POST KO (unintentional System.DivideByZeroException)

* OtherProductController input.Name="0" => OK
  * **api/product**  { Name = "0", ... }
    >  ==> POST OK

  * **api/product/async**  { Name = "0", ... }
    >  ==> POST OK

* ErrorController
  * **api/error**
    >  ==> Generic message displayed because of a bug in application


#### BoilerWebApiCore/Repository

* IProductRepo.cs
* IOtherProductRepo.cs

* ProductRepo.cs
* OtherProductRepo.cs


#### BoilerWebApiCore/Models

* Product.cs
* ErrorContent.cs


#### BoilerWebApiCore/Shared

* BusinessException.cs : Exception
    >  ==> Voluntary BusinessException thrown wherever in application in order to display a business message to user

* GenericExceptionHandler : IExceptionFilter
    >  ==> Displaying a business message to user in case of BusinessException **(MVC)**

    >  ==> Delegating logging and displaying a generic message in ErrorController **(AspNet)**
 
