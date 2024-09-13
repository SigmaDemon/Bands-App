using Microsoft.VisualBasic;

BandManager bandManager = new BandManager();
bandManager.AddBand();

// Make this select bands and add musicians to it
var band = bandManager.SelectBand();
Console.WriteLine("You selected " + band.Name);

Console.WriteLine("Type 'Add' to add a musician.");
Console.WriteLine("Type 'Announce' to announce the band.");
Console.WriteLine("Type 'Select' to select a band to add a member.");
Console.WriteLine("Type 'Remove' to announce the band.");
Console.WriteLine("Type 'Quit' to quit the application.");

var repeat = true;
while (repeat)
{
    Console.WriteLine("Add, Announce, Select, Remove, or Quit?" + " - FOR BAND <<" + band.Name + ">>");

    string action = Console.ReadLine();

    switch (action)
    {
        case "Add":
            {
                band.AddMusician();
                break;
            }
        case string s when s.StartsWith("Add"):
            {
                var arguments = action.Split(' ');
                band.AddMusician(arguments);
                break;
            }
        case "Announce":
            {
                bandManager.AnnounceBands();
                break;
            }
        case "Select":
            {
                band = bandManager.SelectBand();
                Console.WriteLine("You have now selected " + band.Name);
                break;
            }
        case "Remove":
            {
                band.RemoveMusician();
                break;
            }
        case string r when r.StartsWith("Remove"):
            {
                var arguments = action.Split(' ');
                band.RemoveMusician(arguments);
                break;
            }
        case "Quit":
            {
                repeat = false;
                break;
            }
        default:
            {
                Console.WriteLine(action + " is not a valid command");
                break;
            }
    }
}