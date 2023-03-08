using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LostInTime.Migrations
{
    /// <inheritdoc />
    public partial class TemplateGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemplateGroups",
                columns: table => new
                {
                    TemplateGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateGroups", x => x.TemplateGroupId);
                });

            migrationBuilder.CreateTable(
                name: "TemplateGroupItem",
                columns: table => new
                {
                    TemplateGroupItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResetType = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    TemplateGroupId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsChecked = table.Column<bool>(type: "INTEGER", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateGroupItem", x => x.TemplateGroupItemId);
                    table.ForeignKey(
                        name: "FK_TemplateGroupItem_TemplateGroups_TemplateGroupId",
                        column: x => x.TemplateGroupId,
                        principalTable: "TemplateGroups",
                        principalColumn: "TemplateGroupId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateGroupItem_TemplateGroupId",
                table: "TemplateGroupItem",
                column: "TemplateGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateGroupItem");

            migrationBuilder.DropTable(
                name: "TemplateGroups");
        }
    }
}
