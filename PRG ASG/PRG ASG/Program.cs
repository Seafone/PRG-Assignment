using PRG_ASG;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
// Name: Isaac Khoo
// Student Number: S10244252


List<Room> RoomList = new List<Room>();
List<Stay> StayList = new List<Stay>();
List<Guest> GuestList = new List<Guest>();

initialiseRoom();
initialiseStay();
initialiseGuest();


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
    for (int i = 1; i < staysinfo.Length; i++)
    {
        string[] staycontent = staysinfo[i].Split(',');
        Stay stay = new Stay(Convert.ToDateTime(staycontent[3]), Convert.ToDateTime(staycontent[4]));
        StayList.Add(stay);
        foreach (Room room in RoomList)
        {
            if (room.roomNumber == Convert.ToInt32(staycontent[5]))
            {
                if (room is DeluxeRoom)
                {
                    DeluxeRoom deluxe = (DeluxeRoom)room;
                    deluxe.additionalBed = Convert.ToBoolean(staycontent[8]);
                    deluxe.isAvail = false;
                    stay.RoomList.Add(deluxe);
                }
                else if (room.roomNumber == Convert.ToInt32(staycontent[5]))
                {
                    StandardRoom standard = (StandardRoom)room;
                    standard.requireWifi = Convert.ToBoolean(staycontent[8]);
                    standard.isAvail = false;
                    stay.RoomList.Add(standard);
                }

            else
                {
                    continue;
                }
    for(int j = 0; j < GuestList.Count; j++)
                {
                    if (GuestList[j].PassportNum == staycontent[1])
                    {
                        GuestList[i].HotelStay = stay;
                        GuestList[i].IsCheckedin = Convert.ToBoolean(staycontent[2]);
                    }
                    else
                    {
                        continue;
                    }

    foreach (Room room2 in RoomList)
                    {
                        if (staycontent[9] != "")
                        {
                            if (room2 is StandardRoom)
                            {
                                StandardRoom standard = (StandardRoom)room2;
                                standard.requireWifi = Convert.ToBoolean(staycontent[10]);
                                standard.requireBreakfast = Convert.ToBoolean(staycontent[11]);
                                stay.RoomList.Add(standard);
                            }

                            else
                            {
                                continue;
                            }
                        }

                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
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
        Guest guest = new Guest(guestcontent[0], guestcontent[1], stay, membership);
        GuestList.Add(guest);
    }

}



void startupmenu()
{
    Console.WriteLine("=======================================================================================================");
    Console.WriteLine("Select Function");
    Console.WriteLine("1: All Guests \n2: Available Rooms \n3: Register Guest \n4: Check-in guest \n5: Stay Details Of Guest \n6: Extend Stay \n0: Quit Menu");
    Console.WriteLine("=======================================================================================================");
    Console.WriteLine("");
    Console.WriteLine("Input Option: ");
    string selectfunction = Console.ReadLine();
    Console.WriteLine("");
    int selectedfunction = Convert.ToInt32(selectfunction);

    if (selectedfunction == 1)
    {
        DisplayGuest();
        Console.WriteLine("");
        startupmenu();
    }

    else if (selectedfunction == 2)
    {
        DisplayAvailroom();
        Console.WriteLine("");
        startupmenu();
    }

    else if (selectedfunction == 3)
    {
        registerguest();
        Console.WriteLine("");
        startupmenu();
    }

    else if (selectedfunction == 4)
    {
        checkinguest();
        Console.WriteLine("");
        startupmenu();
    }

    else if (selectedfunction == 5)
    {
        gueststaydetails();
        Console.WriteLine("");
        startupmenu();
    }

    else if (selectedfunction == 6)
    {
        extendstay();
        Console.WriteLine("");
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
    Console.WriteLine("List Information Of All Available Rooms: ");
    foreach (Room room in RoomList)
    {
        if (room.isAvail == true)
        {
            Console.WriteLine(room.ToString());
        }
        else
        {
            continue;
        }
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
