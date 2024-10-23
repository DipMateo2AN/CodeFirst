using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Droguerias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cuit = table.Column<int>(type: "int", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Droguerias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monodrogas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monodrogas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreComercial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsVentaLibre = table.Column<bool>(type: "bit", nullable: false),
                    PrecioVenta = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    StockMinimo = table.Column<int>(type: "int", nullable: false),
                    MonodrogaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicamentos_Monodrogas_MonodrogaId",
                        column: x => x.MonodrogaId,
                        principalTable: "Monodrogas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrogueriaMedicamento",
                columns: table => new
                {
                    DrogueriasId = table.Column<int>(type: "int", nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrogueriaMedicamento", x => new { x.DrogueriasId, x.MedicamentoId });
                    table.ForeignKey(
                        name: "FK_DrogueriaMedicamento_Droguerias_DrogueriasId",
                        column: x => x.DrogueriasId,
                        principalTable: "Droguerias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrogueriaMedicamento_Medicamentos_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrogueriaMedicamento_MedicamentoId",
                table: "DrogueriaMedicamento",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_MonodrogaId",
                table: "Medicamentos",
                column: "MonodrogaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrogueriaMedicamento");

            migrationBuilder.DropTable(
                name: "Droguerias");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Monodrogas");
        }
    }
}
