var library = new LibraryManagementSystem();

library.AddItem(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565", 180));
library.AddItem(new Book("To Kill a Mockingbird", "Harper Lee", "9780446310789", 281));
library.AddItem(new DVD("Inception", "Christopher Nolan", "5051892123693", 148));

library.RegisterMember(new LibraryMember(1, "Alice"));
library.RegisterMember(new LibraryMember(2, "Bob"));

Console.WriteLine("Initial Inventory:");
library.DisplayInventory();

Console.WriteLine("\nChecking out items:");
library.CheckOutItem(1, "The Great Gatsby");
library.CheckOutItem(2, "Inception");

Console.WriteLine("\nUpdated Inventory:");
library.DisplayInventory();

Console.WriteLine("\nReturning an item:");
library.ReturnItem(1, "The Great Gatsby");

Console.WriteLine("\nFinal Inventory:");
library.DisplayInventory();

Console.WriteLine("\nChecked out items for Bob Smith:");
var member = library.GetMember(2);
member.DisplayCheckedOutItems();
