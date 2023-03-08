using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LostInTime.Migrations
{
    /// <inheritdoc />
    public partial class CharacterLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Characters",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<ulong>(
                name: "ItemLevel",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<ulong>(
                name: "Level",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemLevel",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Characters");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Characters",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
