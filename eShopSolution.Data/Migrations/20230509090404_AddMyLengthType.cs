using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopSolution.Data.Migrations
{
    public partial class AddMyLengthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categoriesTranslation_Category_CategoryId",
                table: "categoriesTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_categoriesTranslation_Languages_LanguageId",
                table: "categoriesTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_slides",
                table: "slides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categoriesTranslation",
                table: "categoriesTranslation");

            migrationBuilder.RenameTable(
                name: "slides",
                newName: "Slides");

            migrationBuilder.RenameTable(
                name: "categoriesTranslation",
                newName: "CategoryTranslations");

            migrationBuilder.RenameIndex(
                name: "IX_categoriesTranslation_LanguageId",
                table: "CategoryTranslations",
                newName: "IX_CategoryTranslations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_categoriesTranslation_CategoryId",
                table: "CategoryTranslations",
                newName: "IX_CategoryTranslations_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Slides",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Slides",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Slides",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Slides",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SeoTitle",
                table: "CategoryTranslations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SeoDescription",
                table: "CategoryTranslations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SeoAlias",
                table: "CategoryTranslations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CategoryTranslations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slides",
                table: "Slides",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTranslations",
                table: "CategoryTranslations",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("508dce46-e973-49c9-94a1-3b6172fd1664"),
                column: "ConcurrencyStamp",
                value: "2382aecb-5310-425d-b301-a5088ba88517");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d49f2b12-1d4a-4262-80da-405359c8bd3c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9e1c3d6b-a318-4b7d-9b2d-1a62b9971988", "AQAAAAEAACcQAAAAELNZ/7rhw1EvCcZ6Pr/qno5qUffqFIz8Rg06JFVvVRNALkFynrk0eZSjRgEWDwAaFg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 9, 16, 4, 3, 423, DateTimeKind.Local).AddTicks(1262));

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslations_Category_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslations_Languages_LanguageId",
                table: "CategoryTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslations_Category_CategoryId",
                table: "CategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslations_Languages_LanguageId",
                table: "CategoryTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slides",
                table: "Slides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTranslations",
                table: "CategoryTranslations");

            migrationBuilder.RenameTable(
                name: "Slides",
                newName: "slides");

            migrationBuilder.RenameTable(
                name: "CategoryTranslations",
                newName: "categoriesTranslation");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTranslations_LanguageId",
                table: "categoriesTranslation",
                newName: "IX_categoriesTranslation_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTranslations_CategoryId",
                table: "categoriesTranslation",
                newName: "IX_categoriesTranslation_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "slides",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "slides",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "slides",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "slides",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SeoTitle",
                table: "categoriesTranslation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SeoDescription",
                table: "categoriesTranslation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "SeoAlias",
                table: "categoriesTranslation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "categoriesTranslation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_slides",
                table: "slides",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categoriesTranslation",
                table: "categoriesTranslation",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("508dce46-e973-49c9-94a1-3b6172fd1664"),
                column: "ConcurrencyStamp",
                value: "4e206259-4e61-4a1a-a2ce-b528def8f9a9");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d49f2b12-1d4a-4262-80da-405359c8bd3c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7828ca6c-4c5b-469d-bfee-d67cd2c869c0", "AQAAAAEAACcQAAAAEJIS0XQJhT2gMhUviy7bR0l63K2gjReOTLdT086J42Ube0e4xwNIBdIYjEKykiDwMw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 9, 13, 52, 51, 807, DateTimeKind.Local).AddTicks(6276));

            migrationBuilder.AddForeignKey(
                name: "FK_categoriesTranslation_Category_CategoryId",
                table: "categoriesTranslation",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_categoriesTranslation_Languages_LanguageId",
                table: "categoriesTranslation",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
