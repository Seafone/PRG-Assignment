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
            int pointsEarned = Convert.ToInt32(Math.Round(EP, 0, MidpointRounding.AwayFromZero)); //round up to nearest number
            Points += pointsEarned; //add points earned to points

            if (Status == "Ordinary")
            {
                if (Points >= 200)
                { Status = "Gold"; }
                if (Points >= 100)
                { Status = "Silver"; }               
            }
            if (Status == "Silver")
            {
                if (Points >= 200)
                { Status = "Gold"; }                
            }

        }

        public bool ReedemPoints(int RP)
        {
            if (Status == "Ordinary")
            {
                return false;
            }

            if (RP <= 0)
            {
                return false;
            }
            else
            {
                Points -= RP;
                return true;
            }
        }

        public override string ToString()
        {
            return "Status: " + Status + "\tPoints: " + Points;

        }
    }
}
