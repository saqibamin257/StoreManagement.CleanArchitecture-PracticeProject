using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.DBContexts
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Employee Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                EmployeeSerialNumber = "EMP-001",
                FirstName = "Saqib",
                LastName = "Amin",
                ContactNumber="+92336-12345",
                Email="saqib@gmail.com",
                DateOfBirth=new DateTime(1985,10,24)
            }); 
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                EmployeeSerialNumber = "EMP-002",
                FirstName = "Imran",
                LastName = "Nazir",
                ContactNumber = "+92336-558855",
                Email = "imran@gmail.com",
                DateOfBirth = new DateTime(1990, 10, 10) //year,month,day
            });            
        }
    }
}
