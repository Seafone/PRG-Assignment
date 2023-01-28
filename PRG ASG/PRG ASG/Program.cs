using PRG_ASG;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
// Name: Isaac Khoo
// Student Number: S10244252


List<Room> RoomList = new List<Room>();
List<Stay> StayList = new List<Stay>();
List<Guest> GuestList = new List<Guest>();

void initialiseRoom()
{
    string[] roominfo = File.ReadAllLines("Rooms.csv");
    for (int i = 1; i < roominfo.Length; i++)
    {
        string[] roomcontent = roominfo[i].Split(',');
        if (roomcontent[0] == "Standard")
        {
            StandardRoom NStandard = new StandardRoom(Convert.ToInt32(roomcontent[1]), roomcontent[2], Convert.ToDouble(roomcontent[3]), true);
            RoomList.Add(NStandard);
        }

        else if (roomcontent[0] == "Deluxe")
        {
            DeluxeRoom NDeluxe = new DeluxeRoom(Convert.ToInt32(roomcontent[1]), roomcontent[2], Convert.ToDouble(roomcontent[3]), true);
            RoomList.Add(NDeluxe);
        }

        else
        {
            continue;
        }
    }
}

void initialiseStay()
{
    string[] staysinfo = File.ReadAllLines("Stays.csv");
    for(int i = 1; i < staysinfo.Length; i++)
    {
        string[] staycontent = staysinfo[i].Split(',');
        Stay stay = new Stay(Convert.ToDateTime(staycontent[3]),Convert.ToDateTime(staycontent[4]));
        StayList.Add(stay);
    }
}

void initialiseGuest()
{
    string[] guestinfo = File.ReadAllLines("Guests.csv");
    for (int i = 1; i < guestinfo.Length; i++)
    {
        string[] guestcontent = guestinfo[i].Split(',');
        Stay stay = new Stay(default, default);
        Membership membership = new Membership(guestcontent[2], Convert.ToInt32(guestcontent[3]));
        Guest guest = new Guest(guestcontent[0], guestcontent[1],stay,membership);
        GuestList.Add(guest);
    }

}



void startupmenu()
{
    Console.WriteLine("=======================================================================================================");
    Console.WriteLine("Select Function");
    Console.WriteLine("1: All Guests \n2: Available Rooms \n3: Register Guest \n4: Check-in guest \n5: Stay Details Of Guest \n6: Extend Stay \n0: Quit Menu");
    Console.WriteLine("=======================================================================================================");
    Console.WriteLine("Input Option: ");
    string selectfunction = Console.ReadLine();
    int selectedfunction = Convert.ToInt32(selectfunction);
    
    if (selectedfunction == 1)
    {
        DisplayGuest();
        startupmenu();
    }

    else if (selectedfunction == 2)
    {
        DisplayAvailroom();
        startupmenu();
    }

    else if (selectedfunction == 3)
    {
        registerguest();
        startupmenu();
    }

    else if (selectedfunction == 4)
    {
        checkinguest();
        startupmenu();
    }

    else if (selectedfunction == 5)
    {
        gueststaydetails();
        startupmenu();
    }

    else if (selectedfunction == 6)
    {
        extendstay();
        startupmenu();
    }

    else if (selectedfunction == 0)
    {
        Console.WriteLine("Ending program... ...");
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

void DisplayAvailroom()
{
    initialiseStay();
    initialiseRoom();
    Console.WriteLine("List Information Of All Available Rooms: ");
    int count = 1;
    foreach (Room r in RoomList)
    {
        if (r.isAvail)
        {
            Console.WriteLine("{0} {1}", count, r);
            count++;
        }
    }
}

Room FindRoom(int roomNo)
{
    foreach (Room r in RoomList)
    {
        if (r.roomNumber == roomNo)
        {
            return r;
        }
        
    }

    return null;
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
