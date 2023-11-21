using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class xxx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Premissions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valstybe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miestas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gatve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudPastas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefonas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AsmPastas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fakultetas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grupe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kursas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semesrtas = table.Column<int>(type: "int", nullable: true),
                    Programa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dalykas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lecturerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dalykas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dalykas_Person_lecturerId",
                        column: x => x.lecturerId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    DalykoId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfMark = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marks_Dalykas_DalykoId",
                        column: x => x.DalykoId,
                        principalTable: "Dalykas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marks_Person_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Semestras = table.Column<int>(type: "int", nullable: false),
                    Kursas = table.Column<int>(type: "int", nullable: false),
                    DalykoId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programm_Dalykas_DalykoId",
                        column: x => x.DalykoId,
                        principalTable: "Dalykas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dalykas_lecturerId",
                table: "Dalykas",
                column: "lecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_DalykoId",
                table: "Marks",
                column: "DalykoId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_StudentId",
                table: "Marks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Programm_DalykoId",
                table: "Programm",
                column: "DalykoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Programm");

            migrationBuilder.DropTable(
                name: "Dalykas");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
