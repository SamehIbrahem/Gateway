using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GatewayTask.Repo.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gateways",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPv4Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gateways", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UID = table.Column<long>(type: "bigint", nullable: false),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    GatewayId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Device_Gateways_GatewayId",
                        column: x => x.GatewayId,
                        principalTable: "Gateways",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Gateways",
                columns: new[] { "Id", "Created", "IPv4Address", "Modified", "Name", "SerialNumber" },
                values: new object[] { 1, new DateTime(2021, 5, 20, 1, 3, 41, 349, DateTimeKind.Local).AddTicks(3384), "http", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "First Gateway", "123456789-77-1" });

            migrationBuilder.InsertData(
                table: "Gateways",
                columns: new[] { "Id", "Created", "IPv4Address", "Modified", "Name", "SerialNumber" },
                values: new object[] { 2, new DateTime(2021, 5, 20, 1, 3, 41, 350, DateTimeKind.Local).AddTicks(4591), "http", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Second Gateway", "123456789-33-2" });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "Created", "GatewayId", "Modified", "Status", "UID", "Vendor" },
                values: new object[] { 1, new DateTime(2021, 5, 20, 1, 3, 41, 351, DateTimeKind.Local).AddTicks(8442), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 11122L, "Device 1 Vendor" });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "Created", "GatewayId", "Modified", "Status", "UID", "Vendor" },
                values: new object[] { 2, new DateTime(2021, 5, 20, 1, 3, 41, 352, DateTimeKind.Local).AddTicks(73), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 12347L, "Device 2 Vendor" });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "Created", "GatewayId", "Modified", "Status", "UID", "Vendor" },
                values: new object[] { 3, new DateTime(2021, 5, 20, 1, 3, 41, 352, DateTimeKind.Local).AddTicks(120), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 331117L, "Device 3 Vendor" });

            migrationBuilder.CreateIndex(
                name: "IX_Device_GatewayId",
                table: "Device",
                column: "GatewayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "Gateways");
        }
    }
}
