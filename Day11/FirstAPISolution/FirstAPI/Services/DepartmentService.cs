using AutoMapper;
using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;
using FirstAPI.Repositories;

namespace FirstAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<int, Department> _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IRepository<int,Department> departmentRepository,IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<DropDownDto> GetAll()
        {
            var departments = await _departmentRepository.GetAll();
            if (departments == null)
                throw new Exception("Failed to get departments");
            var departmentDtos = _mapper.Map<IEnumerable<DepartmentDto>>(departments);
            var dropdownDto = new DropDownDto();
            dropdownDto.Departments = departmentDtos.ToList();
            return dropdownDto;
        }
    }
}
