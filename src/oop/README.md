# Library Management System

This project demonstrates a simple library management system implemented in C#, showcasing various Object-Oriented Programming (OOP) concepts in a study-related context.

## OOP Concepts Demonstrated

1. **Encapsulation**: 
   - Private fields with public properties in `LibraryItem` and `LibraryMember` classes.

2. **Inheritance**: 
   - `Book` and `DVD` inherit from the abstract `LibraryItem` class.

3. **Abstraction**: 
   - `LibraryItem` is an abstract base class with an abstract `DisplayDetails()` method.

4. **Polymorphism**: 
   - `Book` and `DVD` override the `DisplayDetails()` method with their own implementations.

5. **Composition**: 
   - `LibraryMember` has a list of `LibraryItem`s (checked out items).

6. **Coupling**: 
   - `LibraryManagementSystem` is loosely coupled with `LibraryItem` and `LibraryMember`, interacting with them through their public interfaces.

## System Features

This library system allows for:
- Checking books in and out
- Managing member information
- Tracking book availability

It provides a foundation that can be easily extended with additional features such as:
- Due dates
- Fines
- Different types of library items

## Future Enhancements

The system can be further improved by adding:
- Database integration for persistent storage
- User interface (console-based or graphical)
- Reporting functionality
- Search capabilities
- Reservation system for items currently checked out
