using Microsoft.EntityFrameworkCore.Migrations;

namespace WhoWantsWhat.Migrations
{
    public partial class updateItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Items",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "15af3195-9ce7-4bb1-9048-3b945c8f1a3c", "AQAAAAEAACcQAAAAEFWQmYoxzT+9T3pPHz1Z/ykcic1mjMX3FjKy3xJPU1hsPcjpfebQYMb5nh11rwxQdQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffffffg",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8bb52b52-3cec-4caf-8450-9923ceb3b230", "AQAAAAEAACcQAAAAEGMPweDHsgzdKhW7ukPQYDXI7UA8vSOFB4uGTPvVmbuvo62O5lI3LAhCdK9QHjyhSg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Items");

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
        }
    }
}
