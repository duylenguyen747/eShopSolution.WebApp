using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopSolution.Data.Migrations
{
	public partial class Inital : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "appConfigs",
				columns: table => new
				{
					Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_appConfigs", x => x.Key);
				});

			migrationBuilder.CreateTable(
				name: "appRoles",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
					NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_appRoles", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AppUsers",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
					LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
					Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
					UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
					NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
					EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
					PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
					SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
					TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
					LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
					LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
					AccessFailedCount = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AppUsers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Category",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					SortOrder = table.Column<int>(type: "int", nullable: false),
					IsShowOnHome = table.Column<bool>(type: "bit", nullable: false),
					ParentId = table.Column<int>(type: "int", nullable: true),
					Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Category", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Contacts",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
					Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
					PhoneNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
					Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Status = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Contacts", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Languages",
				columns: table => new
				{
					Id = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
					Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					IsDefault = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Languages", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Product",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
					Stock = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
					ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
					DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsFeatured = table.Column<bool>(type: "bit", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Product", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Promotions",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ApplyForAll = table.Column<bool>(type: "bit", nullable: false),
					DiscountPercent = table.Column<int>(type: "int", nullable: true),
					DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
					ProductIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ProductCategoryIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Status = table.Column<int>(type: "int", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Promotions", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "slides",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
					SortOrder = table.Column<int>(type: "int", nullable: false),
					Status = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_slides", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Order",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					ShipName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ShipAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ShipEmail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
					ShipPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Status = table.Column<int>(type: "int", nullable: false),
					AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Order", x => x.Id);
					table.ForeignKey(
						name: "FK_Order_AppUsers_AppUserId",
						column: x => x.AppUserId,
						principalTable: "AppUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Transactions",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ExternalTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Status = table.Column<int>(type: "int", nullable: false),
					Provider = table.Column<string>(type: "nvarchar(max)", nullable: false),
					UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Transactions", x => x.Id);
					table.ForeignKey(
						name: "FK_Transactions_AppUsers_UserId",
						column: x => x.UserId,
						principalTable: "AppUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "categoriesTranslation",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					CategoryId = table.Column<int>(type: "int", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					SeoDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
					SeoTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
					LanguageId = table.Column<string>(type: "varchar(5)", nullable: false),
					SeoAlias = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_categoriesTranslation", x => x.Id);
					table.ForeignKey(
						name: "FK_categoriesTranslation_Category_CategoryId",
						column: x => x.CategoryId,
						principalTable: "Category",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_categoriesTranslation_Languages_LanguageId",
						column: x => x.LanguageId,
						principalTable: "Languages",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Carts",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ProductId = table.Column<int>(type: "int", nullable: false),
					Quantity = table.Column<int>(type: "int", nullable: false),
					Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Carts", x => x.Id);
					table.ForeignKey(
						name: "FK_Carts_AppUsers_UserId",
						column: x => x.UserId,
						principalTable: "AppUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Carts_Product_ProductId",
						column: x => x.ProductId,
						principalTable: "Product",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "productImages",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ProductId = table.Column<int>(type: "int", nullable: false),
					ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
					IsDefault = table.Column<bool>(type: "bit", nullable: false),
					DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
					SortOrder = table.Column<int>(type: "int", nullable: false),
					FileSize = table.Column<long>(type: "bigint", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_productImages", x => x.Id);
					table.ForeignKey(
						name: "FK_productImages_Product_ProductId",
						column: x => x.ProductId,
						principalTable: "Product",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "ProductInCategory",
				columns: table => new
				{
					ProductId = table.Column<int>(type: "int", nullable: false),
					CategoryId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ProductInCategory", x => new { x.CategoryId, x.ProductId });
					table.ForeignKey(
						name: "FK_ProductInCategory_Category_CategoryId",
						column: x => x.CategoryId,
						principalTable: "Category",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ProductInCategory_Product_ProductId",
						column: x => x.ProductId,
						principalTable: "Product",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "ProductTranslations",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ProductId = table.Column<int>(type: "int", nullable: false),
					Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Details = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
					SeoDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
					SeoTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
					SeoAlias = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
					LanguageId = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ProductTranslations", x => x.Id);
					table.ForeignKey(
						name: "FK_ProductTranslations_Languages_LanguageId",
						column: x => x.LanguageId,
						principalTable: "Languages",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ProductTranslations_Product_ProductId",
						column: x => x.ProductId,
						principalTable: "Product",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "OrderDetail",
				columns: table => new
				{
					OrderId = table.Column<int>(type: "int", nullable: false),
					ProductId = table.Column<int>(type: "int", nullable: false),
					Quantity = table.Column<int>(type: "int", nullable: false),
					Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OrderDetail", x => new { x.OrderId, x.ProductId });
					table.ForeignKey(
						name: "FK_OrderDetail_Order_OrderId",
						column: x => x.OrderId,
						principalTable: "Order",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_OrderDetail_Product_ProductId",
						column: x => x.ProductId,
						principalTable: "Product",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Carts_ProductId",
				table: "Carts",
				column: "ProductId");

			migrationBuilder.CreateIndex(
				name: "IX_Carts_UserId",
				table: "Carts",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_categoriesTranslation_CategoryId",
				table: "categoriesTranslation",
				column: "CategoryId");

			migrationBuilder.CreateIndex(
				name: "IX_categoriesTranslation_LanguageId",
				table: "categoriesTranslation",
				column: "LanguageId");

			migrationBuilder.CreateIndex(
				name: "IX_Order_AppUserId",
				table: "Order",
				column: "AppUserId");

			migrationBuilder.CreateIndex(
				name: "IX_OrderDetail_ProductId",
				table: "OrderDetail",
				column: "ProductId");

			migrationBuilder.CreateIndex(
				name: "IX_productImages_ProductId",
				table: "productImages",
				column: "ProductId");

			migrationBuilder.CreateIndex(
				name: "IX_ProductInCategory_ProductId",
				table: "ProductInCategory",
				column: "ProductId");

			migrationBuilder.CreateIndex(
				name: "IX_ProductTranslations_LanguageId",
				table: "ProductTranslations",
				column: "LanguageId");

			migrationBuilder.CreateIndex(
				name: "IX_ProductTranslations_ProductId",
				table: "ProductTranslations",
				column: "ProductId");

			migrationBuilder.CreateIndex(
				name: "IX_Transactions_UserId",
				table: "Transactions",
				column: "UserId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "appConfigs");

			migrationBuilder.DropTable(
				name: "appRoles");

			migrationBuilder.DropTable(
				name: "Carts");

			migrationBuilder.DropTable(
				name: "categoriesTranslation");

			migrationBuilder.DropTable(
				name: "Contacts");

			migrationBuilder.DropTable(
				name: "OrderDetail");

			migrationBuilder.DropTable(
				name: "productImages");

			migrationBuilder.DropTable(
				name: "ProductInCategory");

			migrationBuilder.DropTable(
				name: "ProductTranslations");

			migrationBuilder.DropTable(
				name: "Promotions");

			migrationBuilder.DropTable(
				name: "slides");

			migrationBuilder.DropTable(
				name: "Transactions");

			migrationBuilder.DropTable(
				name: "Order");

			migrationBuilder.DropTable(
				name: "Category");

			migrationBuilder.DropTable(
				name: "Languages");

			migrationBuilder.DropTable(
				name: "Product");

			migrationBuilder.DropTable(
				name: "AppUsers");
		}
	}
}
