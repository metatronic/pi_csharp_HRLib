using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLib
{
    public class ConfirmEmployee : Employee
    {

        private string designation;

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        private double basic;

        public double Basic
        {
            get { return basic; }
            set { basic = value; }
        }


        public ConfirmEmployee(string _name, string _address, double _basic, string _designation) : base(_name, _address)
        {
            if (_basic < 5000)
            {
                throw new MinimumBasicException("Basic salary for confirm employee cannot be less than Rs. 5000");
            }
            Basic = _basic;
            Designation = _designation;
        }

        sealed public override double CalculateSalary()
        {
            double hra;
            double conv;
            double pf;
            if (Basic >= 30000)
            {
                hra = 30 * Basic / 100;
                conv = 30 * Basic / 100;
                pf = 10 * Basic / 100;
            }
            else if (Basic >= 20000)
            {
                hra = 20 * Basic / 100;
                conv = 20 * Basic / 100;
                pf = 10 * Basic / 100;
            }
            else
            {
                hra = 10 * Basic / 100;
                conv = 10 * Basic / 100;
                pf = 10 * Basic / 100;
            }
            return Basic + hra + conv - pf;
        }

        public override string ToString()
        {
            return string.Format($"Name:{base.Name}, Address:{base.Address}, Designation:{Designation}, Basic:{Basic}");
        }
    }
}
