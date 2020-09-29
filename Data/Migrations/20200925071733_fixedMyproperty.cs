using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsDB.Data.Migrations
{
    public partial class fixedMyproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "StudentInfos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "StudentInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
