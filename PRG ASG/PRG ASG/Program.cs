using PRG_ASG;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

// Name: Isaac Khoo
// Student Number: S10244252


// Name: Isaac Khoo
// Student Number: S10244252C

List<Room> RoomList = new List<Room>();
List<Stay> StayList = new List<Stay>();
List<Guest> GuestList = new List<Guest>();

// Name: Isaac Khoo
// Student Number: S10244252C

initialiseRoom();
initialiseGuest();
initialiseStay();
startupmenu();

// Name: Isaac Khoo
// Student Number: S10244252C

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

// Name: Isaac Khoo
// Student Number: S10244252C

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
                    check2();
                    check3();
                }
                else if (room.roomNumber == Convert.ToInt32(staycontent[5]))
                {
                    StandardRoom standard = (StandardRoom)room;
                    standard.requireWifi = Convert.ToBoolean(staycontent[8]);
                    standard.isAvail = false;
                    stay.RoomList.Add(standard);
                    check2();
                    check3();
                }

                else
                {
                    continue;
                }
            }
        }
        void check2()
        {
            for (int j = 0; j < GuestList.Count; j++)
            {
                if (GuestList[j].PassportNum == staycontent[1])
                {
                    GuestList[j].HotelStay = stay;
                    GuestList[j].IsCheckedin = Convert.ToBoolean(staycontent[2]);
                }
                else
                {
                    continue;
                }
            }
        }

        void check3()
        {
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

// Name: Isaac Khoo
// Student Number: S10244252C

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

// Name: Isaac Khoo
// Student Number: S10244252C

void startupmenu()
{
    try
    {
        Console.WriteLine("=======================================================================================================");
        Console.WriteLine("Select Function");
        Console.WriteLine("1: All Guests \n2: Available Rooms \n3: Register Guest \n4: Check-in guest \n5: Stay Details Of Guest \n6: Extend Stay \n7: Display Monthy Cost \n8: Check Out Guests \n0: Quit Menu");
        Console.WriteLine("=======================================================================================================");
        Console.WriteLine("\nInput Option: ");
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
            Register();
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

        else if (selectedfunction == 7)
        {
            displaymonthlycharge();
            Console.WriteLine("");
            startupmenu();
        }

        else if (selectedfunction == 8)
        {
            CheckOutGuests();
            Console.WriteLine("");
            startupmenu();
        }

        else if (selectedfunction == 0)
        {
            Console.WriteLine("Ending program... ...");
        }

        else
        {
            Console.WriteLine("Invalid Input! ");
            startupmenu();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Invalid Input! ");
        startupmenu();
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

    void displayguestv2()
    {
        for (int i = 0; i < GuestList.Count; i++)
        {
            int x = i + 1;
            Console.WriteLine("[" + x + "]" + "\t" + GuestList[i].ToString());
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
void Register()
{
    Console.Write("Please enter the guest's name: ");
    string? name = Console.ReadLine();
    Console.Write("Please enter the guest's passport number: ");
    string? passportNum = Console.ReadLine();



    if (passportNum == "")
    {
        Console.WriteLine("Please enter a PassPort Number. ");
        Register();
    }
    else
    {
        for (int i = 0; i < GuestList.Count; i++)
        {
            if (GuestList[i].PassportNum == passportNum)
            {
                Console.WriteLine("PassPort Number Already Existed!");
                Register();

            }
            else
            {
                continue;
            }

        }
        Membership m1 = new("Ordinary", 0);
        Guest g1 = new Guest(name, passportNum, null, m1);
        GuestList.Add(g1);
        using (StreamWriter sw = new StreamWriter("Guests.csv", true))
        {
            sw.WriteLine(name + ',' + passportNum + ',' + "Ordinary" + ',' + 0);

        }
        Console.WriteLine("Registered successfully! ");
    }






}

// Name: Isaac Khoo
// Student Number: S10244252C

void checkinguest()
    {
        while (true)
        {
            displayguestv2();
            try
            {
                Console.WriteLine("\nPlease Select A Guest To Retrieve: ");
                int guestinput = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nPlease Enter Your Day of Check In (DD/MM/YYYY): ");
                DateTime checkin = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("\nPlease Enter Your Day of Check Out (DD/MM/YYYY): ");
                DateTime checkout = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("");
                while (true)
                {
                    if (guestinput < GuestList.Count + 1)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (guestinput < GuestList.Count && guestinput > 0)
                {
                    Guest changestay = GuestList[guestinput - 1];
                    Stay stay1 = new(checkin, checkout);
                    changestay.HotelStay = stay1;
                    List<Room> temp = new List<Room>();
                    foreach (Room r in RoomList)
                    {
                        if (r.isAvail)
                        {
                            temp.Add(r);
                        }
                    }
                    int x = 1;
                    foreach (Room r in temp)
                    {
                        Console.WriteLine("[{0}] - {1}", x, r);
                        x++;
                    }
                    int choice = 0;

                    while (true)
                    {
                        Console.WriteLine("\nPlease Select A Room Number: ");
                        int inputchoice = Convert.ToInt32(Console.ReadLine());
                        if (inputchoice < temp.Count + 1)
                        {
                            choice = inputchoice;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Input! ");
                            continue;
                        }
                    }

                    Room room = temp[choice - 1];
                    foreach (Room r in RoomList)
                    {
                        if (r == room)
                        {
                            if (room is StandardRoom sr)
                            {
                                while (true)
                                {
                                    Console.WriteLine("\nDo You Require Wifi? (Y/N): ");
                                    string? wifichoice = Console.ReadLine();
                                    if (wifichoice.ToUpper() == "Y")
                                    {
                                        sr.requireWifi = true;
                                        break;
                                    }
                                    else if (wifichoice.ToUpper() == "N")
                                    {
                                        sr.requireWifi = false;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nEnter Valid Option!");
                                    }
                                }

                                while (true)
                                {
                                    Console.WriteLine("\nDo You Require Breakfast? (Y/N): ");
                                    string? bfastchoice = Console.ReadLine();
                                    if (bfastchoice.ToUpper() == "Y")
                                    {
                                        sr.requireBreakfast = true;
                                        break;
                                    }
                                    else if (bfastchoice.ToUpper() == "N")
                                    {
                                        sr.requireBreakfast = false;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nEnter Valid Option!");
                                    }
                                }
                            }
                            r.isAvail = false;
                            changestay.HotelStay.AddRoom(r);
                        }
                    }
                    int var = 0;
                    while (true)
                    {
                        Console.WriteLine("\nWould You Like To Select Another Room? (Y/N): ");
                        string? anotherchoice = Console.ReadLine();
                        if (anotherchoice.ToUpper() == "N")
                        {
                            changestay.IsCheckedin = true;
                            Console.WriteLine("\nCheck In Succesful!");
                            var += 1;
                            break;
                        }
                        else if (anotherchoice.ToUpper() == "Y")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nEnter Valid Option!");
                        }
                    }
                    if (var == 1)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nInvalid Input! \n");
                checkinguest();
            }
        }
    }

// Name: Natalie Chan
// Student Number: S10220879H

    void gueststaydetails()
    {
        //listing details of guests
        for (int i = 0; i < GuestList.Count; i++)
        {
            Console.WriteLine("[{0}]\t{1}", i + 1, GuestList[i].Name);
        }

        //prompt user to select guest
        Console.Write("Please select a guest: ");
        int index = Convert.ToInt32(Console.ReadLine());
        if (index < GuestList.Count && index > 0)
        {
            Guest guest = GuestList[index - 1];
            Console.WriteLine(guest.HotelStay.ToString());
        }
    }

    // Name: Isaac Khoo
    // Student Number: S10244252C

    void extendstay()
    {
        try
        {
            displayguestv2();
            Console.WriteLine("\nPlease Select A Guest To Retrieve: ");
            int guestinput = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (guestinput < GuestList.Count + 1)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            for (int i = 0; i < GuestList.Count; i++)
            {
                if (guestinput == i + 1 && GuestList[i].IsCheckedin == true)
                {
                    Console.WriteLine("\n" + GuestList[i].ToString());
                    Console.WriteLine("\nHow Many Days Do You Want To Extend? : ");
                    int extend = Convert.ToInt32(Console.ReadLine());
                    GuestList[i].HotelStay.CheckoutDate = GuestList[i].HotelStay.CheckoutDate.AddDays(extend);
                    displayguestv2();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nInvalid Input! \n");
            extendstay();
        }

     }


// Name: Isaac Khoo
// Student Number: S10244252C

void displaymonthlycharge()
{
    {
        List<double> monthsinyear = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int year;
        while (true)
        {
            try
            {
                Console.WriteLine("Enter year: ");
                year = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch (FormatException) { Console.WriteLine("Please enter valid year."); }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        for (int i = 0; i < StayList.Count; i++)
        {
            if (StayList[i].CheckoutDate.Year == year)
            {
                foreach (Room rm in StayList[i].RoomList)
                {
                    monthsinyear[StayList[i].CheckoutDate.Month - 1] += rm.CalculateCharges();
                }

            }

        }
    }
}
// Name: Natalie Chan
// Student Number: S10220879H

void CheckOutGuests()
{
    for (int i = 0; i < GuestList.Count; i++)
    {
        Console.WriteLine("[{0}] {1}", i + 1, GuestList[i]);
    }
    Console.WriteLine("select a guest: ");
    int choice = Convert.ToInt32(Console.ReadLine());
    if (choice > GuestList.Count || choice <= 0)
    {
        Console.WriteLine("Invalid Choice");
    }
    else
    {
        Guest guest1 = GuestList[choice - 1];
        double amt = guest1.HotelStay.CalculateTotal();
        Console.WriteLine("Total charges: " + amt);
        Console.WriteLine("{0} {1}", guest1.Member.Status, guest1.Member.Points);

        int pts = guest1.Member.Points;
        guest1.Member.EarnPoints(pts);
        Console.WriteLine("How many points do you want to redeem? ");
        int pts2 = Convert.ToInt32(Console.ReadLine());
        double newamt = amt - pts2;
        Console.WriteLine("Press any key to make payment: ");
        string? statement = Console.ReadLine();
        if (statement != "Pay")
        {
            Console.WriteLine("Payment was not made properly");
        }
        else
        {
            guest1.Member.EarnPoints(newamt);
            guest1.IsCheckedin = false;
        }
    }
}
