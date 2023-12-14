using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mapper
{
    internal class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeRequest, Employee>(); //Map Employee Request to Employee model object
            CreateMap<Employee, EmployeeDTO>();    //Map Employee Model Object to Employee DTO (response object)
        }
    }
}
