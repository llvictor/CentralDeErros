using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErros.Datas.Migrations
{
    public partial class attnometabela3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Log");

            migrationBuilder.AddColumn<int>(
                name: "Events",
                table: "Log",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Events",
                table: "Log");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Log",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
