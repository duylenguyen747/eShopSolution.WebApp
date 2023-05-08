using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopSolution.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("508dce46-e973-49c9-94a1-3b6172fd1664"), "9428be1a-53c7-4a2b-8b4a-b949e6c260bc", "Adminisrtrator role", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("508dce46-e973-49c9-94a1-3b6172fd1664"), new Guid("d49f2b12-1d4a-4262-80da-405359c8bd3c") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d49f2b12-1d4a-4262-80da-405359c8bd3c"), 0, "a07a5f5e-a976-4bea-982c-99a7d35ba589", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "duylenguyen747@gmail.com", true, "Nguyen", "Duy", false, null, "duylenguyen747@gmail.com", "admin", "AQAAAAEAACcQAAAAEK1LE42d94Sm7woTPy4oNmB3QTtiGG3Zt/khZm5QPcXJPrjbZOyiI+lAfLkafL82zw==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 8, 11, 10, 6, 286, DateTimeKind.Local).AddTicks(7399));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("508dce46-e973-49c9-94a1-3b6172fd1664"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("508dce46-e973-49c9-94a1-3b6172fd1664"), new Guid("d49f2b12-1d4a-4262-80da-405359c8bd3c") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d49f2b12-1d4a-4262-80da-405359c8bd3c"));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 8, 10, 48, 14, 973, DateTimeKind.Local).AddTicks(7751));
        }
    }
}
