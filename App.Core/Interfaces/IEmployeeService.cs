using App.Core.Models;

namespace App.Core.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Task<List<Employee>> GetAllEmployeesAsync();
        List<Employee> SearchEmployees(string keyword);
        Task<List<Employee>> SearchEmployeesAsync(string keyword);
        Employee GetEmployeeByID(int employeeID);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int employeeID);
    }
}