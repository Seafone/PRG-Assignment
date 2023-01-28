using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Name: Isaac Khoo
// Student Number: S10244252C

namespace PRG_ASG
{
    internal class DeluxeRoom : Room
    {
        public bool additionalBed { get; set; }

        public DeluxeRoom() { }

        public DeluxeRoom(int rn, string bc, double dr, bool ia) : base(rn, bc, dr, ia) { }

        public override double CalculateCharges()
        {
            double totalRate = dailyRate;
            if (additionalBed is true)
            {
                totalRate = dailyRate + 25;
            }
            return totalRate;
        }

        public override string ToString()
        {
            return base.ToString() + $"\tAdditional Bed: {additionalBed}";
        }
    }
}
