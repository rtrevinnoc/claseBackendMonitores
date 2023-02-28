using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Monitores.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    width = table.Column<float>(type: "real", nullable: false),
                    length = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Monitors",
                columns: table => new
                {
                    EMonitorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    size = table.Column<float>(type: "real", nullable: false),
                    displayType = table.Column<int>(type: "int", nullable: false),
                    refreshRate = table.Column<int>(type: "int", nullable: false),
                    brand = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitors", x => x.EMonitorId);
                    table.ForeignKey(
                        name: "FK_Monitors_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monitors_RoomId",
                table: "Monitors",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monitors");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
