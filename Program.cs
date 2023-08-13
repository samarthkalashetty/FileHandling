using System;
using System.Collections.Generic;

namespace AddressBookApp
{
    class contact
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
        }

        public void EditContact(string firstName, string lastName)
        {
            Contact contact = FindContact(firstName, lastName);
            if (contact != null)
            {
                Console.WriteLine($"Editing contact: {contact.FirstName} {contact.LastName}");
                Console.Write("Enter new Address: ");
                contact.Address = Console.ReadLine();

                Console.Write("Enter new City: ");
                contact.City = Console.ReadLine();

                Console.Write("Enter new State: ");
                contact.State = Console.ReadLine();

                Console.Write("Enter new Zip: ");
                contact.Zip = Console.ReadLine();

                Console.Write("Enter new Phone Number: ");
                contact.PhoneNumber = Console.ReadLine();

                Console.Write("Enter new Email: ");
                contact.Email = Console.ReadLine();

                Console.WriteLine("Contact edited successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        private Contact FindContact(string firstName, string lastName)
        {
            return contacts.Find(contact =>
                contact.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                contact.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
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

            // Adding some contacts (you can add more contacts here)

            Console.WriteLine("Welcome to Address Book");

            Console.Write("Enter the first name of the contact to edit: ");
            string editFirstName = Console.ReadLine();

            Console.Write("Enter the last name of the contact to edit: ");
            string editLastName = Console.ReadLine();

            addressBook.EditContact(editFirstName, editLastName);

            addressBook.DisplayContacts();
        }
    }
}