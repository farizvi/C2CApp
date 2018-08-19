# C2CApp

This is a console application which represents a **Command and Control System**. 

## Project Structure

### C2C.Core Project

The `C2C.Core` project contains the core logic of this application. It contains Contracts, Enums, Domain Entites and the Business Logic.

### C2C.ConsoleApp

The `C2C.ConsoleApp` project is the starting point of this application. It contains a Console Application which instantiates a Camera object and performs different operations.

### C2C.UnitTests

The `C2C.UnitTests` project contains all the Unit Tests for this application. It covers various scenarios to ensure that appropriate messages are returned in case of both valid and invalid inputs.


## Drawings

The **Drawings** folder contains class diagrams for this project.

## Future Enhancements

This project can be enhanced further by refining the domain entities. If a need for adding a database arises in future, Entity Framework can be integrated into this application.

Another improvement which can be made is use of Dependency Injection. Any 3rd party dependency injection utility like Unity, Autofac, Ninject, etc. can be integrated into this application.