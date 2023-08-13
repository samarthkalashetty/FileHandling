using System;
using System.Collections.Generic;
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
            new Contact { Name = "Alice", PhoneNumber = "123-456-7890", Email = "alice@example.com", City = "Solapur", State = "Maharashtra" },
            new Contact { Name = "Bob", PhoneNumber = "987-654-3210", Email = "bob@example.com", City = "Pune", State = "CA" }
        };

        List<Contact> addressBook2 = new List<Contact>
        {
            new Contact { Name = "Charlie", PhoneNumber = "111-222-3333", Email = "charlie@example.com", City = "New York", State = "NY" },
            new Contact { Name = "David", PhoneNumber = "555-666-7777", Email = "david@example.com", City = "Chicago", State = "IL" }
        };

        List<Contact> allContacts = new List<Contact>();
        allContacts.AddRange(addressBook1);
        allContacts.AddRange(addressBook2);

        Dictionary<string, List<Contact>> cityDictionary = BuildCityDictionary(allContacts);
        Dictionary<string, List<Contact>> stateDictionary = BuildStateDictionary(allContacts);

        Console.Write("Enter the city to view persons: ");
        string viewCity = Console.ReadLine();

        if (cityDictionary.ContainsKey(viewCity))
        {
            Console.WriteLine($"Persons in {viewCity}:");
            foreach (Contact contact in cityDictionary[viewCity])
            {
                Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
            }
        }
        else
        {
            Console.WriteLine("City not found.");
        }

        Console.Write("Enter the state to view persons: ");
        string viewState = Console.ReadLine();

        if (stateDictionary.ContainsKey(viewState))
        {
            Console.WriteLine($"Persons in {viewState}:");
            foreach (Contact contact in stateDictionary[viewState])
            {
                Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
            }
        }
        else
        {
            Console.WriteLine("State not found.");
        }
    }

    static Dictionary<string, List<Contact>> BuildCityDictionary(List<Contact> contacts)
    {
        var cityDictionary = new Dictionary<string, List<Contact>>();

        foreach (Contact contact in contacts)
        {
            if (!cityDictionary.ContainsKey(contact.City))
            {
                cityDictionary[contact.City] = new List<Contact>();
            }
            cityDictionary[contact.City].Add(contact);
        }

        return cityDictionary;
    }

    static Dictionary<string, List<Contact>> BuildStateDictionary(List<Contact> contacts)
    {
        var stateDictionary = new Dictionary<string, List<Contact>>();

        foreach (Contact contact in contacts)
        {
            if (!stateDictionary.ContainsKey(contact.State))
            {
                stateDictionary[contact.State] = new List<Contact>();
            }
            stateDictionary[contact.State].Add(contact);
        }

        return stateDictionary;
    }
}
