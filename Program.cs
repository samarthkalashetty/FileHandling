using System;
using System.Collections.Generic;

class Contact : IComparable<Contact>
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public int CompareTo(Contact other)
    {
        // Compare by City, then by State, then by Zip
        int cityComparison = string.Compare(City, other.City, StringComparison.OrdinalIgnoreCase);
        if (cityComparison != 0) return cityComparison;

        int stateComparison = string.Compare(State, other.State, StringComparison.OrdinalIgnoreCase);
        if (stateComparison != 0) return stateComparison;

        return string.Compare(ZipCode, other.ZipCode, StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return $"Name: {Name}, Phone: {PhoneNumber}, Email: {Email}, City: {City}, State: {State}, Zip: {ZipCode}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Contact> addressBook = new List<Contact>
        {
            new Contact { Name = "Alice", PhoneNumber = "123-456-7890", Email = "alice@example.com", City = "New York", State = "NY", ZipCode = "10001" },
            new Contact { Name = "Bob", PhoneNumber = "987-654-3210", Email = "bob@example.com", City = "Los Angeles", State = "CA", ZipCode = "90001" },
            new Contact { Name = "Charlie", PhoneNumber = "111-222-3333", Email = "charlie@example.com", City = "New York", State = "NY", ZipCode = "10002" },
            new Contact { Name = "David", PhoneNumber = "555-666-7777", Email = "david@example.com", City = "Chicago", State = "IL", ZipCode = "60601" }
        };

        Console.WriteLine("Original Address Book:");
        PrintContacts(addressBook);

        Console.Write("\nEnter 'city', 'state', or 'zip' to sort the address book: ");
        string sortBy = Console.ReadLine();

        List<Contact> sortedAddressBook = SortAddressBook(addressBook, sortBy);

        if (sortedAddressBook != null)
        {
            Console.WriteLine($"\nSorted Address Book by {sortBy}:");
            PrintContacts(sortedAddressBook);
        }
        else
        {
            Console.WriteLine("Invalid input. No sorting performed.");
        }
    }

    static List<Contact> SortAddressBook(List<Contact> contacts, string sortBy)
    {
        switch (sortBy.ToLower())
        {
            case "city":
                contacts.Sort((contact1, contact2) => contact1.City.CompareTo(contact2.City));
                break;
            case "state":
                contacts.Sort((contact1, contact2) => contact1.State.CompareTo(contact2.State));
                break;
            case "zip":
                contacts.Sort((contact1, contact2) => contact1.ZipCode.CompareTo(contact2.ZipCode));
                break;
            default:
                return null;
        }

        return contacts;
    }

    static void PrintContacts(List<Contact> contacts)
    {
        foreach (Contact contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }
}
