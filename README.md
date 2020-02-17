# EasyTrello

### Backgrouund.
Helps to import/export Trello tasks from/to differen sources. 
Currently supports import from xlsx to Trello.

### How to use?
Get access key and token using [this instruction](https://developers.trello.com/docs/api-introduction#section-a-name-auth-authentication-and-authorization-a).

Prepare .xlsx file with the following structure:
| Name | Labels | Description | Checklist | List |
| ------ | ------ | ------ | ------ | ------ |
| [Task name] | [comma-separated list of labels] | [Task description] | [New-line separated list of items]] | [Board list name] |

Initialise new instance of TrelloManager with access key and token
```csharp
var appKey = "[YOUR APP KEY]";
var token = "[YOUR APP TOKEN]";

var manager = new EaseTrello.TrelloManager(appKey, token);
```

Invoke ImportToTrello method with path to your xlsx file
```csharp
await manager.ImportToTrello(@"C:\New board.xlsx");
```

Thats all! Invoke of ImportToTrello creates new board with, list, labels and cards with checklist.


