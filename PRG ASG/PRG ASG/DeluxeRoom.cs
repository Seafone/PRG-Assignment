using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_ASG
{
    internal abstract class DeluxeRoom: Room
    {
        public bool additionalBed { get; set; }

        public DeluxeRoom() { }
        
        public DeluxeRoom(int rn, string bc, double dr, bool ia): base(rn, bc, dr, ia) { }

        public override string ToString()
        {
            return base.ToString() + $"Additional Bed: {additionalBed}";
        }
    }
}
