using PRG_ASG;
// Name: Natalie Chan
// Student Number: S10220879H
void DisplayGuest()
{
    string[] info = File.ReadAllLines("Guests.csv");

    for (int i = 0; i < info.Length; i++)
    {
        string[] data = info[i].Split(',');
        Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10}", data[0], data[1], data[2], data[3]);
    }

}
// Name: Isaac Khoo
// Student Number: S10244252C

void Displayroom()
{
    Console.WriteLine("List Information Of All Rooms: ");
    string[] roominfo = File.ReadAllLines("Rooms.csv");
    string[] roomdata = roominfo[0].Split(',');
    List<Room> roomlist = new List<Room>();

    for (int i = 1; i < roominfo.Length; i++)
    {
        string[] roomcontent = roominfo[1].Split(',');
        Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", roomcontent[0], roomcontent[1], roomcontent[2], roomcontent[3]);
    }
}