// Data/EmployeeDataCanada.cs
using DemoApi.Models;
using System.Collections.Generic;

namespace DemoApi.Data
{
    public static class EmployeeDataCanada
    {
        public static List<EmployeeCanada> GetEmployees() => new List<EmployeeCanada>
        {
            new EmployeeCanada { Id = 1, Name = "Alice Brown", Position = "Manager", Department = "Finance", Salary = 70000, Province = "Ontario", Language = "English", Experience = 8, Industry = "Banking", Certification = "CFA" },
            new EmployeeCanada { Id = 2, Name = "Bob Smith", Position = "Engineer Executive", Department = "IT", Salary = 80000, Province = "British Columbia", Language = "English", Experience = 5, Industry = "Tech", Certification = "P.Eng" },
            new EmployeeCanada { Id = 3, Name = "Claire Evans", Position = "Consultant Developer", Department = "HR", Salary = 65000, Province = "Quebec", Language = "French", Experience = 6, Industry = "Consulting", Certification = "CHRP" },
            new EmployeeCanada { Id = 4, Name = "David White", Position = "Analyst Teacher", Department = "Marketing", Salary = 62000, Province = "Ontario", Language = "English", Experience = 3, Industry = "Retail", Certification = "CIM" },
            new EmployeeCanada { Id = 5, Name = "Emma Wilson", Position = "Developer Researcher", Department = "IT", Salary = 75000, Province = "Alberta", Language = "English", Experience = 7, Industry = "Oil & Gas", Certification = "PMI" },
            new EmployeeCanada { Id = 6, Name = "Frank Johnson", Position = "Project Manager", Department = "Construction", Salary = 85000, Province = "Manitoba", Language = "English", Experience = 9, Industry = "Construction", Certification = "PMP" },
            new EmployeeCanada { Id = 7, Name = "Grace Lee", Position = "Teacher", Department = "Education", Salary = 60000, Province = "Nova Scotia", Language = "English", Experience = 10, Industry = "Education", Certification = "OCT" },
            new EmployeeCanada { Id = 8, Name = "Henry Kim", Position = "Engineer Executive", Department = "Sales", Salary = 58000, Province = "Saskatchewan", Language = "English", Experience = 4, Industry = "Agriculture", Certification = "CSM" },
            new EmployeeCanada { Id = 9, Name = "Irene Lopez", Position = "Consultant Researcher", Department = "Healthcare", Salary = 73000, Province = "Quebec", Language = "French", Experience = 6, Industry = "Healthcare", Certification = "R.N." },
            new EmployeeCanada { Id = 10, Name = "Jack Carter", Position = "Project Analyst Consultant", Department = "Legal", Salary = 90000, Province = "Ontario", Language = "English", Experience = 11, Industry = "Legal", Certification = "LLB" }
        };
    }
}
