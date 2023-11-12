using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanesTuristicos.Migrations
{
    /// <inheritdoc />
    public partial class y : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanesT",
                columns: table => new
                {
                    Id_PlanTuristicos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_PlanTuristico = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Rut = table.Column<int>(type: "int", nullable: true),
                    Municipio = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Precio = table.Column<double>(type: "float", unicode: false, maxLength: 50, nullable: false),
                    Actividades = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: true),
                    Duracion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Informacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PlanesT__Id", x => x.Id_PlanTuristicos);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id_Proveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_turista = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Rut = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: true),
                    cedula = table.Column<int>(type: "int", nullable: true),
                    correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    direccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Clave = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proveedores__Id", x => x.Id_Proveedor);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_turista = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    cedula = table.Column<int>(type: "int", nullable: true),
                    direccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: true),
                    Clave = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__5B65BF971AB28277", x => x.IdUsuario);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanesT");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
