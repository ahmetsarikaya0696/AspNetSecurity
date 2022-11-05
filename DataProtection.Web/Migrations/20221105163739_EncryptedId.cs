using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProtection.Web.Migrations
{
    public partial class EncryptedId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EncryptedId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EncryptedId",
                table: "Products");
        }
    }
}
