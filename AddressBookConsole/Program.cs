using AddressBookConsole.Services;

var Menu = new MainMenu();

Menu.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";


while (true)
{
    Console.Clear();
    Menu.OptionsMenu();

}
