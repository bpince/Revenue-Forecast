# Revenue Forecast Tool

## Technical Solution

The revenue forecast tool is built using .NET Core 3.1
and Angular 11, with Boostrap.

Upon lauching the application, you will be directed to the Home page,
which displays a list of projects for the current month. For example, 
if the month is July, then all project revenue's in July will be displayed in the table.

There is also a search filter above the table that allows you to search with a string term on the fields:
- Job Number
- Status
- Client Name

If you navigate to the Client Revenue's page, you will see a table that shows all Client Projects that
have been added into the system. 

Here you can edit/update these entries by clicking the Edit button for
each row. 

You can Add new entries, delete entries and also check any projects audit history from the edit page.

## Technical Strcuture

You will find all the angular front end pages for the application at - /clientapp/src/app

The backend solution has been structured in the following folders:

Controllers -> Controllers
Services -> Services
Entity Models and DbContext -> Data
Application Models -> Models

## Set up

Prequisites:
Ensure you have:
- Visual Studiop 2019
- MSSQL Server


1. Clone the repository locally

2. Open the .Sln file in Visual Studio 2019 - Revenue-Forecast.sln

