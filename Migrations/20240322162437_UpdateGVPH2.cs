using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLPreschool.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGVPH2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SDT_PHUHUYNH",
                table: "PHU HUYNH",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SDT_GV",
                table: "GIAO VIEN",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SDT_PHUHUYNH",
                table: "PHU HUYNH",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<int>(
                name: "SDT_GV",
                table: "GIAO VIEN",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");
        }
    }
}
