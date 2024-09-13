using System.Data.Common;

public class BandManager
{
    public List<Band> Bands = new List<Band>();
    public List<Musician> musicians = new List<Musician>();

    public void AddBand()
    {
        bool toInsert = true;
        while (toInsert)
        {
            Console.WriteLine("What is your band's name?");
            Band band = new Band();
            band.Name = Console.ReadLine();

            Bands.Add(band);
            Console.WriteLine("Would you like to introduce another band? (yes/no)");
            var answer = Console.ReadLine();
            if (answer.ToLower() == "yes")
            {

            }
            else if (answer.ToLower() == "no")
            {
                toInsert = false;
            }
        }
    }

    public Band SelectBand()
    {
        Console.WriteLine("Let us welcome the following bands to the stage! Please pick a band from the list by typing a number: ");
        AnnounceBands();

        Band input = null;
        while (input == null)
        {
            int chosenId = Convert.ToInt32(Console.ReadLine());
            if (chosenId >= 1 && chosenId <= Bands.Count)
            {
                return Bands[chosenId - 1];
            }
            else
            {
                Console.WriteLine("Band Id " + chosenId + " does not exist. Please introduce another id: ");
            }
        }
        return input;
    }

    public void AnnounceBands()
    {
        Console.WriteLine("All Bands on the Stage: ");
        foreach (var bandName in Bands)
        {
            bandName.Announce();
        }
    }
}