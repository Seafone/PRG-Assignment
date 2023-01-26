void DisplayGuest()
{
    string[] info = File.ReadAllLines("Guests.csv");
    
    for (int i = 0; i <info.Length;i++)
    {
        string[] data = info[i].Split(',');
        Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10}",data[0], data[1], data[2], data[3]);
    }
         
}

DisplayGuest();
