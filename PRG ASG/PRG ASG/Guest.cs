using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Name: Natalie Chan
// Student Number: S10220879H

namespace PRG_ASG
{
    class Guest
    {
        public string Name { get; set; }

        public string PassportNum { get; set; }

        public Stay HotelStay { get; set; }

        public Membership Member { get; set; }

        public bool IsCheckedin { get; set; }

        public Guest() { }

        public Guest(string name, string passportNum, Stay hotelStay, Membership member)
        {
            Name = name;
            PassportNum = passportNum;
            HotelStay = hotelStay;
            Member = member;
        }

        public override string ToString()
        {
            return "Name: " + Name + "\tPassport Number: " + PassportNum + HotelStay.ToString() + Member.ToString() + "\tIs Checked-in: " + IsCheckedin;
        }
    }
}
