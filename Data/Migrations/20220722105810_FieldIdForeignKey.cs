using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FieldBooking.Data.Migrations
{
    public partial class FieldIdForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59e5371a-ffed-4119-8723-e35763bbff4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b51cb9ca-c747-4f63-8b39-8dc565a20127");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e7b6222-fad4-431b-ab21-381e76bfaa1b", "d70191d7-9fca-4bd1-833b-976e00484751", "Administator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28fb34ea-5e83-48a4-b775-e5d04c043332", "ee69f22c-ed29-4f3c-99fa-c6c099b64a8d", "Player", "PLAYER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e7b6222-fad4-431b-ab21-381e76bfaa1b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28fb34ea-5e83-48a4-b775-e5d04c043332");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "59e5371a-ffed-4119-8723-e35763bbff4d", "b40600e3-0fc1-4b96-9e50-9d3c3febda15", "Administator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b51cb9ca-c747-4f63-8b39-8dc565a20127", "5929c9a2-73cb-4606-8ab7-2aa83bb9038d", "Player", "PLAYER" });
        }
    }
}
