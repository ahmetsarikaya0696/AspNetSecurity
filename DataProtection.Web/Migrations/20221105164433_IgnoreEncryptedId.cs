using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProtection.Web.Migrations
{
    public partial class IgnoreEncryptedId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EncryptedId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EncryptedId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
