using AutoMapper;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;

namespace FirstAPI.Misc
{
    public class DepartmentMapper : Profile
    {
        public DepartmentMapper()
        {
            CreateMap<Department, DepartmentDto>();
               
            CreateMap<DepartmentDto, Department>();
           
        }
    }
}
