---
title: "2024"
layout: home
nav_order: 2
---

# STAG-AUIUI-P8VT 2024

{: .no_toc }

# Náplň a požadavky

Kurz AP8VT si klade za cíl naučit studenty kvalitně a efektivně vyvíjet webové aplikace podle moderních přístupů a postupů. Přednášky jsou realizovány také formou praktických workshopů, v rámci nichž dílčí týmy postupně budují svůj webový produkt. Cvičení se zaměřují na využívání konkrétních technologií, pomocí kterých studenti průběžně realizují týmový projekt.

## Lektoři

**Petr Záček**
Organizační záležitosti univerzity, garant předmětu, Product Owner

**Jiří Urban**
Hlavní přednášející, organizace kurzu, Product Owner

**Tomáš Juřička**
Hlavní cvičící, .NET, React

**Stanislav Čermák**
Product Owner

**David Sedlář**
Cvičící, .NET

## Dochazka

Povoleny jsou 3 absence, v opačném případě je třeba donést omluvenku od doktora.

## Způsob hodnocení

Studenti mohou během semestru získat až 70 bodů v následující struktuře:

### Projekt – 65 bodů

Projekt je rozdělen do 5 sprintů, každý po 10 bodech.
Finální sprint (ve zkouškovém období) má hodnotu 15 bodů.

### Code review – 5 bodů

Před finální prezentací proběhne hodnocení kvality zdrojových kódů, kde má tým možnost získat a obhajit si dodatečných 5 bodů.

Bodování projektu sestává z hodnocení dílčích sprintů (Scrum terminologie). Konkrétní bodování za jednotlivé sprinty probíhá následovně:

Vedení kurzu a product owneri ohodnotí increment každého sprintu hodnotou 0-100 % za plánování a jeho formální správnost, dodané množství práce (increment), komunikaci a projev v průběhu sprintu, prezentaci při sprint review.
Všechna tři hodnocení se zprůměrují (např. 85 %) a tímto průměrem se násobí maximální možný počet bodů (10 bodů \* počet členů týmu). Například pro 5ti-členný tým by součet byl max. 50 bodů, který mohl tým za sprint získat. Body se zaokrouhlí na celé číslo nahoru a tím se získá bodové ohodnocení za tento sprint pro daný tým (např. 43 bodů).
Tyto body si mezi sebe rozdělí členové týmu na základě vzájemné dohody, jak kdo v daném sprintu pracoval. Tým je povinen nahlásit do 3 dnů od sprint review počet bodů pro jednotlivé členy v týmu (např. Karel 8b, Monika 10 bodů, Pepa 5 bodů, Simona 10 bodů, Šimon 10 bodů). Tímto způsobem můžete reflektovat skutečnou práci na projektu napříč týmem.

### Zvláštní pravidla

Za jeden sprint může jednotlivec v rámci přerozdělování bodů v týmu dostat i více bodů než 10, maximálně však o 2 body více než je maximum.
Počet přidělených bodů na jednoho zaokrouhlete na celá čísla.
Za finální (poslední) sprint je nutné, aby tým obdržel minimálně 50% bodů pro úspěšné absolvování kurzu. V případě, že se tak nestane, bude vedoucí kurzu s týmem řešit celou situaci a buď celý tým nebo určití jedinci dostanou z kurzu známku F.

Přepočet bodů na konkrétní známky odpovídá standardům vysokých škol.

## Program výuky - Seminář

1. Týden 5.2 - Seznámení s předmětem, Představení projektu, Sestavení týmů.
2. Týden 12.2 - Lean Canvas workshop.
3. Týden 19.2 - Základy Scrumu / (External) UI/UX triky
4. Týden 26.2 - Sprint review 1.
5. Týden 4.3 - Workshop o týmových odhadech / Backlog.
6. Týden 11.3 - Sprint review 2.
7. Týden 18.3 - Scrum game
8. Týden 25.3 - Sprint review 3.
9. Týden 1.4 - Odpadá - Velikonoce
10. Týden 8.4 - Sprint review 4.
11. Týden 15.4 - (External) Tyrkysová organizace / agilní vývoj projektu: Honza Podzimek.
12. Týden 22.4 - Sprint review 5.
13. Týden 29.4 - Finální retrospektiva / Pokročilý Scrum.
14. Týden 6.5 - Finální prezentace projektu.

## Program výuky - Cvičení

1. Týden 5.2 - Založení projektu ze šablony a nastavení lokálního vývojového prostředí
2. Týden 12.2 - Git, Continuous development & Continuous integration, Azure
3. Týden 19.2 - Databáze, Entity framework, DI, Databáze, Entity framework, REST API
4. Týden 26.2 - Cvičení vynecháno z důvodu nepřítomnosti cvičícího
5. Týden 4.3 - React app intro, React and Blazor components, Bootstrap, Fetch
6. Týden 11.3 - Autentizace a autorizace
7. Týden 18.3 - Scrum game
8. Týden 25.3 - Logování aplikace, Individuální podpora týmů
9. Týden 1.4 - Odpadá - Velkkonoce
10. Týden 8.4 - Přednáška CI&CD Best practices, 
11. Týden 15.4 - Individuální podpora týmů / Volné téma
12. Týden 22.4 - Clean Code/Atomic design / Code review
13. Týden 29.4 - Code review
14. Týden 6.5 - Už nebude cvičení.

## Table of contents

{:toc}

---

## 1. Lekce - Založení projektu ze šablony a nastavení lokálního vývojového prostředí

### Technical Prerequisites:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Your favorite IDE
  - [VS Code](https://code.visualstudio.com/)
  - [Visual studio community](https://visualstudio.microsoft.com/cs/vs/community/)
  - [Jetbrains Rider](https://www.jetbrains.com/rider/)
- [Node JS](https://nodejs.org/en/) for react development
- [MSSQL](https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=&ved=2ahUKEwjUwczW8bmDAxU11gIHHZcPB90QFnoECBIQAQ&url=https%3A%2F%2Fwww.microsoft.com%2Fen-us%2Fsql-server%2Fsql-server-downloads&usg=AOvVaw0d74lgRcnfX6ZThGwL_ED6&opi=89978449) or a [Docker image](https://hub.docker.com/_/microsoft-mssql-server) (mcr.microsoft.com/mssql/server:latest) for local database. And some management tool
  - [SQL Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
  - [Azure Data Studio](https://azure.microsoft.com/en-us/products/data-studio)

### Copy project a get it working locally

1. Copy the project

2. Install MSSQL Server and run it or run your MSSQL Docker Image

   - `docker pull mcr.microsoft.com/mssql/server:latest`
   - `docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest`
   - See how to use section in https://hub.docker.com/_/microsoft-mssql-server

3. Create a database in your local SQL server

   `Create Database "STAG-AUIUI-P8VT"`

4. Change your connection string in your `appsettings.json`

   ```js
   "ConnectionStrings": {
       "Database": "Data Source=localhost;Initial Catalog=STAG-AUIUI-P8VT;Integrated Security=false;User ID=sa;Password=yourStrong(!)Password;TrustServerCertificate=true"
     },
   ```

5. Build the application via `dotnet build`

6. Run the application via IDE or `dotnet run`

7. Maybe you will need to install dev certificates  
   `dotnet dev-certs https `

8. This will run both backend and frontend as one application

   - The ASP.NET server will serve as a host to both API and frontend

9. In `Fetch Data` page you can see some data being pull from API, this data is stored in database an has been seeded via a migration.

More info

- [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet)
- [ASP.NET with React](https://learn.microsoft.com/cs-cz/aspnet/core/client-side/spa/react?view=aspnetcore-7.0&tabs=visual-studio)
- [How to debug blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/debug)

## 2. Lekce - Git, Continuous development & Continuous integration, Azure

**Overview:**
- Git & best practices presentation
- Create a continuous integration pipeline to build your application.
- Create a continous delivery pipeline (release) to deploy your application to server.
- Setup git policies for branches.


**Prerequisites:**
- [Git](https://git-scm.com/downloads)
- Pushed changes into a repository in azure devops

### Git and development with it

1. Git Demo - Basics, Commit, Branch, Checkout, Rebase, merge
2. Git Demo - Gitflow
3. Git Demo - Trunk based
4. How to colaborate using git

### Create a build definition using YAML

Setup build pipelines with branch push trigger in azure devops

```yml
trigger:
  branches:
    include:
      - main

pool:
  vmImage: "windows-latest"

variables:
  buildConfiguration: "Release"

steps:
  - task: UseDotNet@2
    displayName: Use Dotnet 8
    inputs:
      version: "8.0.x"

  - script: dotnet clean
    displayName: "dotnet clean"

  - script: dotnet publish -o $(Build.ArtifactStagingDirectory)
    displayName: "dotnet publish"

  - task: PublishBuildArtifacts@1
    displayName: "Publish Artifact: drop"
    inputs:
      PathtoPublish: "$(Build.ArtifactStagingDirectory)"
      ArtifactName: "application"
```

> NOTE: Get latest version of react app to get the fix for api URL

### Create a release pipeline in Azure DevOps

To host our applications, we will use Azure app service.  
To deploy our application, we will create a release pipeline.

Release pipeline:

1. Create new Release pipeline
2. Select 'Azure App Service deployment'
3. Add artifact
4. Configure Azure App Service deployment
   - Add subscription (admin needed)
   - Add application (admin needed)
   - Select Package/Folder location (from build)

![AzureDevops_Release_1](AzureDevops_Release_1.PNG)
![AzureDevops_Release_2](AzureDevops_Release_2.PNG)

If we did everything correctly, we should have our application deployed and it should look like this:

- [Azure/Application](https://utb--2024-internal-test.azurewebsites.net/)

More Info:

- [Azure pipelines](https://learn.microsoft.com/en-us/azure/devops/pipelines/create-first-pipeline?view=azure-devops&tabs=net%2Ctfs-2018-2%2Cbrowser)

### Application urls of teams

- [AlfaskvadraVlkousi - Preberu ukradnu](https://utb--2024-alfa-preberu.azurewebsites.net/)
- [Dynamic Developers - Random](https://utb--2024-dynamic-random.azurewebsites.net/)
- [Spolecenstvo Simona - Binary Brothers](https://utb--2024-spolecenstvo-binary.azurewebsites.net/)
- [Internal_Test](https://utb--2024-internal-test.azurewebsites.net/)

Additional Topics: 
- Overview of Azure resources.  
- How is application connected to database ?  
- If we have Time - Infrastructure as code and Pulumi  
- How can i get my release running automagically after a new build ?

More info:

- [YAML](https://yaml.org/)
- [Azure devops pipelines](https://docs.microsoft.com/cs-cz/azure/devops/pipelines/?view=azure-devops)
- [Continuous Integration](https://en.wikipedia.org/wiki/Continuous_integration)
- [Continuous Deployment](https://en.wikipedia.org/wiki/Continuous_deployment)
- [Learn git branching](https://learngitbranching.js.org/)
  - [Sandbox](https://learngitbranching.js.org/?NODEMO)

## 3. Lekce - Databáze, Entity framework, DI, Databáze, Entity framework, REST API

**Overview:**
- Leftover from last lecture: Setup git policies for branches.
- Overview of MSSQL database and entity framework
- Migrations, Database update, managing migrations in release
- Relations and how to create them
- Repositories & Dependency injection
- Data seeding
- REST API in ASP.NET

More info:
- [Entity Framework](https://docs.microsoft.com/en-us/ef/)
- [EF Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
- [ASP.NET Rest API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio)
- [REST Api best practices](https://stackoverflow.blog/2020/03/02/best-practices-for-rest-api-design/)
- [HTTP statuses](https://httpstatusdogs.com/)
  - [Boring version](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status)

## 4. Lekce

> Cvičení vynecháno z důvodu nepřítomnosti cvičícího

## 5. Lekce - React app intro, React and Blazor components, Bootstrap, Fetch

**Overview:**
- React Intro
  - What is React
  - Intro to TSX/JSX
  - Functional components and hooks
  - State management with `useState`
  - Side effects with `useEffect`
  - Passing props to child components
  - Lifting state up
  - Fetch API/Axios
  - Information about bootstrap
- Blazor Intro
  - What is Blazor
  - Blazor hosting models
  - State management and side effect (loading data)
  - Passing properties to child components
  - HttpClient usage
  - Information about bootstrap

More info:
- [React](https://react.dev/learn)
  - [Components](https://react.dev/learn/your-first-component)
  - [State management](https://react.dev/learn/state-a-components-memory)
  - [Side effects](https://react.dev/learn/synchronizing-with-effects)
  - [Lifting state up](https://react.dev/learn/sharing-state-between-components#lifting-state-up-by-example)
  - [Forms in react](https://react.dev/learn/reacting-to-input-with-state)
  - [Fetch API](https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API)
    - [Axios](https://axios-http.com/docs/intro)
- [React Bootstrap](https://react-bootstrap.netlify.app/)
- [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)
  - [Hosting Models](https://learn.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-8.0)
  - [Components in blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/?view=aspnetcore-8.0)
  - [Components lifecycle](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-8.0)
  - [State management](https://learn.microsoft.com/en-us/aspnet/core/blazor/state-management?view=aspnetcore-8.0&pivots=server)
  - [Get data from API](https://learn.microsoft.com/en-us/aspnet/core/blazor/call-web-api?view=aspnetcore-8.0)
- [Bootstrap](https://getbootstrap.com/)

## 6. Lekce - Autentizace a autorizace

**Overview:** 
 - What is authentization? What is authorization? Difference
 - JWT tokens
 - Authentication in ASP.NET
 - Current user context
 - Authorization in ASP.NET
  - Role Based
  - Policy Based
  - Claims-based
 - Claims in tokens for frontend

### Add authenticaion to API

1. Register Authentication Services  

    ```csharp
    // Add authentication
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true
        };
    });
    ```

  2. Add configuration for JWT

      ```csharp
      "Jwt": {
        "Issuer": "https://utb--2024-internal-test.azurewebsites.net/",
        "Audience": "https://utb--2024-internal-test.azurewebsites.net/",
        "Key": "{GENERATED_KEY_DO_NOT_SHARE}"
      }
      ```

      ```csharp
      public class AppSettings
      {
          public required JwtOptions Jwt { get; init; }
          
          public record JwtOptions
          {
              public required string Issuer { get; init; }
              
              public required string Audience { get; init; }
              
              public required string Key { get; init; }
          }   
      }
      ```

  3. Add authentication middleware

      ```csharp
      app.UseAuthorization();
      ```

  4. Create login Endpoint

      ```csharp
      [ApiController]
      [Route("/api/account")]
      public class AccountController(DataContext dataContext, IOptions<AppSettings> appSettings) : Controller
      {
          private readonly AppSettings _appSettings = appSettings.Value;
          
          [HttpPost("login")]
          public IActionResult Login(LoginRequest request)
          {
              var user = dataContext.Users.FirstOrDefault(user => user.Email == request.Email);
              if (user == null)
                  return NotFound();

              if (Password.Verify(request.Password, user.PasswordHash, user.PasswordSalt) == false)
                  return BadRequest();

              var issuer = _appSettings.Jwt.Issuer;
              var audience = _appSettings.Jwt.Audience;
              var key = Encoding.ASCII.GetBytes(_appSettings.Jwt.Key);
              var tokenDescriptor = new SecurityTokenDescriptor
              {
                  Subject = new ClaimsIdentity(new[]
                  {
                      new Claim("Id", user.Id.ToString()),
                      new Claim(JwtRegisteredClaimNames.Email, user.Email),
                  }),
                  Expires = DateTime.UtcNow.AddDays(1),
                  Issuer = issuer,
                  Audience = audience,
                  SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
              };
              var tokenHandler = new JwtSecurityTokenHandler();
              var token = tokenHandler.CreateToken(tokenDescriptor);
              var jwtToken = tokenHandler.WriteToken(token);

              return Ok(jwtToken);
          }
      }
      ```

  5. You should now be able to login in with your user 
    - You can inspect your token at https://jwt.io/

  6. Authorize weather forecasts

      ```csharp
      ...
      [ApiController]
      [Route("/api/weather-forecast")]

      [Authorize]

      public class WeatherForecastController(DataContext dataContext, UsersRepository usersRepository) : ControllerBase
      {
      ...
      ```

  7. Add JWT token capability for swagger

      ```csharp
      // Add Swagger
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen(option =>
      {
          option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
          {
              In = ParameterLocation.Header,
              Description = "Please enter a valid token",
              Name = "Authorization",
              Type = SecuritySchemeType.Http,
              BearerFormat = "JWT",
              Scheme = "Bearer"
          });
          option.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
              {
                  new OpenApiSecurityScheme
                  {
                      Reference = new OpenApiReference
                      {
                          Type=ReferenceType.SecurityScheme,
                          Id="Bearer"
                      }
                  },
                  new string[]{}
              }
          });
      });
      ```

  8. Now your endpoints are restricted to authorized users only and swagger can work with token


### Add authorization to API

  1. Define roles

      ```csharp
      namespace Application.Backend.Authorization;

      public class Role
      {
          public const string Administrator = "Administrator";
          public const string User = "User";
      }
      ```

  2. Define policies

      ```csharp
      namespace Application.Backend.Authorization;

      public class Policy
      {
          public const string CanEditForecasts = "CanEditForecasts";
      }
      ```

  3. Add Authorization and register policy

      ```csharp
      builder.Services
        .AddAuthorization(options =>
        {
            options.AddPolicy(Policy.CanEditForecasts, policy => policy.RequireClaim(Policy.CanEditForecasts, "True"));
        });
      ```

  4. Add role to User
  5. Add claim when creating token

      ```csharp
      ...
      new Claim(Policy.CanEditForecasts, (user.Role == Role.Administrator).ToString())
      ...
      ```

  6. Apply authorization attribute on controller methods
  
      ```csharp
      [Authorize(Policy = Policy.CanEditForecasts)]
      ```

  7. Now you have roles and policies for them, you can also use the policies on FE since they are in token

### Getting current user context in API

```csharp
...
public class WeatherForecastController(DataContext dataContext) : ControllerBase
...
var emailClaim = User.FindFirst(ClaimTypes.Email);
...
```


More info:
- [jwt.io](https://jwt.io/)
- [ASP.NET Authenticaion](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-8.0)


## 7. Lekce - Scrum game

> Cvičení vynecháno - věnováno scrum game

## 8. Lekce - Feature Flags, Logování aplikace, Individuální podpora týmů

**Overview:** 
- What is loggin and why is it usefull
- ASP.NET Logging basics
- Azure app insights
- What is feature management and why should you use it
- Setup feature managamenet
- Give permessions to read azure ? TJU - JUR 


### Logging

1. Inject ILogger<T> in your class

    ```csharp
    public class WeatherForecastController(DataContext dataContext, ILogger<WeatherForecastController> logger) : ControllerBase
    ```

2. Log your actions

    ```csharp
    ...
    [HttpGet]
    public IActionResult Get()
    {
        logger.LogInformation("Getting weather forecasts");
    ...  
    ```
    
    ```csharp
    ...
    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        var weatherForecasts = dataContext.WeatherForecasts.FirstOrDefault(forecast => forecast.Id == id);
        if (weatherForecasts == null)
        {
            logger.LogWarning("Weather forecast  {id} not found", id);

            return NotFound();
        }
    ...
    ```

    ```csharp
    [HttpGet("exception")]
    public IActionResult GetException()
    {
        try
        {
            throw new Exception("Foo bar");
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "An error happened while ...");
            throw;
        }
    }
    ```

3. Log all your HTTP request

    ```csharp
    ...
    // Add Database
    builder.Services
        .AddDbContext<DataContext>(options => options
            .UseSqlServer(builder.Configuration.GetConnectionString("Database")));

    // Add Logging
    builder.Services.AddHttpLogging(o => { });

    // Build app
    var app = builder.Build();
    ...
    ```

    ```csharp
    ...
    dataContext.Database.Migrate();

    // Configure the HTTP request pipeline.
    app.UseHttpLogging();

    if (app.Environment.IsDevelopment())
    {
    ...
    ``` 
    ```json
    ...
    "Logging": {
      "LogLevel": {
        ...
        "Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware": "Information"
      }
    },
    ...
    ```

### Feature Flags

1. Install Microsoft.FeatureManagement package
2. Add your flags to appsettings.json
   
   ```json
    "FeatureManagement": { 
      "WeatherForecastIncludesFahrenheits": true,
      "WeatherForecastIncludesKelvins": {
        "EnabledFor": [
          {
            "Name": "Percentage",
            "Parameters": {
              "Value": 50
            }
          }
        ]
      }
    }
   ```
3. Inject `IFeatureManager`

  ```csharp
  public class WeatherForecastController(DataContext dataContext, IFeatureManager featureManager) : ControllerBase
  ```

4. Use flags in code

  ```csharp
  ...
  var includeFahrenheit = await featureManager.IsEnabledAsync("WeatherForecastIncludesFahrenheits");
  var includeKelvin = await featureManager.IsEnabledAsync("WeatherForecastIncludesKelvins");
  
  var weatherForecasts = dataContext.WeatherForecasts
      .Select(forecast => new
      {
          forecast.Id,
          forecast.Summary,
          forecast.Date,
          Fahrenheit = includeFahrenheit ? Random.Next() : (int?)null,
          Kelvin = includeKelvin ? Random.Next() : (int?)null,
      })
      .ToList();
  ...
  ```

More Info:
- [ASP.NET Http logging](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-logging/?view=aspnetcore-8.0)
- [ASP.NET Logging fundamentals](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-8.0)
- [Azure App Insights](https://learn.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview)
- [ASP.NET Feature flags](https://learn.microsoft.com/en-us/azure/azure-app-configuration/use-feature-flags-dotnet-core)
- [Feature toggle (Wiki)](https://en.wikipedia.org/wiki/Feature_toggle)
- [Feature toggle (Martin Fowler)](https://martinfowler.com/articles/feature-toggles.html)

## 9. Lekce 

> Cvičení odpadá - Velikonoce

## 10. Lekce - Přednáška CI&CD Best practices

[Presentation Link](/docs/2024/UTB%20CICD.pptx)

## 11. Lekce - Individuální podpora týmů / Volné téma

## 12. Lekce - Clean Code/Atomic design Code review


## 13. Lekce - Final code review