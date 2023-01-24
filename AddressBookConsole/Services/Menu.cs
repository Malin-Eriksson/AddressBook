using AddressBookConsole.Interfaces;
using AddressBookConsole.Models;
using Newtonsoft.Json;
using System;
using System.Linq.Expressions;
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
            case "2": ShowAllContacts(); break;
            case "3": ShowSelectedContact(); break;
            case "4": DeleteSelectedContact(); break;
            case "9": Environment.Exit(1); break;
        }
    }

    private void Option1()
    {
        // Read contacts from file
        try
        {
            var items = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath));
            if (items != null)
                contacts = items;
        }
        catch { }

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
    private void ShowAllContacts()
    {
        // List Contacts
        ListContacts();

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();

    }

    private void ShowSelectedContact()
    {

        // List Contacts
        ListContacts();

        // Ask for contact to show
        Console.WriteLine("\nEnter contact number to show");
        string ContactNumberString = Console.ReadLine() ?? "";

        // Show Contact
        int ContactNumber = Convert.ToInt32(ContactNumberString);
        ShowContact(contacts[ContactNumber]);

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private void ListContacts()
    {
        // Read contacts from file
        try
        {
            var items = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath));
            if (items != null)
                contacts = items;
        }
        catch { }

        // Clear screen
        Console.Clear();
        
        // Prepare screen
        Console.WriteLine("CONTACTS");
        Console.WriteLine("-----------------------------------------");

        // Declare varibles
        int ContactNumber = 0;
        string ContactNumberString = "";

        // Loop and write contacts
        for (ContactNumber = 0; ContactNumber < contacts.Count; ContactNumber++)
        {
            ContactNumberString = Convert.ToString(ContactNumber);
            Console.WriteLine("\n" + ContactNumberString + " " + contacts[ContactNumber].FirstName + " " + contacts[ContactNumber].LastName + "\n" + contacts[ContactNumber].Email + "\n");
        }
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

   

private void DeleteSelectedContact()
    {

        // Clear screen
        Console.Clear();

        // List Contacts
        ListContacts();

        Console.WriteLine("\nEnter contact number to DELETE");
        string ContactNumberString = Console.ReadLine() ?? "";

        // Clear screen
        Console.Clear();

        // Show Contact
        int ContactNumber = Convert.ToInt32(ContactNumberString);
        ShowContact(contacts[ContactNumber]);

        // Confirm
        Console.WriteLine("\nAre you sure you want to delete this contact? (y/n)");
        string OkToDelete = Console.ReadLine() ?? "";
        if (OkToDelete == "y" || OkToDelete == "Y")
        {
            // Delete
            try
            {
                contacts.RemoveAt(ContactNumber);
            }
            catch
            {
                Console.WriteLine("Could not delete contact.");
                return;
            }

            // Save file
            try
            {
                file.Save(FilePath, JsonConvert.SerializeObject(contacts));
            }
            catch
            {
                Console.WriteLine("Could not save list of contacts after delete.");
                return;
            }

            Console.WriteLine("Contact deleted");
        }
        else
        {
            Console.WriteLine("Vadådå?");
        }



    }



}
