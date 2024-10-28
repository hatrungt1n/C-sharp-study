using System;
using System.Collections.Generic;

// Abstraction: abstract base class for library items
public abstract class LibraryItem
{
    // Encapsulation: private fields with public properties
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public bool IsAvailable { get; protected set; }

    protected LibraryItem(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        IsAvailable = true;
    }

    // Abstract method for displaying item details
    public abstract void DisplayDetails();

    // Virtual method for checking out an item
    public virtual bool CheckOut()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
            return true;
        }
        return false;
    }

    // Virtual method for checking in an item
    public virtual void CheckIn()
    {
        IsAvailable = true;
    }
}

// Inheritance: Book inherits from LibraryItem
public class Book : LibraryItem
{
    public int PageCount { get; private set; }

    public Book(string title, string author, string isbn, int pageCount) 
        : base(title, author, isbn)
    {
        PageCount = pageCount;
    }

    // Polymorphism: Override the abstract method
    public override void DisplayDetails()
    {
        Console.WriteLine($"Book: {Title} by {Author}");
        Console.WriteLine($"ISBN: {ISBN}, Pages: {PageCount}");
        Console.WriteLine($"Available: {IsAvailable}");
    }
}

// Inheritance: DVD inherits from LibraryItem
public class DVD : LibraryItem
{
    public int RuntimeMinutes { get; private set; }

    public DVD(string title, string director, string isbn, int runtimeMinutes) 
        : base(title, director, isbn)
    {
        RuntimeMinutes = runtimeMinutes;
    }

    // Polymorphism: Override the abstract method
    public override void DisplayDetails()
    {
        Console.WriteLine($"DVD: {Title} directed by {Author}");
        Console.WriteLine($"ISBN: {ISBN}, Runtime: {RuntimeMinutes} minutes");
        Console.WriteLine($"Available: {IsAvailable}");
    }
}

// Composition: LibraryMember class representing a library member
public class LibraryMember
{
    public int MemberId { get; private set; }
    public string Name { get; set; }
    private List<LibraryItem> CheckedOutItems { get; set; }

    public LibraryMember(int memberId, string name)
    {
        MemberId = memberId;
        Name = name;
        CheckedOutItems = new List<LibraryItem>();
    }

    public void CheckOutItem(LibraryItem item)
    {
        if (item.CheckOut())
        {
            CheckedOutItems.Add(item);
            Console.WriteLine($"{Name} checked out: {item.Title}");
        }
        else
        {
            Console.WriteLine($"Sorry, {item.Title} is not available.");
        }
    }

    public void ReturnItem(LibraryItem item)
    {
        if (CheckedOutItems.Remove(item))
        {
            item.CheckIn();
            Console.WriteLine($"{Name} returned: {item.Title}");
        }
        else
        {
            Console.WriteLine($"Error: {Name} did not check out {item.Title}");
        }
    }

    public void DisplayCheckedOutItems()
    {
        Console.WriteLine($"Items checked out by {Name}:");
        foreach (var item in CheckedOutItems)
        {
            Console.WriteLine($"- {item.Title}");
        }
    }
}

// Coupling: library management system (loosely coupled with LibraryItem and LibraryMember)
public class LibraryManagementSystem
{
    private List<LibraryItem> _inventory;
    private List<LibraryMember> _members;

    public LibraryManagementSystem()
    {
        _inventory = new List<LibraryItem>();
        _members = new List<LibraryMember>();
    }

    public void AddItem(LibraryItem item)
    {
        _inventory.Add(item);
    }

    public void RegisterMember(LibraryMember member)
    {
        _members.Add(member);
    }

    public LibraryMember GetMember(int memberId)
    {
        return _members.Find(m => m.MemberId == memberId);
    }

    public LibraryItem FindItem(string title)
    {
        return _inventory.Find(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public void CheckOutItem(int memberId, string itemTitle)
    {
        var member = GetMember(memberId);
        var item = FindItem(itemTitle);

        if (member != null && item != null)
        {
            member.CheckOutItem(item);
        }
        else
        {
            Console.WriteLine("Member or item not found.");
        }
    }

    public void ReturnItem(int memberId, string itemTitle)
    {
        var member = GetMember(memberId);
        var item = FindItem(itemTitle);

        if (member != null && item != null)
        {
            member.ReturnItem(item);
        }
        else
        {
            Console.WriteLine("Member or item not found.");
        }
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Library Inventory:");
        foreach (var item in _inventory)
        {
            item.DisplayDetails();
            Console.WriteLine();
        }
    }
}
