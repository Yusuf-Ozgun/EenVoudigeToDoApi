# EenVoudigeToDoApi

Users, Boards & ToDos werden aangemaakt

Boards kunnen meerdere todos hebben.
Een User kan gekoppeld worden aan boards en todos.

HttpGet:
- Hiermee kunnen we alle Users, Boards & ToDos oproepen vanuit de repository.
- Dit kan ook afzonderlijk per User, Board OF ToDos met de ID

HttpDelete:
- Hiermee kunnen we Users, Boards & ToDos deleten vanuit de repository als we de ID meegeven.

HttpPost:
- Hiermee kunnen we nieuwe Users, Boards & ToDos aanmaken.

HttpPut:
- Hiermee kunnen we Users, Boards & ToDos toevoegen, er wordt ook gecontroleerd of de User, Board OF ToDo al bestaat.

Door behulp van de krachtige Swagger kunnen we alle requests - net alsof we ze in Postman zouden executen - uitvoeren.
