﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee serial number is required")]
        public string EmployeeSerialNumber { get; set; }

        [Required(ErrorMessage = "Employee first name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Employee contact number is required")]
        public string ContactNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        
    }
    public record EmployeeRequest(
        
        [Required(ErrorMessage = "Employee serial number is required")]
        string EmployeeSerialNumber,

        [Required(ErrorMessage = "Employee first name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
        string FirstName,
        string LastName,
        string ContactNumber,
        string Email, 
        DateTime DateOfBirth        
        );
}
