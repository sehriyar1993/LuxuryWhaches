using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuxuryWhaches.DataAcsessLayer.Migrations
{
    public partial class _mig_confirmcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ComfirmCode",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComfirmCode",
                table: "AspNetUsers");
        }
    }
}
