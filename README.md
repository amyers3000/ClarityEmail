# ClarityEmail
***
## Table of Contents
* [General Info](#general-info)
* [Tools and Technologies](#tools-and-technologies)
* [Setup](#setup)
* [Routes and Data](#routes-and-data)
* [Testing](#testing)


## General-Info

An API that both sends and logs emails. This backend has the following features:

* Send Email Method is in a dll that can be reused throughout different applications and entry
points.
* Email sender, recipient, subject, and body (not attachments), and date arelogged/stored indefinitely
with status of send attempt.
* If email fails to send it will be rety until success or a max of 3 times whichever comes first
* Credentials are stored in appsettings
* Front end calls the API to send the email.


Note: DLL can be found in EmailMethod folder; React(TypeScript) frontend can be found in EmailSite; API can be found in ClarityEmail

## Tools and Technologies

React | Material-UI | .NET | MailKit| C# | TypeScript | SQLite | EntityFrameworks| AutoMapper

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
![Email](/Assets/Screenshot%202022-12-21%20at%2011.15.06%20AM.png)

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

Below is a test Etheral recipitent account. Use this information to check if the email was successfully received.

![EtheralRecipient](/Assets/Screenshot%202022-12-29%20at%208.40.02%20AM.png)


## Routes and Data


| Method | Route | Description |
| ----- | ----- | -------- |
| Post | /api/Email | Send email to desired recipient that contains both subject and email |
| Get  | /api/Email | View emails logs. Logs include success of message and a timestamp |

<table>
<tr><th>Email Model</th><th>EmailDto</th><th>ViewEmailDto</th></tr>
<tr><td>

| Type | Data |
| --- | ---- |
| int | Id |
| string | Sender |
| string | Recipient |
| string | Subject |
| string | Body |
| string | Date |
| bool | Success |

</td>
<td>

| Type | Data |
| --- | ---- |
| string | Recipient |
| string | Subject |
| string | Body |

</td>
<td>

| Type | Data |
| ---- | --- |
| string | Sender |
| string | Recipient |
| string | Subject |
| string | Body |
| string | Date |
| bool | Success |

</td>
</tr>
</table>

## Testing

Run the test collection in Postman or check routes on Swagger!

[![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/20982764-7307a0b4-ba1f-43a4-a8d0-e147580a542a?action=collection%2Ffork&collection-url=entityId%3D20982764-7307a0b4-ba1f-43a4-a8d0-e147580a542a%26entityType%3Dcollection%26workspaceId%3Dadf8db36-86c0-4737-b4be-33ed4a311c12#?env%5BEmail%20Variables%5D=W3sia2V5IjoidXNlcm5hbWUiLCJ2YWx1ZSI6IiIsImVuYWJsZWQiOnRydWUsInR5cGUiOiJhbnkifV0=)
