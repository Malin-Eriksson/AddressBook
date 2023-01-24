using AddressBookConsole.Interfaces;
using AddressBookConsole.Models;
using Newtonsoft.Json;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace AddressBookConsole.Services;

internal class Menu
{
    public List<Contact> contacts = new List<Contact>();

    private FileService file = new FileService();

    public string FilePath { get; set; } = null!;

    public void OptionsMenu()
    {
        Console.Clear();
        Console.WriteLine("ADDRESS BOOK");
        Console.WriteLine("-----------------------------------------\n");
        Console.WriteLine("1. Create new contact");
        Console.WriteLine("2. Show all contacts");
        Console.WriteLine("3. Show contact");
        Console.WriteLine("4. Delete contact");
        Console.WriteLine(""); 
        Console.WriteLine("9. Exit");
        Console.Write("\nChoose an option from the menu above: ");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1": Option1(); break;
            case "2": Option2(); break;
            case "3": ShowSelectedContact(); break;
            case "4": Option4(); break;
            case "9": Environment.Exit(1); break;
        }
    }

    private void Option1()
    {
        Console.Clear();
        Console.WriteLine("ADD NEW CONTACT");
        Console.WriteLine("-----------------------------------------");

        Contact contact = new Contact();

        Console.Write("First name: ");
        contact.FirstName = Console.ReadLine() ?? "";
        Console.Write("Last name: ");
        contact.LastName = Console.ReadLine() ?? "";
        Console.Write("Email address: ");
        contact.Email = Console.ReadLine() ?? "";
        Console.Write("Phone number: ");
        contact.PhoneNumber = Console.ReadLine() ?? "";
        Console.Write("Street address: ");
        contact.Address = Console.ReadLine() ?? "";
        Console.Write("Postal code: ");
        contact.PostalCode = Console.ReadLine() ?? "";
        Console.Write("City: ");
        contact.City = Console.ReadLine() ?? "";

        contacts.Add(contact);
        file.Save(FilePath, JsonConvert.SerializeObject(contacts));

        Console.Clear();
        Console.WriteLine("Contact added! \nPress any key to continue...");
        Console.ReadKey();

        

    }
    private void Option2()
    {
        Console.Clear(); 

        try
        {
            var items = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath));
            if (items != null)
                contacts = items;
        }
        catch { }

        Console.WriteLine("CONTACTS");
        Console.WriteLine("-----------------------------------------");

        foreach (var contact in contacts)
        {
            Console.WriteLine("\n" + contact.FirstName + " " + contact.LastName + "\n" + contact.Email + "\n");
            
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();

    }

    private void ShowSelectedContact()
    {
        // Clear screen
        Console.Clear();

        // Read file
        try
        {
            var items = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath));
            if (items != null)
                contacts = items;
        }
        catch { }

        // Preapare screen
        Console.WriteLine("CONTACTS");
        Console.WriteLine("-----------------------------------------");

        // Declare varibles
        int ContactNumber = 0;
        string ContactNumberString = "";


        // Loop and write contacts
        // foreach (var contact in contacts)
        for (ContactNumber = 0; ContactNumber < contacts.Count; ContactNumber++)
        {
            ContactNumberString = Convert.ToString(ContactNumber);
            Console.WriteLine("\n" + ContactNumberString + " " + contacts[ContactNumber].FirstName + " " + contacts[ContactNumber].LastName + "\n" + contacts[ContactNumber].Email + "\n");
        }

        // Ask for contact to show
        Console.WriteLine("\nEnter contact number to show");
        ContactNumberString = Console.ReadLine() ?? "";

        // Show Contact
        ContactNumber = Convert.ToInt32(ContactNumberString);
        ShowContact(contacts[ContactNumber]);

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private void ShowContact(Contact c)
    {
        // Clear screen
        Console.Clear();

        // Show contact
        Console.WriteLine(c.FirstName);
        Console.WriteLine(c.LastName);
        Console.WriteLine(c.PhoneNumber);
    }



    private void Option4()
    {

    }



}
