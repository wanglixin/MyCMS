using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCMS.Infrastructure.Migrations
{
    public partial class add_Desc_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "SiteInfo",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "SiteInfo");
        }
    }
}
