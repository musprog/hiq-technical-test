# HiQ Skåne Backend Test

## Questions & Answers 

# 1. How long time did you end up spending on this coding test? 

I have spent roughly eight hours on the development and testing of this coding assigment.

# 2. Explain why you chose the code structure(s) you used in your solution.

I have used command patterns to establish code reusability, scalability, and readability. Interfaces promote abstraction, flexibility, and testability. Finally, logging aids in debugging and monitoring.

 Command Pattern: Helps to encapsulate each request as an object.

 Interfaces: Ensure consistent behavior (ICommand, ICommandHandler).

 Logging & Exception Handling: Logging provides insight into operations, and exception handling ensures robustness (SimulationLogger, ExceptionHandler, SimulationException).

 Utilities: Make the code more modular and maintainable (SimulationIO, Mapper).

 Models: Represent data structures (Car, Room, Directions, Movements).

 Dependency Injection: Makes the app flexible and testable.

# 3. What would you add to your solution if you had more time? This question is especially important if you did not spend much time on the coding test - use this as an opportunity to explain what your solution is missing.

With more time the solution could be improved with the following:

 Command Handling: Implement command to undo actions.

 Service Layer Pattern: Using this pattern will separate business logic and other layers. 

 Improved Error Handling and Validation: Provide detailed error messages and better input validation.

 Performance: Handling multiple cars and add performance metrics.

 Additional Features: Support for multiple cars, room layouts, flexible rotation.

 User Interface: GUI and a web solution for better user interaction.

 Documentation: Well written documentation and teknik spec.

 Logging and Monitoring: Implement logging and a monitoring functions.

# 4. What did you think of this recruitment test?

The assignment is well-thought-out and covers very important aspects, from design patterns and interfaces to logging and exception handling. With these aspects, it is clear to see the developer’s skills and ability to solve problems and build useful code. The assignment also tests the developer’s ability and knowledge of modern software techniques and design philosophy. Finally, I think the assignment covers enough aspects to evaluate a skilled developer. Time is a very important key factor and affects the productivity and quality of the solution.

# Overview
This is a console application built using Visual Studio 2022 (v17.9.6). The application includes logging functionality and is tested using the NUnit framework with Moq for mocking.

# Prerequisites
Visual Studio 2022 (v17.9.6)
.NET SDK (compatible with your project)
NuGet packages:
Microsoft.Extensions.Logging
Microsoft.Extensions.Logging.Console
NUnit
Moq
NUnit3TestAdapter
# Installation
# Clone the repository:

git clone https://github.com/musprog/hiq-technical-test.git

Answers.md file hiq-technical-test\Backend only
To run hiq-technical-test\Backend only\RadioControlledCarSimulator

# Open the project in Visual Studio:
Open Visual Studio 2022.
Select File > Open > Project/Solution.
Navigate to the cloned repository and open the solution file (.sln).
# Restore NuGet packages:
In Visual Studio, right-click on the solution in the Solution Explorer.
Select Restore NuGet Packages.
Building the Application
# Build the solution:
In Visual Studio, select Build > Build Solution or press Ctrl+Shift+B.
Running the Application
# Run the application:
In Visual Studio, press F5 or select Debug > Start Debugging.