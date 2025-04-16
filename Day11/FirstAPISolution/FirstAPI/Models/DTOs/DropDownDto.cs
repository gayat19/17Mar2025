namespace FirstAPI.Models.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }   
    public class DropDownDto
    {
        public List<DepartmentDto>? Departments { get; set; }
    }
}
