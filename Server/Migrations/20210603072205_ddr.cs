using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Server.Migrations
{
    public partial class ddr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customers",
                newName: "FirstName");
        }
    }
}
