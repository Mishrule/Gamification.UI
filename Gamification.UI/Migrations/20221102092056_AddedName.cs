using Microsoft.EntityFrameworkCore.Migrations;

namespace Gamification.UI.Migrations
{
    public partial class AddedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "b0a66688-dc53-417c-af92-0715cbf05afa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "033520fa-c753-4aaf-ac65-45ad3db07d78");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "507bd1f6-7965-4da7-8fdb-28023e707c90", "AQAAAAEAACcQAAAAEGJfd8t148iyGM+zg+4GKtSnY8Y6qAJzP2qphkKt51e6wTGaIlMp/iXEuTZkiSTGwg==", "fabe9ab6-8ba4-4834-8101-8fd96618e9f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79d06374-ca6c-41ea-9df2-652ac242ea90", "AQAAAAEAACcQAAAAEJCkSC84BMa/Wom0yB1DWYH4QB3NMIe+fANGbXMj8BttSColRsXBamxZDVjiYI6sNQ==", "e076dd2e-a149-42aa-a635-38696886ec3d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "566aae65-8c95-4b4f-9d1e-4fb25788cfbd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "aed6933d-2e11-4dd8-bd75-4480645f8f89");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c992abd-aebb-4d42-95f3-4fa8ef9fb416", "AQAAAAEAACcQAAAAEGNBNkiOCF2l3VjTkrQlNNhFZPEWMpipEY7DmAzlvb4um40lxJfUe9KkzQ0DvykgZA==", "78384d91-5745-468d-9ab9-e3c6f812c9a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f588301-4e6b-49ee-bea1-0b7b83ae0d5b", "AQAAAAEAACcQAAAAECwiD+XeitdABTEKhbaNA5LYFFVcmy/42qzRUhFrx1hO4KC/CFvvp8zGZ2g1HKPWvQ==", "11a1a651-7801-45b9-8082-a6e3699b2367" });
        }
    }
}
