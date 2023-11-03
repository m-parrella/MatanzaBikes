using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatanzaBikes.Migrations
{
    public partial class MatanzaBikes : Migration
    {
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
                values: new object[] { 1, 2023, "12", "650", "Verde", "Disco", 1, "KLT 650", "4 tiempos", 160, 11067000m, 118.0, 5, "Hidraulica" });

            migrationBuilder.CreateIndex(
                name: "IX_Motos_MarcaId",
                table: "Motos",
                column: "MarcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motos");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
