using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErros.Datas.Migrations
{
    public partial class attnometabela2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Error_Environment_EnvironmentId",
                table: "Error");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Error",
                table: "Error");

            migrationBuilder.RenameTable(
                name: "Error",
                newName: "Log");

            migrationBuilder.RenameIndex(
                name: "IX_Error_EnvironmentId",
                table: "Log",
                newName: "IX_Log_EnvironmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Log",
                table: "Log",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Environment_EnvironmentId",
                table: "Log",
                column: "EnvironmentId",
                principalTable: "Environment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Environment_EnvironmentId",
                table: "Log");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Log",
                table: "Log");

            migrationBuilder.RenameTable(
                name: "Log",
                newName: "Error");

            migrationBuilder.RenameIndex(
                name: "IX_Log_EnvironmentId",
                table: "Error",
                newName: "IX_Error_EnvironmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Error",
                table: "Error",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Error_Environment_EnvironmentId",
                table: "Error",
                column: "EnvironmentId",
                principalTable: "Environment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
