using Microsoft.EntityFrameworkCore.Migrations;

namespace WhoWantsWhat.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
