# Project Mercurius
![Banner](/misc/mercurius-banner.png)

Project for M151 &amp; M152

## :scroll: Table of contents
* [General info](#:information_source:-general-info)
* [Live Demo](#:eyes:-live-demo)
* [Technologies](#:dna:-technologies)
* [Setup](#:flight_departure:-setup)

## :information_source: General info
We made this Project for M152 and M153.

## :dna: Technologies
* SwissQRBill.NET
* Swagger
* Angular
* PrimeNG
* libwkhtmltox.dll
	
## :flight_departure: Setup

### Backend & Databse
Switch to database folder

```
cd ./backend/Database
```

Start docker with the Backend and Database

```
docker compose up -d
```

Execute the following two scripts: "CreateDatabase.sql" and "DemoData.sql"

### Frontend

Switch to the Frontend folder
```
cd ./frontend/
```
Start the Frontend
```
ng serve
```
