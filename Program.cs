using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Microsoft.VisualBasic.FileIO;

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

        // Write the address book to a CSV file
        using (var writer = new StreamWriter("addressbook.csv"))
        {
            foreach (var contact in addressBook)
            {
                writer.WriteLine($"{contact.Name},{contact.PhoneNumber},{contact.Email}");
            }
        }

        Console.WriteLine("Address book written to CSV file.");

        // Read the address book from the CSV file
        using (var parser = new TextFieldParser("addressbook.csv"))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                if (fields != null && fields.Length >= 3)
                {
                    Contact contact = new Contact
                    {
                        Name = fields[0],
                        PhoneNumber = fields[1],
                        Email = fields[2]
                    };

                    Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
                }
            }
        }
    }
}
