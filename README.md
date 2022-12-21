# ClarityEmail
***
## Table of Contents
*[General Info](#general-info)
*[Tools and Technologies](#tools-and-technologies)
*[Setup](#setup)
*[Routes and Data](#routes-and-data)
*[Testing](#testing)
*[Improvements](#improvements)

## General-Info

An API that both sends and logs emails. This backend satisfies the following requirments:

* Send Email Method should be in a dll that can be reused throughout different applications and entry
points.
* Email sender, recipient, subject, and body (not attachments), and date must be logged/stored indefinitely
with status of send attempt.
* If email fails to send it should either be retried until success or a max of 3 times whichever comes first,
and can be sent in succession or over a period of time.
* Please store all credentials in an appsettings instead of hardcoded.
* At minimum that method/dll should be called from a console application.
* EXTRA Credit if a front end (wpf/asp.net web application/etc...) calls the API to send the email.

Note: DLL can be found in EmailMethod folder; React(TypeScript) frontend can be found in EmailSite; API can be found in ClarityEmail

## Tools and Technologies

React: v18.2 | Material-UI: v5.11 | .NET: v7 | MailKit: v3.4.3 | C# | TypeScript | SQLite: v7.01 | EntityFrameworks: v7.01 | AutoMapper: v12.0.0

## SetUp

Clone Repo:
```
$ git clone https://github.com/amyers3000/ClarityEmail.git
```

.Net API:

```
$ cd ../path/to/the/file
$ cd ClarityEmail
$ dotnet ef database update
$ dotnet watch run
```


React(TypeScript) Frontend:

```
$ cd ../path/to/the/file
$ cd ClaritySite
$ npm install
$ npm start
```

Default sender info provided in appSettings.Development.json. Feel free to modify host, username, and password.

Note: For testing purposes Etheral("https://ethereal.email/"), a fake SMTP service, was used to make sender and recipitent info. The username and password below can be used to login and view messages.

```
{
  "EmailHost": "smtp.etheral.email",
  "EmailUserName": "jack.walker@ethereal.email",
  "EmailPassword": "2QaWf1j1bqQkdHT1GJ",
  "ConnectionStrings": {
    "DefaultConnection": "Data source=store.db"
  }
```

![Etheral](/Assets/Screenshot%202022-12-21%20at%208.12.38%20AM.png)


## Routes and Data

| Method | Route | Description |
| ****** | ***** | *********** |
| Post | /api/Email | Send email to desired recipient that contains both subject and email |
| Get  | /api/Email | View emails logs. Logs include success of message and a timestamp |

### Email Model

| Type | Data |
| **** | **** |
| int | Id |
| string | Sender |
| string | Recipient |
| string | Subject |
| string | Body |
| string | Date |
| bool | Success |

### EmailDto

| Type | Data |
| **** | **** |
| string | Recipient |
| string | Subject |
| string | Body |

### ViewEmailDto

| Type | Data |
| **** | **** |
| string | Sender |
| string | Recipient |
| string | Subject |
| string | Body |
| string | Date |
| bool | Success |

### Response Object
| Type | Data |
| **** | **** |
| T (Generic) | Data |
| string | Message |
| bool | Success

## Testing


Postman API Test collection("https://alex-email-clarity.postman.co/workspace/Team-Workspace~0ffa55bf-f22d-471d-8b81-6788fc858a95/api/8bdf9e98-f34e-42cc-b2db-61de02c3454d")


[![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/20982764-7307a0b4-ba1f-43a4-a8d0-e147580a542a?action=collection%2Ffork&collection-url=entityId%3D20982764-7307a0b4-ba1f-43a4-a8d0-e147580a542a%26entityType%3Dcollection%26workspaceId%3Dadf8db36-86c0-4737-b4be-33ed4a311c12#?env%5BEmail%20Variables%5D=W3sia2V5IjoidXNlcm5hbWUiLCJ2YWx1ZSI6IiIsImVuYWJsZWQiOnRydWUsInR5cGUiOiJhbnkifV0=)