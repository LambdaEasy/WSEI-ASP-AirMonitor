# AirMonitor

## Project Description

### Origin

AirMonitor is a project created under the university ([WSEI](https://en.wsei.edu.pl/)) subject `Programming in ASP.NET environment` as a term passing grade.

### Objectives

To create a sample ASP.core application.

Some of main objectives included:

- usage of .Net DI,
- usage of Razor Views (preferably over Rest),
- usage of ORM (preferably EF),
- TODO objectives...

### Personal goals

As a java spring developer approaching c# .net.  
I have focused on introducing simplified common concepts I use every day into a c# application. Those were often brutally forced, which gave me solid idea on language and framework differences.  

### Application Description

`AirMonitor` is an application which integrates with [airly](https://airly.org/)
to monitor and display current air and wether condition nearby user.

## Application Architecture

Application was written in DDD approach connected with hexagonal architecture.

### Hexagonal Architecture - Layers

Application has been written in `Hexagonal Architecture`. With a heavy focus on separation of concern.

Each individual layer has been excluded to a separate c# class library. With minimum dependency on another projects.

In order to achieve this design application has two core layers:

- `AirMonitor.Core`,
- `AirMonitor.Domain`.

Which accordingly describe application internal api and actions, common objects and their mappings between different layers.

To integrate all separated layers project `AirMonitor.Infrastructure` was introduced.

Finally dependency injection of which of application components is performed in `AirMonitor.Web`.  
Personally I don't like this approach but It was forced over by .NET framework.

#### Personal Note

Creating modular/hexagonal application in c#.net felt really forced.  
I have this wired filling that .net really wants you to put all of your code in Razor views.

And that is not a good thing in my honest and humble opinion...
