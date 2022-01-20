using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaAgendaMinhaVidaAPI.Migrations
{
    public partial class ResetMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    AgendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.AgendaId);
                    table.ForeignKey(
                        name: "FK_Agendas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Login", "Name", "Password", "Role" },
                values: new object[] { 1, "LucasAmaral", "Amaral", "Amaral", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Login", "Name", "Password", "Role" },
                values: new object[] { 2, "MateusAmaral", "Mateus", "Mateus", 1 });

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "AgendaId", "Data", "Description", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2022, 1, 20, 0, 19, 52, 400, DateTimeKind.Local).AddTicks(8334), "Anotações sobre dezembro", "Agenda Dezembro", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_UserId",
                table: "Agendas",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
