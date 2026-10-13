using System;
using System.Collections.Generic;
using System.Text;

namespace F26W6MidtermReview
{
    public enum EmployeeType
    {
        FullTime, PartTime, Contractor
    }


    public abstract class Employee (int id, string? name, EmployeeType empType, bool isUnionMember)
    {
        public int Id { get; set; } = id;
        public string? Name { get; set; } = name;
        public EmployeeType EmpType { get; set; } = empType;
        public bool IsUnionMember { get; set; } = isUnionMember;

        public abstract double Earnings();
    }
}
