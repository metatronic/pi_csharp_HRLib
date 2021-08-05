using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLib
{
    public class Trainee : Employee
    {
        private int numberOfDays;

        public int NumberOfDays
        {
            get { return numberOfDays; }
            set { numberOfDays = value; }
        }

        private double ratePerDay;

        public double RatePerDay
        {
            get { return ratePerDay; }
            set { ratePerDay = value; }
        }


        public Trainee(string _name, string _address, int _numberOfDays, double _ratePerDay) : base(_name, _address)
        {
            NumberOfDays = _numberOfDays;
            RatePerDay = _ratePerDay;
        }

        sealed public override double CalculateSalary()
        {
            return NumberOfDays * RatePerDay;
        }

        public override string ToString()
        {
            return string.Format($"Name:{base.Name}, Address:{base.Address}, Number of Days:{NumberOfDays}, Rate per Day:{RatePerDay}");
        }
    }
}
