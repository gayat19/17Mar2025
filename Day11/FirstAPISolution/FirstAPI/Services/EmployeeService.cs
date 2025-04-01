using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;
using FirstAPI.Repositories;

namespace FirstAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _employeeRepository;
        private readonly IRepository<int, Department> _departmentRepository;

        public EmployeeService(IRepository<int,Employee> employeeRepository,
                                IRepository<int,Department>  departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }
        public async Task<IEnumerable<GetEmployeeResponse>> GetEmployeesByDepartment(int departmentId)
        {
            List<GetEmployeeResponse> employees = new List<GetEmployeeResponse>();
            var department = await _departmentRepository.GetById(departmentId);
            if(department == null)
                throw new Exception("Department not found");
            if(department.Employees.Count() == 0)
                throw new Exception("No employees found in this department");
            foreach (var employee in department.Employees)
            {
                employees.Add(new GetEmployeeResponse
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Phone = employee.Phone,
                    Department = department.Name
                });
            }
            return employees;
        }
    }
}
