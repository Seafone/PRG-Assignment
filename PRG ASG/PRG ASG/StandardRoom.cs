using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Name: Isaac Khoo
// Student Number: S10244252C

namespace PRG_ASG
{
    internal class StandardRoom : Room
    {
        public bool requireWifi { get; set; }

        public bool requireBreakfast { get; set; }

        public StandardRoom() { }

        public StandardRoom(int r, string b, double dr, bool ia) : base(r, b, dr, ia) { }

        public override double CalculateCharges()
        {
            double total = 0;
            if (requireWifi == true)
            {
                total = +10;
            }
            if (requireBreakfast == true)
            {
                total = +20;
            }

            total = dailyRate + total;
            if (bedConfiguration == "single")
            {
                total = +90;
            }
            else if (bedConfiguration == "twin")
            {
                total = +110;
            }
            else if (bedConfiguration == "triple")
            {
                total = +120;
            }
            return total;
        }

        public override string ToString()
        {
            return base.ToString() + $"Require Wifi: {requireWifi}, Require Breakfast: {requireBreakfast}";
        }
    }
}

