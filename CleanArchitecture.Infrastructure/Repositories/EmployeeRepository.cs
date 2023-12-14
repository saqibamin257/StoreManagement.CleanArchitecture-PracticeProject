using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepositories;
using CleanArchitecture.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly StoreContext storeContext;
        public EmployeeRepository(StoreContext _storeContext) 
        {
            this.storeContext = _storeContext;
        }
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            var result = await storeContext.AddAsync(employee);
            await storeContext.SaveChangesAsync();
            return result.Entity;
        }

        public Task DeleteEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await storeContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        //GetEmployeeById using Store Procedure
        public Employee GetEmployeeByIdUsingSP(int id)
        {
            return storeContext.Employees
                   .FromSqlRaw<Employee>("spGetEmployeeById {0}", id)
                   .ToList()
                   .FirstOrDefault();
        }

        public Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
