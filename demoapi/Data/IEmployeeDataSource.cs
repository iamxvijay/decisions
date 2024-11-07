// Data/IEmployeeDataSource.cs
using System.Collections.Generic;
using DemoApi.Models;

namespace DemoApi.Data
{
    public interface IEmployeeDataSource
    {
        List<Employee> GetEmployees();
    }
}
