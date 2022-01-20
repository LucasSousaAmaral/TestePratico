using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaAgendaMinhaVidaAPI.Migrations
{
    public partial class ResetModelSimplificationInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    AgendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.AgendaId);
                });

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "AgendaId", "Data", "Description", "Title" },
                values: new object[] { 1, new DateTime(2022, 1, 20, 11, 48, 9, 543, DateTimeKind.Local).AddTicks(5251), "Anotações sobre dezembro", "Agenda Dezembro" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");
        }
    }
}
