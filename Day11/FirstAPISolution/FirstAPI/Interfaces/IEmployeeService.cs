using FirstAPI.Models;
using FirstAPI.Models.DTOs;

namespace FirstAPI.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<GetEmployeeResponse>> GetEmployeesByDepartment(int departmentId);
    }
}
