using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex.Migrations
{
    /// <inheritdoc />
    public partial class PokemonMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pokemonRegion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemonRegion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pokemonType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemonType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PrimaryType = table.Column<int>(type: "int", nullable: false),
                    SecondaryType = table.Column<int>(type: "int", nullable: false),
                    RegionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemons_pokemonRegion_RegionID",
                        column: x => x.RegionID,
                        principalTable: "pokemonRegion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemons_pokemonType_SecondaryType",
                        column: x => x.SecondaryType,
                        principalTable: "pokemonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_RegionID",
                table: "Pokemons",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_SecondaryType",
                table: "Pokemons",
                column: "SecondaryType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "pokemonRegion");

            migrationBuilder.DropTable(
                name: "pokemonType");
        }
    }
}
