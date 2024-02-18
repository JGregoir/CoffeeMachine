## Project purpose
This project was developed over the course of a day as a technical test and first exploration of the web stack .NET ASP + React.
I leveraged the defautlt project setup from visual studio to setup the environment as I had no notion of the stack beforehand.

## Project current state
As I could not figure out how to create persistent objects through dependency injection in the entity Framework, the Machine stub is not solicitated.

However, the http requests work, so it is possible to request a coffee through the interface, and see it updated in the Framework DbContext.
This same context is used to display logs.

It runs on my visual studio 2022 and fetches depndencies.

## Next steps

### Setup entity 
The coffee machine needs to be setup as a persistent entity.
I could have used a singleton.

### Non-unique index  
The logs are displayed by timestamp. as the timestamp resolution is 1s, multiple coffee logs can have the same index.
Easy to fix by using entity index.

### React
There definitely is some margin for improvement on the front.

## Thoughts

A very challenging and satisfying learning experience with many first discoveries :
HTTP, .NET Entity Framework, React, webserver setup.
