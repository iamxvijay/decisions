using DemoApi.Models;
using System.Collections.Generic;

namespace DemoApi.Data
{
    public static class EmployeeData
    {
        public static List<Employee> GetEmployees() => new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Position = "Developer", Department = "IT", Salary = 50000 },
            new Employee { Id = 2, Name = "Jane Smith", Position = "Designer", Department = "Creative", Salary = 55000 },
            new Employee { Id = 3, Name = "Bill Gates", Position = "Project Manager", Department = "Management", Salary = 75000 },
            new Employee { Id = 4, Name = "Elon Musk", Position = "Developer", Department = "Engineering", Salary = 67000 },
            new Employee { Id = 5, Name = "Jeff Bezos", Position = "Sales Executive", Department = "Sales", Salary = 47000 },
            new Employee { Id = 6, Name = "Mark Zuckerberg", Position = "Developer", Department = "IT", Salary = 52000 },
            new Employee { Id = 7, Name = "Sundar Pichai", Position = "HR Manager", Department = "HR", Salary = 60000 },
            new Employee { Id = 8, Name = "Tim Cook", Position = "Accountant", Department = "Finance", Salary = 53000 },
            new Employee { Id = 9, Name = "Larry Page", Position = "Marketing Specialist", Department = "Marketing", Salary = 59000 },
            new Employee { Id = 10, Name = "Sergey Brin", Position = "Operations Manager", Department = "Operations", Salary = 68000 },
            new Employee { Id = 11, Name = "Satya Nadella", Position = "Product Manager", Department = "Product", Salary = 72000 },
            new Employee { Id = 12, Name = "Reed Hastings", Position = "Content Strategist", Department = "Content", Salary = 65000 },
            new Employee { Id = 13, Name = "Evan Spiegel", Position = "UI/UX Designer", Department = "Creative", Salary = 56000 },
            new Employee { Id = 14, Name = "Sheryl Sandberg", Position = "Business Analyst", Department = "Business", Salary = 62000 },
            new Employee { Id = 15, Name = "Susan Wojcicki", Position = "HR Specialist", Department = "HR", Salary = 58000 },
            new Employee { Id = 16, Name = "Jack Ma", Position = "Sales Manager", Department = "Sales", Salary = 65000 },
            new Employee { Id = 17, Name = "Daniel Ek", Position = "Developer", Department = "Engineering", Salary = 54000 },
            new Employee { Id = 18, Name = "Travis Kalanick", Position = "Operations Executive", Department = "Operations", Salary = 60000 },
            new Employee { Id = 19, Name = "Brian Chesky", Position = "Product Designer", Department = "Product", Salary = 59000 },
            new Employee { Id = 20, Name = "Jeff Weiner", Position = "HR Consultant", Department = "HR", Salary = 62000 }
        };
    }
}
