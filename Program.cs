using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Contact
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Contact> addressBook1 = new List<Contact>
        {
            new Contact { Name = "Samarth", PhoneNumber = "9960852612", Email = "Sam9960852612@gmail.com", City = "Solapur", State = "Maharashtra" },
            new Contact { Name = "Bob", PhoneNumber = "987-654-3210", Email = "bob@example.com", City = "Los Angeles", State = "CA" }
        };

        List<Contact> addressBook2 = new List<Contact>
        {
            new Contact { Name = "Charlie", PhoneNumber = "111-222-3333", Email = "charlie@example.com", City = "New York", State = "NY" },
            new Contact { Name = "David", PhoneNumber = "555-666-7777", Email = "david@example.com", City = "Chicago", State = "IL" }
        };

        List<Contact> allContacts = new List<Contact>();
        allContacts.AddRange(addressBook1);
        allContacts.AddRange(addressBook2);

        Console.Write("Enter the city to search: ");
        string searchCity = Console.ReadLine();

        Console.Write("Enter the state to search: ");
        string searchState = Console.ReadLine();

        List<Contact> searchResults = SearchContactsByCityOrState(allContacts, searchCity, searchState);

        if (searchResults.Count > 0)
        {
            Console.WriteLine($"Search results in {searchCity}, {searchState}:");
            foreach (Contact contact in searchResults)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
            }
        }
        else
        {
            Console.WriteLine("No results found.");
        }
    }

    static List<Contact> SearchContactsByCityOrState(List<Contact> contacts, string city, string state)
    {
        return contacts.Where(contact =>
            contact.City.Equals(city, StringComparison.OrdinalIgnoreCase) ||
            contact.State.Equals(state, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
