namespace FirstAPI.Models.DTOs
{
 
    public class EmployeeSearchLoadRequest
    {
        public Range? EmployeeAgeRange { get; set; }
        public IList<DepartmentDto>? Departments { get; set; }
    }
}
