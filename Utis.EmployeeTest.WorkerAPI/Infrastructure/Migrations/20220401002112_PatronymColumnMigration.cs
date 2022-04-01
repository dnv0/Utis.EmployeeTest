using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkerAPI.Infrastructure.Migrations
{
    public partial class PatronymColumnMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Patronym",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Patronym",
                table: "Workers");
        }
    }
}
