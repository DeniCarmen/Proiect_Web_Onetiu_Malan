using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Web_Onetiu_Malan.Migrations
{
    public partial class Reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    DestinationID = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservation_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Reservation_Destination_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "Destination",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ClientID",
                table: "Reservation",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_DestinationID",
                table: "Reservation",
                column: "DestinationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
