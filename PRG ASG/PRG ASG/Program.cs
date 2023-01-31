using PRG_ASG;
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
initialiseStay();
initialiseGuest();
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

// Name: Natalie Chan
// Student Number: S10220879H

static void menu()
{
    try
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Hotel Management System");
            Console.WriteLine("Please select an option from the menu below:");
            Console.WriteLine("1. List all guests");
            Console.WriteLine("2. List all rooms");
            Console.WriteLine("3. Register a guest");
            Console.WriteLine("4. Check in a guest");
            Console.WriteLine("5. Display stay details of a guest");
            Console.WriteLine("6. Extends stay");
            Console.WriteLine("7. Exit");

            int option = Convert.ToInt32(Console.ReadLine());
            if (option == 1)
            {
                DisplayGuest();
            }
            else if (option == 2)
            {
                DisplayRooms();
            }
            else if (option == 3)
            {
                registerguest();
            }
            else if (option == 4)
            {
                checkinguest();
            }
            else if (option == 5)
            {
                gueststaydetails();
            }
            else if (option == 6)
            {
                extendstay();
            }
            else if (option == 7)
            {
                Console.WriteLine("Thank you for using the Hotel Management System");
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid option");
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        menu();
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
    void registerguest()
    {
            try
            {
                //take input foe name and passprt number

                Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                //check if number contains only alphabets
                if (Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine("Name is valid");
                }
                else
                {
                    Console.WriteLine("Name is not valid");
                    RegisterGuest();
                }
                Console.WriteLine("Enter Passport Number: ");
                string passport = Console.ReadLine();

                //create a membership object
                Membership membership = new Membership();

                //append data into guests.csv usinf file.writeline

                using (var guestswriter = new StreamWriter("Guests.csv", true))
                using (var csvwriter = new CsvWriter(guestswriter, CultureInfo.InvariantCulture))
                {
                    csvwriter.WriteRecord(new CSVmanager.GuestsFile
                    {
                        Name = name,
                        PassportNumber = passport,
                        MembershipStatus = membership.Status,
                        MembershipPoints = membership.Points
                    });
                }





            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                RegisterGuest();
            }
        }
    
        static DateOnly datecreator(string time)
        {
            try
            {
                Console.WriteLine("Enter the {0} year", time);
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the {0} month", time);
                int month = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the {0} day", time);
                int day = int.Parse(Console.ReadLine());
                DateOnly date = new DateOnly(year, month, day);
                //checking validation
                if (date < new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
                {
                    Console.WriteLine("Date cannot be from past");
                    Console.WriteLine("Please try again");
                    return datecreator(time);
                }
                return date;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please try again");
                return datecreator(time);
            }
        }


        static string optioncreator(string opt)
        {
            Console.WriteLine("do you want {0} answer in Y/N?", opt);
            string option = Console.ReadLine();

            if (option == "Y" || option == "y")
            {
                return "TRUE";
            }
            else if (option == "N" || option == "n")
            {
                return "FALSE";
            }
            else
            {
                Console.WriteLine("Invalid option please try again");
                return optioncreator(opt);
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
            try{
            //take guest details
            GuestsFile selectedguest = getGuest();

            //take checkindate
            DateOnly checkindate = datecreator("check in");
            //take checkoutdate
            DateOnly checkoutdate = datecreator("check out");
            //check if checkoutdate is greater than checkindate
            if (checkoutdate < checkindate)
            {
                Console.WriteLine("Checkout date cannot be before checkin date");
                Console.WriteLine("Please try again");
                checkoutdate = datecreator("check out");
            }
            System.Collections.Generic.List<CSVmanager.RoomsFile> room =
           new System.Collections.Generic.List<CSVmanager.RoomsFile>();
            //open rooms.csv and display data
            using (var roomreader = new StreamReader("Rooms.csv"))
            using (var csvreader = new CsvReader(roomreader, CultureInfo.InvariantCulture))
            {
                var rooms = csvreader.GetRecords<CSVmanager.RoomsFile>().ToList();
                room = rooms;
            }
            //list all available rooms
            List<RoomsFile> availableRooms = listAllAvailableRooms(room);
            int i = 1;
            foreach (var rec in availableRooms)
            {
                Console.WriteLine(" {0} , RoomType: {1}, RoomNumber: {2}, BedConfiguration: {3}, DailyRate: {4}", i, rec.RoomType, rec.RoomNumber, rec.BedConfiguration, rec.DailyRate);
                i++;
            }
            //take user option
            Console.WriteLine("Enter the number of the room you want to check in: ");
            int option2 = Convert.ToInt32(Console.ReadLine());
            //check if option is valid
            if (option2 > 0 && option2 <= i)
            {

            }
            else
            {
                Console.WriteLine("Invalid option");
                CheckInGuest();
            }
            RoomsFile selectedroom = availableRooms[option2 - 1];

            if (selectedroom.RoomType == "Standard")
            {
                // require wifi [Y/N] & require breakfast [Y/N]
                string wifi = optioncreator("wifi");
                string breakfast = optioncreator("breakfast");
                storeCheckin(
                    selectedguest.Name,
                    selectedguest.PassportNumber,
                    "TRUE",
                    checkindate,
                    checkoutdate,
                    selectedroom.RoomNumber,
                    wifi,
                    breakfast,
                    "FALSE");
            }
            if (selectedroom.RoomType == "Deluxe")
            {
                string ExtraBed = optioncreator("extra bed");
                storeCheckin(
                    selectedguest.Name,
                    selectedguest.PassportNumber,
                    "TRUE",
                    checkindate,
                    checkoutdate,
                    selectedroom.RoomNumber,
                    "TRUE",
                    "TRUE",
                    ExtraBed);
            }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please try again");
                CheckInGuest();
            }
        }

        //display guests dtails

        public static void displayguests(){
            GuestsFile guestsData=getGuest();

            //store all guests csv data in an array
            System.Collections.Generic.List<GuestsFile> guest =
                new System.Collections.Generic.List<GuestsFile>();
            //open Stays.csv and read all records
            using (var staysreader = new StreamReader("Stays.csv"))
            using (var csvreader = new CsvReader(staysreader, CultureInfo.InvariantCulture))
            {
                var stays = csvreader.GetRecords<CSVmanager.StaysFile>().ToList();
                foreach (var rec in stays)
                {
                    if (rec.PassportNumber == guestsData.PassportNumber)
                    {
                        Console.WriteLine("Name: {0}, PassportNumber: {1}, MembershipStatus: {2}, MembershipPoints: {3}, Checkin Status: {4}", guestsData.Name, guestsData.PassportNumber, guestsData.MembershipStatus, guestsData.MembershipPoints,rec.IsCheckedIn);
                        Console.WriteLine("CheckinDate: {0}, CheckoutDate: {1}, RoomNumber: {2}, Wifi: {3}, Breakfast: {4}, ExtraBed: {5}", rec.CheckinDate, rec.CheckoutDate, rec.RoomNumber, rec.Wifi, rec.Breakfast, rec.ExtraBed);
                    }
                }
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

