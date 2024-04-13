using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLPreschool.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_maGV",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_maPH",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "maPH",
                table: "Users",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "maGV",
                table: "Users",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateIndex(
                name: "IX_Users_maGV",
                table: "Users",
                column: "maGV",
                unique: true,
                filter: "[maGV] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_maPH",
                table: "Users",
                column: "maPH",
                unique: true,
                filter: "[maPH] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_maGV",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_maPH",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "maPH",
                table: "Users",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "maGV",
                table: "Users",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_maGV",
                table: "Users",
                column: "maGV",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_maPH",
                table: "Users",
                column: "maPH",
                unique: true);
        }
    }
}
