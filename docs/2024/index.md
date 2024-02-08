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

**Tomáš Juríčka**
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
Všechna tři hodnocení se zprůměrují (např. 85 %) a tímto průměrem se násobí maximální možný počet bodů (10 bodů * počet členů týmu). Například pro 5ti-členný tým by součet byl max. 50 bodů, který mohl tým za sprint získat. Body se zaokrouhlí na celé číslo nahoru a tím se získá bodové ohodnocení za tento sprint pro daný tým (např. 43 bodů).
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
9. Týden 1.4 - Odpada - Velikonoce
10. Týden 8.4 - Sprint review 4.
11. Týden 15.4 - (External) Tyrkysová organizace / agilní vývoj projektu: Honza Podzimek. 
12. Týden 22.4 - Sprint review 5.
13. Týden 29.4 - Finální retrospektiva / Pokročilý Scrum.
14. Týden 6.5 - Finální prezentace projektu.

## Program výuky - Cvičení
1. Týden - Založení projektu ze šablony a nastavení lokálního vývojového prostředí
2. Týden - Git, Continuous development & Continuous integration, Azure
3. Týden - Databáze, Entity framework, React app intro
4. Týden - React Functional components, Bootstrap, REST API, Fetch
5. Týden - Autentizace a autorizace
6. Týden - Logování aplikace, Individuální podpora týmů 
7. Týden - Scrum game
8. Týden - Clean Code/Atomic design
9. Týden - Odpada - Velkkonoce
10. Týden - Code review
11. Týden - Individuální podpora týmů / Volné téma
12. Týden - Individuální podpora týmů / Volné téma
13. Týden - Code review
14. Týden - Už nebude cvičení.

## Table of contents
{: .no_toc .text-delta }

1. TOC
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
- [Blazor web assembly](https://learn.microsoft.com/cs-cz/aspnet/core/client-side/spa/react?view=aspnetcore-7.0&tabs=visual-studio)
- [How to debug blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/debug)

## 2. Lekce - Git, Continuous development & Continuous integration, Azure

- [Git](https://git-scm.com/downloads)


More Info 
- [Learn git branching](https://learngitbranching.js.org/)