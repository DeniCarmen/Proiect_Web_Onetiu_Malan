using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Web_Onetiu_Malan.Migrations
{
    public partial class Country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "Destination",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destination_CountryID",
                table: "Destination",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Destination_Country_CountryID",
                table: "Destination",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destination_Country_CountryID",
                table: "Destination");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Destination_CountryID",
                table: "Destination");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "Destination");
        }
    }
}
