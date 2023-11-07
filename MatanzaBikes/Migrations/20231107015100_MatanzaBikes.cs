using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MatanzaBikes.Migrations
{
    /// <inheritdoc />
    public partial class MatanzaBikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cilindrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    Motor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bateria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Rodado = table.Column<double>(type: "float", nullable: false),
                    Suspension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frenos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Ducati" },
                    { 2, "Harley Davidson" },
                    { 3, "Honda" },
                    { 4, "Yamaha" }
                });

            migrationBuilder.InsertData(
                table: "Motos",
                columns: new[] { "Id", "Año", "Bateria", "Cilindrada", "Color", "Frenos", "MarcaId", "Modelo", "Motor", "Peso", "Precio", "Rodado", "Stock", "Suspension" },
                values: new object[,]
                {
                    { 3, 2023, "12", "650", "Verde", "Disco", 3, "Mongolia", "4 tiempos", 197, 238m, 207.0, 572, "Hidraulica" },
                    { 4, 2023, "12", "650", "Verde", "Disco", 2, "Greece", "4 tiempos", 112, 244m, 271.0, 608, "Hidraulica" },
                    { 5, 2023, "12", "650", "Verde", "Disco", 3, "Equatorial Guinea", "4 tiempos", 360, 269m, 367.0, 341, "Hidraulica" },
                    { 6, 2023, "12", "650", "Verde", "Disco", 1, "Bermuda", "4 tiempos", 251, 236m, 215.0, 843, "Hidraulica" },
                    { 7, 2023, "12", "650", "Verde", "Disco", 1, "Belarus", "4 tiempos", 388, 267m, 61.0, 701, "Hidraulica" },
                    { 8, 2023, "12", "650", "Verde", "Disco", 1, "Brazil", "4 tiempos", 338, 126m, 105.0, 33, "Hidraulica" },
                    { 9, 2023, "12", "650", "Verde", "Disco", 3, "Germany", "4 tiempos", 273, 86m, 34.0, 726, "Hidraulica" },
                    { 10, 2023, "12", "650", "Verde", "Disco", 3, "Virgin Islands (U.S.)", "4 tiempos", 305, 19m, 143.0, 386, "Hidraulica" },
                    { 11, 2023, "12", "650", "Verde", "Disco", 1, "Côte d'Ivoire", "4 tiempos", 361, 291m, 5.0, 235, "Hidraulica" },
                    { 12, 2023, "12", "650", "Verde", "Disco", 2, "Costa Rica", "4 tiempos", 294, 183m, 53.0, 676, "Hidraulica" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motos_MarcaId",
                table: "Motos",
                column: "MarcaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motos");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
