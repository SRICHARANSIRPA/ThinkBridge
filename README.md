# ThinkBridge

Tech Used: \
-> Language: C# \
     ->Framework: .Net Core\
->Database: SQL Server\
->ORM: Entity Framework\
->Unit Testing: XUnit \
Architecture Used:
    N-Tire Architecture\
	N-tier data applications are applications that access data and are separated into multiple logical layers, or tiers. Separating application components into discrete tiers increases the maintainability and scalability of the application.\
     ->API Layer\
	This layer only deals with the Network calls and uses the application layer to get the results.\
     ->Application Layer\
All the Business logic resides in this layer and all the Contracts (interfaces) are defined in this layer and it is independent of Database.\
     ->Infrastructure Layer\
This Layer deals with the Infrastructure like Database and it will have all the implementation of Contracts defined in the Application Layer.\
      ->Domain Layer\
	This Layer deals with the Core Entities of the Product. it is independent of all the layers.\
-> Design patterns used:\
   CQRS (Command Query Responsibility Segregation):\
	In this Application Items are added or updated by Admin. At the same time Customers try to access the same product item There is often a mismatch between the read and write representations of the data. To avoid this, we use CQRS pattern.\
	CQRS stands for Command and Query Responsibility Segregation, a pattern that separates read and update operations for a data store. Implementing CQRS in your application can maximize its performance, scalability, and security. The flexibility created by migrating to CQRS allows a system to better evolve over time and prevents update commands from causing merge conflicts at the domain level.\
    Dependency Injection:\
Dependency Injection (DI) is a design pattern used to implement IoC. It allows the creation of dependent objects outside of a class and provides those objects to a class through different ways. Using DI, we move the creation and binding of the dependent objects outside of the class that depends on them.\
   Repository Pattern:\
	The repository pattern is intended to create an abstraction layer between the data access layer and the business logic layer of an application.
