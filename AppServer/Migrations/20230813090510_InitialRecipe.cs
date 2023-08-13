using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    RecipeRating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.ID);
                    table.CheckConstraint("RatingCheck", "RecipeRating >= 0 AND RecipeRating < 6");
                });

            migrationBuilder.CreateTable(
                name: "ImagePath",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipeDBID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagePath", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImagePath_Recipes_RecipeDBID",
                        column: x => x.RecipeDBID,
                        principalTable: "Recipes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UsedDate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipeDBID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedDate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsedDate_Recipes_RecipeDBID",
                        column: x => x.RecipeDBID,
                        principalTable: "Recipes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagePath_RecipeDBID",
                table: "ImagePath",
                column: "RecipeDBID");

            migrationBuilder.CreateIndex(
                name: "IX_UsedDate_RecipeDBID",
                table: "UsedDate",
                column: "RecipeDBID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagePath");

            migrationBuilder.DropTable(
                name: "UsedDate");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
