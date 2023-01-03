using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAppEF.Data.Entities.Migrations
{
    /// <inheritdoc />
    public partial class CreateExecutive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Executives",
                columns: table => new
                {
                    ExecutiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExecutiveFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutiveLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutiveEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutiveContact = table.Column<int>(type: "int", nullable: false),
                    ExecutiveBranch = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Executives", x => x.ExecutiveId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Executives");
        }
    }
}
