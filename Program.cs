using System;
using System.Collections.Generic;

namespace AddressBookApp
{
    class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    class AddressBook
    {
        private List<Contact> contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            Console.WriteLine("Contact added successfully.");
        }

        public void DisplayContacts()
        {
            Console.WriteLine("Contacts in Address Book:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Address: {contact.Address}, {contact.City}, {contact.State}, {contact.Zip}");
                Console.WriteLine($"Phone: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();

            Console.WriteLine("Welcome to Address Book");

            bool continueAdding = true;
            while (continueAdding)
            {
                Contact newContact = ReadContactFromConsole();
                addressBook.AddContact(newContact);

                Console.Write("Do you want to add another contact? (yes/no): ");
                string response = Console.ReadLine();
                continueAdding = response.Equals("yes", StringComparison.OrdinalIgnoreCase);
            }

            addressBook.DisplayContacts();
        }

        static Contact ReadContactFromConsole()
        {
            Contact contact = new Contact();

            Console.Write("Enter First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("Enter Address: ");
            contact.Address = Console.ReadLine();

            Console.Write("Enter City: ");
            contact.City = Console.ReadLine();

            Console.Write("Enter State: ");
            contact.State = Console.ReadLine();

            Console.Write("Enter Zip: ");
            contact.Zip = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            contact.PhoneNumber = Console.ReadLine();

            Console.Write("Enter Email: ");
            contact.Email = Console.ReadLine();

            return contact;
        }
    }
}