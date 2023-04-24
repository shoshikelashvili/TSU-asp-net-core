using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProject.Migrations
{
    public partial class modifyHistoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "ProductHistories");

            migrationBuilder.AddColumn<string>(
                name: "EntityName",
                table: "ProductHistories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityName",
                table: "ProductHistories");

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "ProductHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
