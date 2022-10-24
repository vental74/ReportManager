using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportManager.Infrastructure.Migrations
{
    public partial class AddIdUserToReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Reports");
        }
    }
}
