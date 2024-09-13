using System;

public class Musician
{
    public int id; 
    public string Name;
    public string Instrument;

    public void Announce()
    {
        Console.WriteLine(id + " " + Name + " on the " + Instrument + "!");
    }
}