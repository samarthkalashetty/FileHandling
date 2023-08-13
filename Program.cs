using System;
using System.Collections.Generic;

class Contact : IComparable<Contact>
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    public int CompareTo(Contact other)
    {
        return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return $"Name: {Name}, Phone: {PhoneNumber}, Email: {Email}, City: {City}, State: {State}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Contact> addressBook = new List<Contact>
        {
            new Contact { Name = "Alice", PhoneNumber = "123-456-7890", Email = "alice@example.com", City = "New York", State = "NY" },
            new Contact { Name = "Bob", PhoneNumber = "987-654-3210", Email = "bob@example.com", City = "Los Angeles", State = "CA" },
            new Contact { Name = "Charlie", PhoneNumber = "111-222-3333", Email = "charlie@example.com", City = "New York", State = "NY" },
            new Contact { Name = "David", PhoneNumber = "555-666-7777", Email = "david@example.com", City = "Chicago", State = "IL" }
        };

        Console.WriteLine("Original Address Book:");
        PrintContacts(addressBook);

        Console.WriteLine("\nEnter 'sort' to sort the address book by name:");
        string userInput = Console.ReadLine();

        if (userInput.Equals("sort", StringComparison.OrdinalIgnoreCase))
        {
            // Sort the address book by name
            addressBook.Sort();

            Console.WriteLine("\nSorted Address Book:");
            PrintContacts(addressBook);
        }
        else
        {
            Console.WriteLine("No sorting performed.");
        }
    }

    static void PrintContacts(List<Contact> contacts)
    {
        foreach (Contact contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }
}
