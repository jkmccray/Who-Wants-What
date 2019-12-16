using Microsoft.EntityFrameworkCore.Migrations;

namespace WhoWantsWhat.Migrations
{
    public partial class shareWishLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupWishList",
                columns: table => new
                {
                    GroupWishListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false),
                    WishListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupWishList", x => x.GroupWishListId);
                    table.ForeignKey(
                        name: "FK_GroupWishList_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupWishList_WishLists_WishListId",
                        column: x => x.WishListId,
                        principalTable: "WishLists",
                        principalColumn: "WishListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f9d641c1-29b0-4de9-a184-cd4648e4defa", "AQAAAAEAACcQAAAAEMikI3OMnAxAOq9sLuY6jtzObabaJ8OonMaGVBKQ/A8J/1hjY7SPj/UXdMpEFYe81Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffffffg",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e398b612-0e4e-487b-9acf-7eb191a71e8a", "AQAAAAEAACcQAAAAEIBQtALLmw8uM1S+bFs3ZydzIB31Q3kU0akGLK9lAHfnRjJNetYlFCoUeLCEUfPQKQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupWishList_GroupId",
                table: "GroupWishList",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWishList_WishListId",
                table: "GroupWishList",
                column: "WishListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupWishList");

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
        }
    }
}
