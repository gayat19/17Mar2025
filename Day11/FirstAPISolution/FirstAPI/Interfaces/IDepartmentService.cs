using FirstAPI.Models;
using FirstAPI.Models.DTOs;

namespace FirstAPI.Interfaces
{
    public interface IDepartmentService
    {
        Task<DropDownDto> GetAll();

    }
}
