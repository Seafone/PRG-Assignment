using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Name: Natalie Chan
// Student Number: S10220879H

namespace PRG_ASG
{
    class Membership
    {
        public string Status { get; set; }

        public int Points { get; set; }

        public Membership() { }

        public Membership(string status, int points)
        {
            Status = status;
            Points = points;
        }
        public void EarnPoints(double EP)
        {
            Points = Convert.ToInt32(EP) / 10;
        }

        public bool ReedemPoints(int RP)
        {
            if (RP <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            return "Status: " + Status + "\tPoints: " + Points;

        }
    }
}
