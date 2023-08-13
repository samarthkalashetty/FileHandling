using System;
using System.Collections.Generic;

class AddressBookMain
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Address Book Program in C#");

        // Create a list to store addresses
        List<Address> addressList = new List<Address>();

        // Your code logic for the address book can go here

        Console.WriteLine("Address Book program has ended.");
    }
}

class Address
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string AddressInfo { get; set; }
}