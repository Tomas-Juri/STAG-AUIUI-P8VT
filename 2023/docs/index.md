# STAG-AUIUI-AP8VT-2023

_Repository: [https://github.com/Tomas-Juri/STAG-AUIUI-P8VT](https://github.com/Tomas-Juri/STAG-AUIUI-P8VT-2021-2022)_

_Discord channel: [https://discord.gg/9K8PSk4Z7b](https://discord.gg/9K8PSk4Z7b)_

**Table of contents:**

[1. Lekce 10.02.2023](#1-lekce---10022023)  
[2. Lekce 17.02.2023](#2-lekce---17022023)  
[3. Lekce 24.02.2023](#3-lekce---24022023)  
[4. Lekce 03.03.2023](#4-lekce---03032023)  
[5. Lekce 09.03.2023](#5-lekce---10032023)  
[6. Lekce 16.03.2023](#6-lekce---17032023)  
[7. Lekce 23.03.2023](#7-lekce---24032023)  
[8. Lekce 30.03.2023](#8-lekce---31032023)  
[9. Lekce 06.04.2023](#9-lekce---07042023)  
[10. Lekce 13.04.2023](#10-lekce---13042023)    
[11. Lekce 20.04.2023](#11-lekce---20042023)    
[12. Lekce 27.04.2023](#12-lekce---27042023)

## 1. Lekce - 10.02.2023

### Presentation:

[![Presentation](https://media.slid.es/thumbnails/16c313c8909a921845d7b977a0765c43/thumb.jpg?1675846106)](https://slides.com/jiriurban-1/deck/fullscreen)

### Technical Prerequisites:

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- Your favorite IDE
  - [VS Code](https://code.visualstudio.com/)
  - [Visual studio community](https://visualstudio.microsoft.com/cs/vs/community/)
  - [Jetbrains Rider](https://www.jetbrains.com/rider/)
- REST API Client
  - [Insomnia](https://insomnia.rest/)
  - [Postman](https://www.postman.com/)

### Create Project and run it

1. Create an Blazor webassembly App - ASP.NET Core Hosted  
   `dotnet new blazorwasm --hosted -n OnlyShare -o .`

2. Run application using  
   `dotnet run --project .\Server\OnlyShare.Server.csproj  `

3. Or use your ide to run Server project

4. This will run both backend and frontend as one application

   - The ASP.NET server as a host to both API and frontend

5. Delete/Change scaffolded code from project
   - `./Server/Pages` - Remove whole folder
   - `./Server.Program.cs`
     - `builder.Services.AddControllersWithViews();` -> `builder.Services.AddControllers();`
     - `builder.Services.AddRazorPages();` - Remove
     - `app.MapRazorPages();` - Remove

### How to debug (in VS Community)

1. Open the solution in VS community

2. Press the debug button 'https' in VS

![Image](./VS_Debug.png)

More info on how to debug: https://learn.microsoft.com/en-us/aspnet/core/blazor/debug

_Final code commit of this lecture: **37960e5d8dbdaffad510c929f1e2862e6965c008**_

---


## 2. Lekce - 17.02.2023

> TODO

## 3. Lekce - 24.02.2023

> TODO

## 4. Lekce - 03.03.2023

> TODO

## 5. Lekce - 10.03.2023

> TODO

## 6. Lekce - 17.03.2023

> TODO

## 7. Lekce - 24.03.2023

> TODO

## 8. Lekce - 31.03.2023

> TODO

## 9. Lekce - 07.04.2023

> TODO

## 10. Lekce - 13.04.2023

> TODO

## 11. Lekce - 20.04.2023

> TODO

## 12. Lekce - 27.04.2023

> TODO