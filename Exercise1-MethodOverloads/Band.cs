using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public class Band
{
    public int bandId;
    public string Name;
    public List<Musician> Musicians = new List<Musician>();

    public void Announce()
    {
        // Console.WriteLine("Welcome " + Name + " to the stage!");
        Console.WriteLine("Welcome " + Name + " to the stage!");
        foreach (var musician in Musicians)
        {
            musician.Announce();
        }
    }

    public void AddMusician()
    {
        Console.WriteLine("What is the name of the musician you want to add to " + Name + "?");
        var name = Console.ReadLine();
        Console.WriteLine("What instrument does " + name + " play?");
        var instrument = Console.ReadLine();
        AddMusician(name, instrument);  
    }

    public void AddMusician(string name, string instrument)
    {
        int index = !Musicians.Any() ? 1 : Musicians.Count + 1;

        var musician = new Musician();
        musician.id = index;
        musician.Name = name;
        musician.Instrument = instrument;
        Musicians.Add(musician);
        Console.WriteLine(musician.Name + " was added with id " + index);
    }

    public void AddMusician(string[] arguments)
    {
        if (arguments.Length == 3)
        {
            AddMusician(arguments[1], arguments[2]);
        }
        else
        {
            AddMusician();
        }
    }

    public void RemoveMusician()
    {
        Console.WriteLine("Which member would you like to remove from the list below? (please provide musician id)");
        Console.WriteLine("List: ");

        foreach (var musician in Musicians)
        {
            musician.Announce();
        }

        int chosenId = Convert.ToInt32(Console.ReadLine());
        RemoveMusician(chosenId);
    }

    public void RemoveMusician(int id)
    {
        bool input = true;
        while (input)
        {
            // Get User Input
            int chosenId = id;

            // Check if id exists
            int musicianIdFound = 0;
            foreach (var musician in Musicians)
            {
                if (musician.id == chosenId)
                {
                    musicianIdFound = chosenId;
                }
            }

            // Message to Provide Another Id
            if (musicianIdFound == chosenId)
            {
                foreach (var musician in Musicians)
                {
                    if (musician.id == musicianIdFound)
                    {
                        Musicians.Remove(musician);
                        Console.WriteLine("Musician with id " + musician.id + " and name " + musician.Name + " has been removed.");

                        // Adjust IDs after removal
                        for (int i = 0; i < Musicians.Count; i++)
                        {
                            Musicians[i].id = i + 1;
                        }
                        break;
                    }
                }
                input = false;
            }
            else
            {
                Console.WriteLine("Musician Id " + chosenId + " does not exist. Please introduce another id: ");
                input = false;
            }
        }
    }

    public void RemoveMusician(string[] arguments)
    {
        if (int.TryParse(arguments[1], out int id))
        {
            if (arguments.Length == 2)
            {
                RemoveMusician(id);
            }
            else
            {
                RemoveMusician();
            }
        }
    }
}