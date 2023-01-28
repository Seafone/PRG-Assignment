using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Name: Isaac Khoo
// Student Number: S10244252C

namespace PRG_ASG
{
    internal abstract class Room
    {
        public int roomNumber { get; set; }

        public string bedConfiguration { get; set; }

        public double dailyRate { get; set; }

        public bool isAvail { get; set; }


        public Room() { }

        public Room(int r, string b, double d, bool i)
        {
            roomNumber = r;
            bedConfiguration = b;
            dailyRate = d;
            isAvail = i;
        }

        public abstract double CalculateCharges();

        public override string ToString()
        {
            return base.ToString() + $", Room Number: {roomNumber}, Bed Configuration: {bedConfiguration}, Daily Rate: {dailyRate}, Is Available: {isAvail} ";
        }
    }

}
