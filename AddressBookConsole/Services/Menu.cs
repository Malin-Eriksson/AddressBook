using AddressBookConsole.Interfaces;
using AddressBookConsole.Models;
using System.Runtime.CompilerServices;

namespace AddressBookConsole.Services;

internal class Menu
{
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

        IContact contact = new Contact();

        Console.Write("First name:");
        contact.FirstName = Console.ReadLine() ?? null!;
        Console.Write("Last name:");
        contact.LastName = Console.ReadLine() ?? null!;
        Console.Write("Email address:");
        contact.Email = Console.ReadLine() ?? null!;
        Console.Write("Phone number:");
        contact.PhoneNumber = Console.ReadLine() ?? null!;
        Console.Write("Address:");
        contact.Address = Console.ReadLine() ?? null!;
        Console.Write("Postal code:");
        contact.PostalCode = Console.ReadLine() ?? null!;
        Console.Write("City:");
        contact.City = Console.ReadLine() ?? null!;


    }
    private void Option2()
    {

    }
    private void Option3()
    {

    }
    private void Option4()
    {

    }


}
