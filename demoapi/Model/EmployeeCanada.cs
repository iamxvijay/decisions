// Models/EmployeeCanada.cs
namespace DemoApi.Models
{
    public class EmployeeCanada : Employee
    {
        public string Province { get; set; }
        public string Language { get; set; }
        public int Experience { get; set; }
        public string Industry { get; set; }
        public string Certification { get; set; }
    }
}
