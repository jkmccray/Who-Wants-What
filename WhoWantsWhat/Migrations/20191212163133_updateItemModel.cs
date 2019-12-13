using Microsoft.EntityFrameworkCore.Migrations;

namespace WhoWantsWhat.Migrations
{
    public partial class updateItemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PurchaserId",
                table: "Items",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "81ef8ce6-4bc4-48f4-a4dc-46609b10993e", "AQAAAAEAACcQAAAAEJPH3fYGxXMMds+Y8pg8ageUbP/Z/QQYMwOlSElKjPIyisHOHJWnwMRPeNgixjjrRQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffffffg",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5da40900-05b9-497c-aff5-984b389c7998", "AQAAAAEAACcQAAAAEAiDLXgSsE0NiCnZUK9pp3OEr/+7n5fuqtjW9v/564d7+7rH+Xgo6b2a9SLHopz+Nw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Items_PurchaserId",
                table: "Items",
                column: "PurchaserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_PurchaserId",
                table: "Items",
                column: "PurchaserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_PurchaserId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_PurchaserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PurchaserId",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "01f5dde3-868b-483b-8903-94427286f0f7", "AQAAAAEAACcQAAAAEL600n8CLKNK7gxird6h2nGvNQAJQOOWsAfNLEJaHH1ZyWDAKBG2KTsN0u8i+AJ0VA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffffffg",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dff2fe59-bda4-46b9-9938-b277dd99f3d7", "AQAAAAEAACcQAAAAEMeOX9p+bvN8+3WwhXmiNEMw0LYD/+Wc7NVozlSSHG7ux5f1Bo9HH4qMjSbyVnI0CQ==" });
        }
    }
}
