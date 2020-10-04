using Microsoft.EntityFrameworkCore.Migrations;

namespace BowlingWebApplication.Data.Migrations
{
    public partial class BuildUpTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CumulativeScore",
                table: "Frames",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Delivery1Id",
                table: "Frames",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Delivery2Id",
                table: "Frames",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Delivery3Id",
                table: "Frames",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "Frames",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CumulativeScore",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "Delivery1Id",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "Delivery2Id",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "Delivery3Id",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "Frames");
        }
    }
}
