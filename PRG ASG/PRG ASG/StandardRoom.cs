using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_ASG
{
    internal abstract class StandardRoom : Room
    {
        public bool requireWifi { get; set; }

        public bool requireBreakfast { get; set; }

        public StandardRoom() { }

        public StandardRoom(int r, string b, double dr, bool ia): base(r, b, dr, ia) { }

        public override double CalculateCharges()
        {

        }

        public override string ToString()
        {
            return base.ToString() + $"Require Wifi: {requireWifi}, Require Breakfast: {requireBreakfast}";
        }
    }
}
