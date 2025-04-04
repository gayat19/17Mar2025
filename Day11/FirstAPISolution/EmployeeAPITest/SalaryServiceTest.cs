using AutoMapper;
using FirstAPI.Contexts;
using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;
using FirstAPI.Repositories;
using FirstAPI.Services;
using log4net.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace EmployeeAPITest
{
    public class SalaryServiceTest
    {
        private  IMapper _mapper;
        private  SalaryService _salaryService;
        private  IRepository<int, Employee> _employeeRepository;
        private  IRepository<int, Salary> _salaryRepository;
        private  IRepository<int, EmployeeSalary> _employeeSalaryRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EmployeeManagementContext>()
                .UseInMemoryDatabase(databaseName: "EmployeeManagementTest")
                .Options;
            EmployeeManagementContext context = new EmployeeManagementContext(options);
            _employeeRepository = new EmployeeRepository(context);
            _salaryRepository = new SalaryRepository(context);
            _employeeSalaryRepository = new EmployeeSalaryRepository(context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Salary, SalaryResponse>();
                cfg.CreateMap<SalaryResponse, Salary>();
            });

        }

        [Test]
        public async Task GetSalaryPass()
        {
            // Arrange

            Mock<ILogger<SalaryService>> loggerMock = new Mock<ILogger<SalaryService>>();
            var salary = new Salary
            {
                Id = 1,
                Basic = 5000,
                Allowance = 1000,
                HRA = 2000,
                DA = 1500,
                PF = 500,
                Status = "Active"
            };
            Mock<IMapper> mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<IEnumerable<SalaryResponse>>(It.IsAny<IEnumerable<Salary>>()))
                .Returns(new List<SalaryResponse>
                {
                    new SalaryResponse
                    {
                        Id = salary.Id,
                        Basic = salary.Basic,
                        Allowance = salary.Allowance,
                        HRA = salary.HRA,
                        DA = salary.DA,
                        PF = salary.PF,
                    }
                });
            await _salaryRepository.Add(salary);
            _salaryService = new SalaryService(_employeeRepository, _salaryRepository, _employeeSalaryRepository, mapper.Object, loggerMock.Object);
           
            var result = await _salaryService.GetAllSalaries();
            Assert.That(result.Count(), Is.EqualTo(1));
        }
    }
}