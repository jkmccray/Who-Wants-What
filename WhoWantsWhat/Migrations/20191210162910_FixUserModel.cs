using Microsoft.EntityFrameworkCore.Migrations;

namespace WhoWantsWhat.Migrations
{
    public partial class FixUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_ApplicationUserId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ApplicationUserId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Groups");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "170f081b-1ed5-49e1-be0e-f43d108e7122", "AQAAAAEAACcQAAAAEOM8XkV2z87wiu+qIo1vNvGu5bkCwN8rb5eqh82TqY+eUVWtwETxf1BpYHBPf545Ng==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffffffg",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "10ca944f-e3d7-4144-8f70-f83460bc0864", "AQAAAAEAACcQAAAAEBtrzUJrC3S5GncMBdWCzmCdtP1mJgAwsFp/hJiihnMx88hMJ925Z06NFli9uSk8Jg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Groups",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b401ab4d-917d-444e-8ad4-d3fbeb7a614d", "AQAAAAEAACcQAAAAEGA2vK/x/B7m9upH3aBVToAzLwUMHimZKPuc4svMAzlrIS0AeBHsRt31I4fJSIizVw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffffffg",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5252bd20-fbb9-4d5d-87b4-ba3d63dc8001", "AQAAAAEAACcQAAAAEDBxuvx26ZDJqJCGPZv1fOA8LFOv4R8Qxv/LG9CW5NQmL6HYtFyqAanQB59zAtBxBA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ApplicationUserId",
                table: "Groups",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AspNetUsers_ApplicationUserId",
                table: "Groups",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
