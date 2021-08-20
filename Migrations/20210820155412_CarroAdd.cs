using Microsoft.EntityFrameworkCore.Migrations;

namespace Webapi.Migrations
{
    public partial class CarroAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    modelo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    marca_id = table.Column<int>(type: "int", nullable: false),
                    ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.id);
                    table.ForeignKey(
                        name: "FK_Carros_Marcas_marca_id",
                        column: x => x.marca_id,
                        principalTable: "Marcas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_marca_id",
                table: "Carros",
                column: "marca_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
