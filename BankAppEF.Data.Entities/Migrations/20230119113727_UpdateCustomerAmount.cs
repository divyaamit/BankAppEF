using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAppEF.Data.Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CustomerBalance",
                table: "Customers",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerBalance",
                table: "Customers");
        }
    }
}
