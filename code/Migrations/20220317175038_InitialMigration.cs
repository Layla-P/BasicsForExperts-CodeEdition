using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicsForExperts.Web.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Waffles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Base = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waffles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Waffles_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderTopping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaffleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    WaffleType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTopping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTopping_Waffles_WaffleId",
                        column: x => x.WaffleId,
                        principalTable: "Waffles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber" },
                values: new object[] { 1, "Test@test.com", "Jakub", "01234564565" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber" },
                values: new object[] { 2, "Test2@test.com", "Layla", "012345256465" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Price", "UserId" },
                values: new object[] { 1, 15m, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Price", "UserId" },
                values: new object[] { 2, 17m, 2 });

            migrationBuilder.InsertData(
                table: "Waffles",
                columns: new[] { "Id", "Base", "OrderId" },
                values: new object[] { 1, "round", 1 });

            migrationBuilder.InsertData(
                table: "Waffles",
                columns: new[] { "Id", "Base", "OrderId" },
                values: new object[] { 2, "square", 2 });

            migrationBuilder.InsertData(
                table: "Waffles",
                columns: new[] { "Id", "Base", "OrderId" },
                values: new object[] { 3, "square", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTopping_WaffleId",
                table: "OrderTopping",
                column: "WaffleId");

            migrationBuilder.CreateIndex(
                name: "IX_Waffles_OrderId",
                table: "Waffles",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderTopping");

            migrationBuilder.DropTable(
                name: "Waffles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
