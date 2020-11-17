# timebox
A simple application to allow time boxing

## Running the application

Install Tye to run the application install from [here](https://github.com/dotnet/tye)

Run ```tye run``` with both dontet 5 sdk and dotnet 3.1 sdk installed.

Then navigate to dashboard running [here](http://localhost:8000)

## Architecture

This application aims to follow a Clean or Onion archietcture.

![onion architecture](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/media/image5-7.png)

This is then tied together using a monolith of microservices approach using Domain Driven Design at the core of the application.

The projects that make up the sections of a module which is a set area of the domain (could be it's own service in a microservice architecture) are layed out using the following project structure:

> This section will use the simple example of an Appointment module to show how this could be organised


### Timebox.Appointment.Domain
This section will make up the core domain for appointments this will include the following items:

* Entities
* Value Objects
* Domain Events
* Custom Domain Exceptions
* Enumerations

> This should reference *NONE* of the projects listed below

### Timebox.Appointment.Application.Interfaces
This section will mark out the interfaces which the application layer declares to be implemented by the infastructure layer. This can be things such as:

* Repositories
* Http Clients
* Third Party Services
* Identity Providers

These should only declare the functionality needed by the application and then be implemented by the Infastructure project.

> This should *ONLY* reference the ```Domain``` project. 
> *This can also include interfaces to be implemented by the application layer i.e. Application Services*

### Timebox.Appointment.Application
This section will define anything relevant to this applications interface (*WITHOUT* tying it to a specific framework or transport mechanism (i.e. HTTP or Grpc) this can include the following:

* Application Logic
* Models (DTOs, View Models ...)
* Validators
* Exceptions
* Commands/Queries (Request made into the system)

> This project can reference *BOTH* the ```Application.Interfaces``` and ```Domain``` projects it should *NOT* reference the ```Infastructure``` project.


### Timebox.Appointment.Infastructure
This section shall include all implementations declared in the Application.Interfaces this can include hard dependancies such as:

* Databases
* Messaging Pipelines
* Third Party Access
* Identity Services
* Persistance Providers

> This should *ONLY* reference the ```Application.Interfaces``` project.
 
### Timebox.Appointment.Api
This section will tie all of the other projects together and declare the transport layer (how data is sent and returned to the client) this will also wire up all of the dependancies and declare the implementations of these from the relevant projects.

This could use for example a ASP.NET CORE Controller to receive and response to request from a client.

> This can reference *ALL* of the projects listed above.
