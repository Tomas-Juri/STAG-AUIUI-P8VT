---
title: "2025"
layout: home
nav_order: 996
---

# STAG-AUIUI-P8VT 2025

{: .no_toc }

# Náplň a požadavky

Kurz AP8VT si klade za cíl naučit studenty kvalitně a efektivně vyvíjet aplikace podle moderních přístupů a postupů. Přednášky jsou
realizovány také formou praktických workshopů, v rámci nichž dílčí týmy postupně budují svůj webový produkt. Cvičení se zaměřují na
využívání konkrétních technologií, pomocí kterých studenti průběžně realizují týmový projekt.

## Lektoři

**Petr Záček**
Organizační záležitosti univerzity, garant předmětu, Product Owner

**Jiří Urban**
Hlavní přednášející, organizace kurzu, Product Owner

**Tomáš Juřička**
Hlavní cvičící

**Stanislav Čermák**
Product Owner

## Docházka

Povoleny jsou 3 absence, v opačném případě je třeba donést omluvenku od doktora.

## Způsob hodnocení

Studenti mohou během semestru získat až 70 bodů v následující struktuře:

**Projekt – 65 bodů**

-   Projekt je rozdělen do 5 sprintů, každý po 10 bodech.
-   Finální sprint (ve zkouškovém období) má hodnotu 15 bodů.

**Go to market – 5 bodů**

-   Extra body je možné získat za prokazatelnou snahu uvést aplikaci na "trh".
    -   Získání a zpracování zpětné vazby od reálných uživatelů.
    -   Marketingové aktivity spojené s propagací aplikace
    -   Viditelný engagement uživatelů aplikace

Bodování projektu sestává z hodnocení dílčích sprintů (Scrum terminologie). Konkrétní bodování za jednotlivé sprinty probíhá následovně:

1. Vedení kurzu a product owneri ohodnotí increment každého sprintu hodnotou 0-100 % za plánování a jeho formální správnost, dodané množství
   práce (increment), komunikaci a projev v průběhu sprintu, prezentaci při sprint review.
2. Všechna tři hodnocení se zprůměrují (např. 85 %) a tímto průměrem se násobí maximální možný počet bodů (10 bodů \* počet členů týmu).
   Například pro 5ti-členný tým by součet byl max. 50 bodů, který mohl tým za sprint získat.
3. Body se zaokrouhlí na celé číslo nahoru a tím se získá bodové ohodnocení za tento sprint pro daný tým (např. 43 bodů).
4. Tyto body si mezi sebe rozdělí členové týmu na základě vzájemné dohody, jak kdo v daném sprintu pracoval.
5. Tým je povinen nahlásit do 3 dnů od sprint review počet bodů pro jednotlivé členy v týmu (např. Karel 8b, Monika 10 bodů, Pepa 5 bodů,
   Simona 10 bodů, Šimon 10 bodů). Tímto způsobem můžete reflektovat skutečnou práci na projektu napříč týmem.

### Zvláštní pravidla

Za jeden sprint může jednotlivec v rámci přerozdělování bodů v týmu dostat i více bodů než 10, maximálně však o 2 body více než je maximum.
Počet přidělených bodů na jednoho zaokrouhlete na celá čísla.
Za finální (poslední) sprint je nutné, aby tým obdržel minimálně 50% bodů pro úspěšné absolvování kurzu. V případě, že se tak nestane, bude
vedoucí kurzu s týmem řešit celou situaci a buď celý tým nebo určití jedinci dostanou z kurzu známku F.

Přepočet bodů na konkrétní známky odpovídá standardům vysokých škol.

<iframe src="https://docs.google.com/spreadsheets/u/1/d/e/2PACX-1vTQ3jHS6tC_j0in8UQweziS8DoeepuyOBnnn6vZ6E-JRoMXzwSNflS9eCaLqte9fAenSl_RgjrRvJru/pubhtml?gid=0&amp;single=true" style="width: 100%;height: 60rem;"></iframe>

## Program výuky

| Lekce     | Datum     | Přednáška                                                                                     | Cvičení                                                   |
| --------- | --------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------- |
| 1. Lekce  | 10.2.2025 | Seznámení s předmětem, Představení projektu, Sestavení týmů, Základy Scrumu a Agilniho vývoje | Seznámení s šablonou aplikace                             |
| 2. Lekce  | 17.2.2025 | Lean Canvas workshop                                                                          | Continuous development & Continuous integration, Azure    |
| 3. Lekce  | 24.2.2025 | Přednáška - UI a UX / Backlog                                                                 | Trunk based development, small releases, feature toggling |
| 4. Lekce  | 3.3.2025  | Scrum game (Lego)                                                                             |                                                           |
| 5. Lekce  | 10.3.2025 | Sprint review 2                                                                               | Coding standarts, Pull requests, technical debt           |
| 6. Lekce  | 17.3.2025 | Přednáška - Filip Kapler                                                                      |                                                           |
| 7. Lekce  | 24.3.2025 | Sprint review 3                                                                               | Extreme programming                                       |
| 8. Lekce  | 31.3.2025 | Přednáška - Život ve startupu s OpenVibe                                                      |                                                           |
| 9. Lekce  | 7.4.2025  | Sprint review 4                                                                               | Pair/mob programming                                      |
| 10. Lekce | 14.4.2025 | -- Velikonoce --                                                                              |                                                           |
| 11. Lekce | 21.4.2025 | Finální retrospektiva / Pokročilý scrum                                                       |                                                           |
| 12. Lekce | 28.4.2025 | Finální prezentace projektu                                                                   |                                                           |

## 1. Lekce

### Seznámení s předmětem, Představení projektu, Sestavení týmů, Základy Scrumu a Agilniho vývoje

Odkaz na přednášku: [Úvod](https://docs.google.com/presentation/d/1yTSpYGDSLRayM4I8yML0vNC_a2_kXp1l/edit?usp=sharing&ouid=112391049308284909945&rtpof=true&sd=true)

### Seznámení s šablonou aplikace

Prerequisites:

-   [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
-   Your favorite IDE ([Rider recommended](https://www.jetbrains.com/rider/))
-   [Docker](https://www.docker.com/)
-   [MSSQL Docker image](https://hub.docker.com/_/microsoft-mssql-server) (mcr.microsoft.com/mssql/server:latest) for local database. And some management tool
-   [Azure Data Studio](https://azure.microsoft.com/en-us/products/data-studio) for db management

#### Copy project a get it working locally

1. Copy the project from [github repo](https://github.com/Tomas-Juri/STAG-AUIUI-P8VT/tree/master/2025)
2. Run your MSSQL Docker image
    - `docker pull mcr.microsoft.com/mssql/server:latest`
    - `docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest`
    - See how to use section in https://hub.docker.com/_/microsoft-mssql-server
3. Create a database in your local SQL server
    - `CREATE DATABASE "STAG-AUIUI-P8VT"`
4. Change your connection string in your `appsettings.json`
    ```
     "ConnectionStrings": {
         "Database": "Data Source=localhost;Initial Catalog=STAG-AUIUI-P8VT;Integrated Security=false;User ID=sa;Password=yourStrong(!)Password;TrustServerCertificate=true"
       },
    ```
5. Build the application via `dotnet build`
6. Run the application via IDE or `dotnet run`
7. Application is running and has applied db migrations

**More info**

-   [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet)
