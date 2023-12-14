using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepositories;
using CleanArchitecture.Infrastructure.DBContexts;
using Microsoft.Data.SqlClient;
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

        public Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
        #region Methods using stored procedures
        //GetEmployeeById using Store Procedure
        public Employee GetEmployeeByIdUsingSP(int id)
        {
            //NOTE: FromSqlRaw is not safe against SQL Injection
            //      FromSql is safe against SQL Injection
            //      FromSqlInterpolated is safe against SQL Injection

            //01-Passing parameter simple way and FromSqlRaw

            //return storeContext.Employees
            //       .FromSqlRaw<Employee>("spGetEmployeeById {0}", id)
            //       .ToList()
            //       .FirstOrDefault();


            //02-Passing Parameter using sql parameter and FromSqlRaw
            //SqlParameter parameter = new SqlParameter("@Id", id);
            //return storeContext.Employees
            //       .FromSqlRaw<Employee>("spGetEmployeeById @Id", parameter)
            //       .ToList()
            //       .FirstOrDefault();


            //NOTE: FromSql is  safe against SQL Injection, FromSql and FromSqlInterpolated are both same
            //03-Passing Parameter using FromSql            

            return storeContext.Employees
                   .FromSql<Employee>($"spGetEmployeeById {id}")
                   .ToList()
                   .FirstOrDefault();

        }       

        public Employee CreateEmployeeUsingSP(Employee employee) 
        {
            try
            {


                //01- ExecuteSqlRaw
                //SqlParameter parameter = new SqlParameter("@EmployeeSerialNumber", employee.EmployeeSerialNumber);

                //storeContext.Database.ExecuteSqlRaw("spAddEmployee {0}, {1}, {2}, {3}, {4}, {5}",
                //                                               employee.EmployeeSerialNumber,
                //                                               employee.FirstName,
                //                                               employee.LastName,
                //                                               employee.ContactNumber,
                //                                               employee.Email,
                //                                               employee.DateOfBirth);
                //return employee;

                //02-ExecuteSql
                storeContext.Database.ExecuteSql($@"spAddEmployee 
                                                    @EmployeeSerialNumber={employee.EmployeeSerialNumber},
                                                    @FirstName={employee.FirstName},
                                                    @LastName={employee.LastName},
                                                    @ContactNumber={employee.ContactNumber},
                                                    @Email={employee.Email},
                                                    @DateOfBirth={employee.DateOfBirth}");
                return employee;
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException();
            }                            
        }

        public async Task<Employee> CreateEmployeeUsingSPAsync(Employee employee)
        {
            try
            {
               await storeContext.Database.ExecuteSqlAsync($@"spAddEmployee 
                                                    @EmployeeSerialNumber={employee.EmployeeSerialNumber},
                                                    @FirstName={employee.FirstName},
                                                    @LastName={employee.LastName},
                                                    @ContactNumber={employee.ContactNumber},
                                                    @Email={employee.Email},
                                                    @DateOfBirth={employee.DateOfBirth}");
                return employee;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }




        #endregion
    }
}
