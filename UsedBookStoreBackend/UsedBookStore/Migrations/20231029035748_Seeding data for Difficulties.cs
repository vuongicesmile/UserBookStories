using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsedBookStore.Migrations
{
    public partial class SeedingdataforDifficulties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulty", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("7eecec1a-1bc4-4a9c-b155-9c9380289918"), "Hard" });

            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e93f05be-4b4b-48be-accf-6a517cdbe047"), "Easy" });

            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("fd916900-429f-4102-915a-0464670c3a65"), "Medium" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Difficulty");
        }
    }
}
