using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCEFCORE.Migrations
{
    public partial class CustomerRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Customers",
                nullable: true);
        }
    }
}
