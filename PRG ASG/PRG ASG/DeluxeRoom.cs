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

        public override string ToString()
        {
            return base.ToString() + $"Additional Bed: {additionalBed}";
        }

        public override double CalculateCharges()
        {
            return 0;
        }
    }
}
