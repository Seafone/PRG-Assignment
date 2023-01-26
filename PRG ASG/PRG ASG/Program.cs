using PRG_ASG;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
// Name: Isaac Khoo
// Student Number: S10244252
void startupmenu()
{
    Console.WriteLine("=======================================================================================================");
    Console.WriteLine("Select Function");
    Console.WriteLine("1: All Guests \n2: Available Rooms \n3: Register Guest \n4: Check-in guest \n5: Stay Details Of Guest \n6: Extend Stay \n0: Quit Menu");
    Console.WriteLine("=======================================================================================================");
    string selectfunction = Console.ReadLine();
    int selectedfunction = Convert.ToInt32(selectfunction);
    if (selectedfunction == 1)
    {
        DisplayGuest();
    }

    else if (selectedfunction == 2)
    {
        Displayroom();
    }

    else if (selectedfunction == 3)
    {

    }

    else if (selectedfunction == 4)
    {

    }

    else if (selectedfunction == 5)
    {

    }

    else if (selectedfunction == 6)
    {

    }

    else if (selectedfunction == 0)
    {
        Console.WriteLine("Ending progran... ...");
    }
}





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

// Name: Natalie Chan
// Student Number: S10220879H
void registerguest()
{

}

// Name: Isaac Khoo
// Student Number: S10244252C

void checkinguest()
{

}

// Name: Natalie Chan
// Student Number: S10220879H

void gueststaydetails()
{

}

// Name: Isaac Khoo
// Student Number: S10244252C

void extendstay()
{

}










startupmenu();
