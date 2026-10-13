using System;
using System.Collections.Generic;
using System.Text;

namespace F26W6MidtermReview
{
    public class CommissionEmployee (int id, string? name, EmployeeType empType, bool isUnionMember, double grossSales, double commissionRate) : Employee (id, name, empType, isUnionMember)
    {
        public double GrossSales { get; set; } = grossSales;
        public double CommissionRate { get; set; } = commissionRate;

        public override double Earnings()
        {
            return GrossSales * CommissionRate;
        }
    }
}
