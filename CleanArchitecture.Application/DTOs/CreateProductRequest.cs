﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs
{
    public class CreateProductRequest
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; } = String.Empty;

        [Required]
        public string Description { get; set; } = String.Empty;

        [Required]
        [Range(0.01, 1000)]
        public double Price { get; set; }
    }
    public class UpdateProductRequest : CreateProductRequest
    {
        [Required]
        [Range(0, 100)]
        public int Stock { get; set; }
    }
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int Stock { get; set; }
        public double Price { get; set; }
    }
}
