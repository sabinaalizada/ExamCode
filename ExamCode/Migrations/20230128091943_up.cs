using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamCode.Migrations
{
    public partial class up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Settings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Settings",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
