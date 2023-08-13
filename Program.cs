using System;
using System.Collections.Generic;
using System.IO;

class Contact
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Contact> addressBook = new List<Contact>
        {
            new Contact { Name = "Alice", PhoneNumber = "123-456-7890", Email = "alice@example.com" },
            new Contact { Name = "Bob", PhoneNumber = "987-654-3210", Email = "bob@example.com" }
        };

        string filePath = "addressbook.txt";

        // Write address book to file
        WriteToFile(addressBook, filePath);

        // Read address book from file
        List<Contact> readAddressBook = ReadFromFile(filePath);

        // Display the read contacts
        foreach (Contact contact in readAddressBook)
        {
            Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
        }
    }

    static void WriteToFile(List<Contact> contacts, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Contact contact in contacts)
            {
                writer.WriteLine($"{contact.Name},{contact.PhoneNumber},{contact.Email}");
            }
        }

        Console.WriteLine("Address book written to file.");
    }

    static List<Contact> ReadFromFile(string filePath)
    {
        List<Contact> addressBook = new List<Contact>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    addressBook.Add(new Contact
                    {
                        Name = parts[0],
                        PhoneNumber = parts[1],
                        Email = parts[2]
                    });
                }
            }
        }

        Console.WriteLine("Address book read from file.");
        return addressBook;
    }
}
