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
                    { 3, 2023, "12", "650", "Verde", "Disco", 1, "New Zealand", "4 tiempos", 216, 226m, 239.0, 262, "Hidraulica" },
                    { 4, 2023, "12", "650", "Verde", "Disco", 1, "Egypt, Arab Rep.", "4 tiempos", 363, 241m, 311.0, 532, "Hidraulica" },
                    { 5, 2023, "12", "650", "Verde", "Disco", 2, "Suriname", "4 tiempos", 376, 259m, 218.0, 820, "Hidraulica" },
                    { 6, 2023, "12", "650", "Verde", "Disco", 2, "Yemen, Rep.", "4 tiempos", 368, 183m, 22.0, 786, "Hidraulica" },
                    { 7, 2023, "12", "650", "Verde", "Disco", 2, "Zimbabwe", "4 tiempos", 195, 45m, 148.0, 636, "Hidraulica" },
                    { 8, 2023, "12", "650", "Verde", "Disco", 1, "Azerbaijan", "4 tiempos", 385, 140m, 10.0, 319, "Hidraulica" },
                    { 9, 2023, "12", "650", "Verde", "Disco", 3, "India", "4 tiempos", 275, 272m, 385.0, 190, "Hidraulica" },
                    { 10, 2023, "12", "650", "Verde", "Disco", 2, "Eritrea", "4 tiempos", 241, 187m, 25.0, 645, "Hidraulica" },
                    { 11, 2023, "12", "650", "Verde", "Disco", 1, "Korea, Dem. Rep.", "4 tiempos", 246, 177m, 290.0, 204, "Hidraulica" },
                    { 12, 2023, "12", "650", "Verde", "Disco", 3, "Kiribati", "4 tiempos", 272, 256m, 184.0, 816, "Hidraulica" }
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
