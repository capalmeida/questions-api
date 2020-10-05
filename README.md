# Questions API Assessment

## Tech used:
```
.NET Core 3.1
EF Core
Swagger
AutoMapper
Serilog
MailKit
```

## Database setup
```
Change the LocalConnection connection string with your server setup

Inside Questions.Service layer run command: 
dotnet ef database update --context QuestionsContext --verbose 
```

## Testing Share controller
```
For demo purposes the send e-mail share endpoint is using https://ethereal.email/

To verify that e-mails are being sent you can login to https://ethereal.email/
username: fabiola.vandervort@ethereal.email
password: wfVhrmy8qv4t65z6qt
```
