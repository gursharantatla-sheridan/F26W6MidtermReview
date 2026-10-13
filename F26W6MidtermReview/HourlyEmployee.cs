using System;
using System.Collections.Generic;
using System.Text;

namespace F26W6MidtermReview
{
    public class HourlyEmployee : Employee
    {
        public int Hours { get; set; }
        public double Wage { get; set; }

        public HourlyEmployee(int id, string? name, EmployeeType empType, bool isUnionMember, int hours, double wage) : base (id, name, empType, isUnionMember)
        {
            Hours = hours;
            Wage = wage;
        }

        public override double Earnings()
        {
            if (Hours <= 40)
                return Hours * Wage;
            else
                return (40 * Wage) + (Hours - 40) * Wage * 1.5;
        }
    }
}
