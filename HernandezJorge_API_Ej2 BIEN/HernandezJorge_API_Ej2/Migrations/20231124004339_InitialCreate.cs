using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HernandezJorge_API_Ej2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    JuegoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.JuegoId);
                    table.ForeignKey(
                        name: "FK_Game_Genre_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genre",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GeneroId", "Nombre" },
                values: new object[] { 1, "Accion" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GeneroId", "Nombre" },
                values: new object[] { 2, "Aventura" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GeneroId", "Nombre" },
                values: new object[] { 3, "Carreras" });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "JuegoId", "GeneroId", "Titulo" },
                values: new object[] { 1, 1, "Juego1" });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "JuegoId", "GeneroId", "Titulo" },
                values: new object[] { 2, 2, "Juego2" });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "JuegoId", "GeneroId", "Titulo" },
                values: new object[] { 3, 3, "Juego3" });

            migrationBuilder.CreateIndex(
                name: "IX_Game_GeneroId",
                table: "Game",
                column: "GeneroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
