using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Server.Migrations
{
    public partial class addCustomerinformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CusInfoId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerinformationCusInfoId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customerinformations",
                columns: table => new
                {
                    CusInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customerinformations", x => x.CusInfoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerinformationCusInfoId",
                table: "Customers",
                column: "CustomerinformationCusInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Customerinformations_CustomerinformationCusInfoId",
                table: "Customers",
                column: "CustomerinformationCusInfoId",
                principalTable: "Customerinformations",
                principalColumn: "CusInfoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Customerinformations_CustomerinformationCusInfoId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Customerinformations");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerinformationCusInfoId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CusInfoId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerinformationCusInfoId",
                table: "Customers");
        }
    }
}
