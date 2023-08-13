using System;
using System.Collections.Generic;

class Contact
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Contact otherContact = (Contact)obj;
        return Name.Equals(otherContact.Name, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Contact> addressBook = new List<Contact>();

        AddContact(addressBook, "Alice", "123-456-7890", "alice@example.com");
        AddContact(addressBook, "Bob", "987-654-3210", "bob@example.com");
        AddContact(addressBook, "Alice", "111-222-3333", "newalice@example.com"); // Duplicate entry

        foreach (Contact contact in addressBook)
        {
            Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
        }
    }

    static void AddContact(List<Contact> addressBook, string name, string phoneNumber, string email)
    {
        Contact newContact = new Contact { Name = name, PhoneNumber = phoneNumber, Email = email };

        if (!addressBook.Contains(newContact))
        {
            addressBook.Add(newContact);
            Console.WriteLine("Contact added successfully.");
        }
        else
        {
            Console.WriteLine("Duplicate contact. Not added.");
        }
    }
}
