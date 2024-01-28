using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RECUPO01_HernandezJorge.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "producto",
            //    columns: table => new
            //    {
            //        codigo_producto = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nombre = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
            //        gama = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        dimensiones = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
            //        proveedor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        descripcion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
            //        cantidad_en_stock = table.Column<short>(type: "smallint", nullable: false),
            //        precio_venta = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
            //        precio_proveedor = table.Column<decimal>(type: "numeric(15,2)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__producto__105107A9906642F5", x => x.codigo_producto);
            //    });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Units = table.Column<int>(type: "int", nullable: false),
                    productoId = table.Column<int>(type: "int", nullable: false),
                    ComercialId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venta_producto_productoId",
                        column: x => x.productoId,
                        principalTable: "producto",
                        principalColumn: "codigo_producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Venta_productoId",
                table: "Venta",
                column: "productoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "producto");
        }
    }
}
