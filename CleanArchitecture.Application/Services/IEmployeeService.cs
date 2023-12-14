using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeRequest employeeRequest);
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        EmployeeDTO GetEmployeeByIdUsingSP(int id);
        EmployeeDTO AddEmployeeUsingSP(EmployeeRequest employeeRequest);
        Task<EmployeeDTO> AddEmployeeUsingSPAsync(EmployeeRequest employeeRequest);
    }
}
