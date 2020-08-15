using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCMS.Infrastructure.Migrations
{
    public partial class remove_Desc_field2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "SiteInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "SiteInfo",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
