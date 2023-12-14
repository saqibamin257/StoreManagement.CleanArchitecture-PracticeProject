using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService)
        {
            this.employeeService = _employeeService;
        }

        [HttpGet("GetEmployeeById")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            try
            {
                var result = await employeeService.GetEmployeeByIdAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving employee record from Database.");
            }
        }


        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> AddEmployee(EmployeeRequest employeeRequest)
        {
            try
            {
                if (employeeRequest == null)
                    return BadRequest();

                var createdEmployee = await employeeService.AddEmployeeAsync(employeeRequest);
                return CreatedAtAction(nameof(GetEmployeeById), new { Id = createdEmployee.EmployeeId }, createdEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }
        }

        #region Methods using Stored Procdures
        [HttpGet("GetEmployeeByIdUsingSP")]
        public ActionResult<EmployeeDTO> GetEmployeeByIdUsingSP(int id) 
        {
            try 
            {
                var result = employeeService.GetEmployeeByIdUsingSP(id);
                if(result == null)
                    return NotFound();
                return result;
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retrieving employee record from Database.");
            }
        }
        #endregion
    }
}
