using Microsoft.EntityFrameworkCore.Migrations;

namespace WhoWantsWhat.Migrations
{
    public partial class removedGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2103d41-cddb-412b-9467-6db7b077ffc6", "AQAAAAEAACcQAAAAEMvqO5y0ZB1iB/zSIpwiLyf+5JvNeYdlLjK+CnU2L9NBeDdAn7IHVfKbuE473DKEGg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffffffg",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bba5d015-7cea-4630-885b-76892793658d", "AQAAAAEAACcQAAAAEHEhy8NSw9CNsK6KTBtujNFvMeUN6cRJoUE6/At7s9xPOjtUp1vIsK3i/vPkZP3C2w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "Name" },
                values: new object[] { 2, "Nashville Friends" });
        }
    }
}
