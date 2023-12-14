using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;
        public EmployeeService(IEmployeeRepository _employeeRepository, IMapper _mapper)
        {
            this.employeeRepository = _employeeRepository;
            this.mapper = _mapper;
        }
        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id) 
        {
            var employee = await employeeRepository.GetEmployeeByIdAsync(id);
            if(employee != null)
            {
                return mapper.Map<EmployeeDTO>(employee);
            }
            return null;
        }

        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeRequest employeeRequest)
        {
            var employee = mapper.Map<Employee>(employeeRequest);
            await employeeRepository.CreateEmployeeAsync(employee);
            return mapper.Map<EmployeeDTO>(employee);
        }
        public EmployeeDTO GetEmployeeByIdUsingSP(int id) 
        {
            var employee = employeeRepository.GetEmployeeByIdUsingSP(id);
            return mapper.Map<EmployeeDTO>(employee);
        }
    }
}
