using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Name: Natalie Chan
// Student Number: S10220879H

namespace PRG_ASG
{
    class Stay
    {
        public DateTime CheckinDate { get; set; }

        public DateTime CheckoutDate { get; set; }

        public List <Room> RoomList { get; set; }

        public Stay() { }

        public Stay(DateTime checkinDate, DateTime checkoutDate)
        {
            CheckinDate = checkinDate;
            CheckoutDate = checkoutDate;
            RoomList = new List<Room>();
        }

        public void AddRoom (Room room)
        {
            RoomList.Add(room);
        }

        public double CalculateTotal()
        {
            foreach (Room room in RoomList)
            {
                double total = +room.CalculateCharges() * (CheckinDate.Subtract(CheckoutDate).Days);
                return total;
            }
            return 0;
        }

        public override string ToString()
        {
            return "\tCheck-in Date: " + DateOnly.FromDateTime(CheckinDate) + "\tCheck-out Date: " + DateOnly.FromDateTime(CheckoutDate);
        }
    }
}
