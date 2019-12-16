using Microsoft.EntityFrameworkCore.Migrations;

namespace WhoWantsWhat.Migrations
{
    public partial class updateAppDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWishList_Groups_GroupId",
                table: "GroupWishList");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupWishList_WishLists_WishListId",
                table: "GroupWishList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupWishList",
                table: "GroupWishList");

            migrationBuilder.RenameTable(
                name: "GroupWishList",
                newName: "GroupWishLists");

            migrationBuilder.RenameIndex(
                name: "IX_GroupWishList_WishListId",
                table: "GroupWishLists",
                newName: "IX_GroupWishLists_WishListId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupWishList_GroupId",
                table: "GroupWishLists",
                newName: "IX_GroupWishLists_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupWishLists",
                table: "GroupWishLists",
                column: "GroupWishListId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6d86770a-6eea-4721-b96a-43da53bc03c4", "AQAAAAEAACcQAAAAELo+27nDpm1tY7eK/wI56Lo/WJr1wZYRfBObgb+grNHkdsq81wd+j7Sov9DqNP3gRg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffffffg",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "84fd92f2-7b4f-49ff-a9ae-37189a9569d9", "AQAAAAEAACcQAAAAEB8j8PgeiKzeFZ1aSBCxXb+uyXZCdISDiy/R2yubFj8FoVXgQAWLpfvEFVGvX2fcCg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWishLists_Groups_GroupId",
                table: "GroupWishLists",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWishLists_WishLists_WishListId",
                table: "GroupWishLists",
                column: "WishListId",
                principalTable: "WishLists",
                principalColumn: "WishListId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWishLists_Groups_GroupId",
                table: "GroupWishLists");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupWishLists_WishLists_WishListId",
                table: "GroupWishLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupWishLists",
                table: "GroupWishLists");

            migrationBuilder.RenameTable(
                name: "GroupWishLists",
                newName: "GroupWishList");

            migrationBuilder.RenameIndex(
                name: "IX_GroupWishLists_WishListId",
                table: "GroupWishList",
                newName: "IX_GroupWishList_WishListId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupWishLists_GroupId",
                table: "GroupWishList",
                newName: "IX_GroupWishList_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupWishList",
                table: "GroupWishList",
                column: "GroupWishListId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWishList_Groups_GroupId",
                table: "GroupWishList",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWishList_WishLists_WishListId",
                table: "GroupWishList",
                column: "WishListId",
                principalTable: "WishLists",
                principalColumn: "WishListId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
