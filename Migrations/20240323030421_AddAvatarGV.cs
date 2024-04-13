using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLPreschool.Migrations
{
    /// <inheritdoc />
    public partial class AddAvatarGV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarGV",
                table: "GIAO VIEN",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarGV",
                table: "GIAO VIEN");
        }
    }
}
