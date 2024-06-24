using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    IsMale = table.Column<bool>(type: "boolean", nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deposit = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    IsNewCustomer = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Birthdate",
                table: "Customers",
                column: "Birthdate");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_City",
                table: "Customers",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Deposit",
                table: "Customers",
                column: "Deposit");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Gender",
                table: "Customers",
                column: "IsMale");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IsNewCustomer",
                table: "Customers",
                column: "IsNewCustomer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
