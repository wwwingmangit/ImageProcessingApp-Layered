# Next-Gen Coding with My Daughter: Software Architecture!
## Monolithic Layered Approach

This project is about developing an app that processes images, initially applying a grayscale filter. This concept can extend to image analysis, AI, and more, but we'll focus on the architecture and the usage of AI to assist us in building this solution.

Diagrams are essential for better architecture designs. I recommend using at least three types:
- Layers architecture diagram
- Dependencies diagram
- Workflow diagram

## Workflow Diagram

Let's begin with the workflow diagram, as it quickly provides a clearer sense of how the application will function. This visual representation helps to understand the process flow and interactions within the system, making it an excellent starting point for discussing and refining the architecture. You can see I use three layers: Presentation, BusinessLogic, and DataAccess, which is a very traditional and efficient way to build applications. However, I will suggest in a second an optional fourth layer for a better design.

## Layers Architecture Diagram

The architecture diagram illustrates the structure of our monolithic application, divided into distinct layers to promote modularity and separation of concerns. When building the solution, I recommend replicating this concept and building one project per layer. We will use 4 layers, which is an improvement of the three layers described above, for reasons I will describe later.

At the top, the Presentation Layer handles all user interactions through controllers and views, providing interfaces for uploading images, selecting filters, and displaying results. Below it, the Business Logic Layer contains the core functionality of the application, including services that process images and apply filters. The Data Access Layer sits beneath, managing data persistence and retrieval by interacting with the database context. At the foundation, the Models Layer defines the data structures used across all other layers, ensuring consistent representation of entities like ImageModel throughout the application.
Importance of Adding a Fourth Layer for Models

Introducing a separate Models Layer as the fourth layer enhances the application's architecture by centralizing the data models shared across multiple layers. This separation allows the Presentation, Business Logic, and Data Access Layers to reference the Models Layer independently without creating tight coupling or circular dependencies between themselves. By isolating the data structures, we promote reusability and maintainability, making it easier to manage changes to models without impacting the business logic or presentation code directly. This approach leads to a cleaner, more modular architecture that can scale and adapt as the application grows. You can see that more clearly when building the Dependencies diagram.

## To build / run
This project was built using .Net Code under visual studio but is fully compatible with Linux.

For Windows: After cloning the repository, open Visual Studio, load the solution and run it.

For Linux: After cloning the repository, run:
```
dotnet restore
dotnet build
dotnet run --project PresentationLayer/PresentationLayer.csproj
```
