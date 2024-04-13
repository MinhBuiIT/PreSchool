using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLPreschool.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGVField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "GIAO VIEN",
                type: "ntext",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "GioiTinh",
                table: "GIAO VIEN",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "GIAO VIEN");

            migrationBuilder.DropColumn(
                name: "GioiTinh",
                table: "GIAO VIEN");
        }
    }
}
