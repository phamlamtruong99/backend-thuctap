using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTT.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phatuid",
                table: "dondangkys");

            migrationBuilder.AddColumn<string>(
                name: "trangthai",
                table: "phattus",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "trangthai",
                table: "phattus");

            migrationBuilder.AddColumn<int>(
                name: "phatuid",
                table: "dondangkys",
                type: "int",
                nullable: true);
        }
    }
}
