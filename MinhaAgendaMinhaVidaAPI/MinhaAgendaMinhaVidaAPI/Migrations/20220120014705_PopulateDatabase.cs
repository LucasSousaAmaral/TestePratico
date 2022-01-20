using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaAgendaMinhaVidaAPI.Migrations
{
    public partial class PopulateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "AgendaId", "Data", "Description", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2022, 1, 19, 22, 47, 4, 971, DateTimeKind.Local).AddTicks(1407), "Anotações sobre dezembro", "Agenda Dezembro", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Login", "Name", "Password", "Role" },
                values: new object[] { 1, "LucasAmaral", "Amaral", "Amaral", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Login", "Name", "Password", "Role" },
                values: new object[] { 2, "MateusAmaral", "Mateus", "Mateus", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agendas",
                keyColumn: "AgendaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
