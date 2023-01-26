using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_ASG
{
    class Stay
    {
        public DateTime CheckinDate { get; set; }

        public DateTime CheckoutDate { get; set; }

        public Stay() { }

        public Stay (DateTime checkinDate, DateTime checkoutDate)
        {
            CheckinDate = checkinDate;
            CheckoutDate = checkoutDate;
        }

        public double CalculateTotal () 
        {

            
        }

        public override string ToString()
        {
            return "Check-in Date: " + CheckinDate + "\tCheck-out Date: " + CheckoutDate;
        }
    }
}
