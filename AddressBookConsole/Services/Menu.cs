using AddressBookConsole.Interfaces;
using AddressBookConsole.Models;
using Newtonsoft.Json;
using System;
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
        Console.WriteLine("1. Create new contact");
        Console.WriteLine("2. Show all contacts");
        Console.WriteLine("3. Search contact");
        Console.WriteLine("4. Delete contact");
        Console.Write("Choose an option from the menu above:");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1": Option1(); break;
            case "2": Option2(); break;
            case "3": Option3(); break;
            case "4": Option4(); break;
        }
    }

    private void Option1()
    {
        Console.Clear();
        Console.WriteLine("Add new contact");

        Contact contact = new Contact();

        Console.Write("First name:");
        contact.FirstName = Console.ReadLine() ?? "";
        Console.Write("Last name:");
        contact.LastName = Console.ReadLine() ?? "";
        Console.Write("Email address:");
        contact.Email = Console.ReadLine() ?? "";
        Console.Write("Phone number:");
        contact.PhoneNumber = Console.ReadLine() ?? "";
        Console.Write("Address:");
        contact.Address = Console.ReadLine() ?? "";
        Console.Write("Postal code:");
        contact.PostalCode = Console.ReadLine() ?? "";
        Console.Write("City:");
        contact.City = Console.ReadLine() ?? "";

        contacts.Add(contact);
        Console.Clear();
        Console.WriteLine("Contact added!");
        Console.Clear();

        file.Save(FilePath, JsonConvert.SerializeObject(contacts ));

    }
    private void Option2()
    {
        try
        {
            var items = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath));
            if (items != null)
                contacts = items;



        }
        catch { }

        foreach (var contact in contacts)
        {
            Console.WriteLine("\n" + contact.FirstName + " " + contact.LastName + "\n" + contact.Address + "\n" + contact.PostalCode + "\n" + contact.City + "\n" + contact.PhoneNumber + "\n" + contact.Email + "\n");
            

        }

        Console.ReadKey();

    }

    private void Option3()
    {

    }
    private void Option4()
    {

    }


}
