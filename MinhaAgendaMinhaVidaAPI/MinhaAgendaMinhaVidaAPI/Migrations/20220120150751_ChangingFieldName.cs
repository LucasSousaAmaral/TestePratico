using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaAgendaMinhaVidaAPI.Migrations
{
    public partial class ChangingFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Agendas",
                newName: "CreationDate");

            migrationBuilder.UpdateData(
                table: "Agendas",
                keyColumn: "AgendaId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 1, 20, 12, 7, 51, 229, DateTimeKind.Local).AddTicks(2184));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Agendas",
                newName: "Data");

            migrationBuilder.UpdateData(
                table: "Agendas",
                keyColumn: "AgendaId",
                keyValue: 1,
                column: "Data",
                value: new DateTime(2022, 1, 20, 11, 48, 9, 543, DateTimeKind.Local).AddTicks(5251));
        }
    }
}
