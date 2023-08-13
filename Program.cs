
using System;
using System.Collections.Generic;

namespace UC6
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

    class AddressBookSystem
    {
        private Dictionary<string, AddressBook> addressBooks = new Dictionary<string, AddressBook>();

        public void AddAddressBook(string name)
        {
            addressBooks[name] = new AddressBook();
            Console.WriteLine($"Address Book '{name}' added.");
        }

        public void AddContactToAddressBook(string name, Contact contact)
        {
            if (addressBooks.TryGetValue(name, out AddressBook addressBook))
            {
                addressBook.AddContact(contact);
            }
            else
            {
                Console.WriteLine($"Address Book '{name}' not found.");
            }
        }

        public void DisplayAddressBookContacts(string name)
        {
            if (addressBooks.TryGetValue(name, out AddressBook addressBook))
            {
                addressBook.DisplayContacts();
            }
            else
            {
                Console.WriteLine($"Address Book '{name}' not found.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AddressBookSystem addressBookSystem = new AddressBookSystem();

            Console.WriteLine("Welcome to Address Book System");

            bool continueOperating = true;
            while (continueOperating)
            {
                Console.WriteLine("1. Add Address Book");
                Console.WriteLine("2. Add Contact to Address Book");
                Console.WriteLine("3. Display Address Book Contacts");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Address Book Name: ");
                        string addressBookName = Console.ReadLine();
                        addressBookSystem.AddAddressBook(addressBookName);
                        break;

                    case 2:
                        Console.Write("Enter Address Book Name: ");
                        string bookName = Console.ReadLine();
                        Contact newContact = ReadContactFromConsole();
                        addressBookSystem.AddContactToAddressBook(bookName, newContact);
                        break;

                    case 3:
                        Console.Write("Enter Address Book Name: ");
                        string displayBookName = Console.ReadLine();
                        addressBookSystem.DisplayAddressBookContacts(displayBookName);
                        break;

                    case 4:
                        continueOperating = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }
            }
        }

    }
}