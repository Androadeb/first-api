using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace first_api.Migrations
{
    /// <inheritdoc />
    public partial class category100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "notes",
                table: "Categories",
                newName: "Notes");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Categories",
                newName: "notes");

            migrationBuilder.AlterColumn<string>(
                name: "notes",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
