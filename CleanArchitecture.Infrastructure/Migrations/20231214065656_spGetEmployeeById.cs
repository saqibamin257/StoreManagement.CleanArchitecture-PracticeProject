using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class spGetEmployeeById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Create Store Procedure spGetEmployeeById
            string procedure = @"Create Procedure spGetEmployeeById
                                 @Id int
                                  as
                                  Begin
                                     select * from Employees
                                     where EmployeeId=@Id
                                  End";
            migrationBuilder.Sql(procedure);


            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(1985, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //drop Store Procedure spGetEmployeeById
            string procedure = @"Drop Procedure spGetEmployeeById";
            migrationBuilder.Sql(procedure);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Employees",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateOnly(1985, 10, 24));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateOnly(1990, 10, 10));
        }
    }
}
