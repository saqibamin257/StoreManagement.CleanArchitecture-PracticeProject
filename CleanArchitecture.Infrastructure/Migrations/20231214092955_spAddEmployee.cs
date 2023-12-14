using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class spAddEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spAddEmployee
                                @EmployeeSerialNumber nvarchar(max),
                                @FirstName nvarchar(50),
                                @LastName nvarchar(max),
                                @ContactNumber nvarchar(max),
                                @Email nvarchar(max),
                                @DateOfBirth datetime
                                As
                                Begin
	                                Insert into Employees 
				                                (EmployeeSerialNumber,FirstName,LastName,ContactNumber,Email,DateOfBirth)
				                                Values
				                                (@EmployeeSerialNumber,@FirstName,@LastName,@ContactNumber,@Email,@DateOfBirth)
                                End";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {     
                string procedure = @"Drop Procedure spAddEmployee";
                migrationBuilder.Sql(procedure);
        }
    }
}
