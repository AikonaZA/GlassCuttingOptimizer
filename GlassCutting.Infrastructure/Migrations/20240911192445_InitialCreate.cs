using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlassCutting.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "CutLayouts",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                StockSheetId = table.Column<int>(type: "INTEGER", nullable: false),
                WastePercentage = table.Column<double>(type: "REAL", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CutLayouts", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "GlassPanels",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Width = table.Column<double>(type: "REAL", nullable: false),
                Height = table.Column<double>(type: "REAL", nullable: false),
                Quantity = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_GlassPanels", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "StockSheets",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Width = table.Column<double>(type: "REAL", nullable: false),
                Height = table.Column<double>(type: "REAL", nullable: false),
                Quantity = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StockSheets", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "CutPositions",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                X = table.Column<double>(type: "REAL", nullable: false),
                Y = table.Column<double>(type: "REAL", nullable: false),
                Width = table.Column<double>(type: "REAL", nullable: false),
                Height = table.Column<double>(type: "REAL", nullable: false),
                CutLayoutId = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CutPositions", x => x.Id);
                table.ForeignKey(
                    name: "FK_CutPositions_CutLayouts_CutLayoutId",
                    column: x => x.CutLayoutId,
                    principalTable: "CutLayouts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_CutPositions_CutLayoutId",
            table: "CutPositions",
            column: "CutLayoutId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CutPositions");

        migrationBuilder.DropTable(
            name: "GlassPanels");

        migrationBuilder.DropTable(
            name: "StockSheets");

        migrationBuilder.DropTable(
            name: "CutLayouts");
    }
}