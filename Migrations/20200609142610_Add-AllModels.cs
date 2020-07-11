using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VueAsp.Migrations
{
    public partial class AddAllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Students_ProductId",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdSizes_Students_ProductId",
                table: "ProdSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdSizes_ProductSingle_ProductSingleSingleId",
                table: "ProdSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdSizes_Size_SizeId",
                table: "ProdSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductMass_Students_ProductId",
                table: "ProductMass");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSingle_Students_ProductId",
                table: "ProductSingle");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Brand_BrandId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_SubCategory_SubCategorySubId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_Category_CategoryId",
                table: "SubCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Size",
                table: "Size");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSingle",
                table: "ProductSingle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductMass",
                table: "ProductMass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photo",
                table: "Photo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "SubCategory",
                newName: "SubCategories");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Size",
                newName: "Sizes");

            migrationBuilder.RenameTable(
                name: "ProductSingle",
                newName: "ProductSingles");

            migrationBuilder.RenameTable(
                name: "ProductMass",
                newName: "ProductMasses");

            migrationBuilder.RenameTable(
                name: "Photo",
                newName: "Photos");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "Brands");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategories",
                newName: "IX_SubCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_SubCategorySubId",
                table: "Products",
                newName: "IX_Products_SubCategorySubId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_BrandId",
                table: "Products",
                newName: "IX_Products_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSingle_ProductId",
                table: "ProductSingles",
                newName: "IX_ProductSingles_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMass_ProductId",
                table: "ProductMasses",
                newName: "IX_ProductMasses_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Photo_ProductId",
                table: "Photos",
                newName: "IX_Photos_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories",
                column: "SubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "SizeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSingles",
                table: "ProductSingles",
                column: "SingleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMasses",
                table: "ProductMasses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "PhotoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "BrandId");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "CartProductMasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    CartId = table.Column<Guid>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProductMasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartProductMasses_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProductMasses_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cartProductSingles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    CartId = table.Column<Guid>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartProductSingles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cartProductSingles_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cartProductSingles_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProductMasses_CartId",
                table: "CartProductMasses",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProductMasses_ProductId",
                table: "CartProductMasses",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_cartProductSingles_CartId",
                table: "cartProductSingles",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_cartProductSingles_ProductId",
                table: "cartProductSingles",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Products_ProductId",
                table: "Photos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdSizes_Products_ProductId",
                table: "ProdSizes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdSizes_ProductSingles_ProductSingleSingleId",
                table: "ProdSizes",
                column: "ProductSingleSingleId",
                principalTable: "ProductSingles",
                principalColumn: "SingleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdSizes_Sizes_SizeId",
                table: "ProdSizes",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMasses_Products_ProductId",
                table: "ProductMasses",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_SubCategorySubId",
                table: "Products",
                column: "SubCategorySubId",
                principalTable: "SubCategories",
                principalColumn: "SubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSingles_Products_ProductId",
                table: "ProductSingles",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Products_ProductId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdSizes_Products_ProductId",
                table: "ProdSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdSizes_ProductSingles_ProductSingleSingleId",
                table: "ProdSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdSizes_Sizes_SizeId",
                table: "ProdSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductMasses_Products_ProductId",
                table: "ProductMasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCategorySubId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSingles_Products_ProductId",
                table: "ProductSingles");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropTable(
                name: "CartProductMasses");

            migrationBuilder.DropTable(
                name: "cartProductSingles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSingles",
                table: "ProductSingles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductMasses",
                table: "ProductMasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "SubCategories",
                newName: "SubCategory");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "Size");

            migrationBuilder.RenameTable(
                name: "ProductSingles",
                newName: "ProductSingle");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "ProductMasses",
                newName: "ProductMass");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "Photo");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brand");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategory",
                newName: "IX_SubCategory_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSingles_ProductId",
                table: "ProductSingle",
                newName: "IX_ProductSingle_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SubCategorySubId",
                table: "Students",
                newName: "IX_Students_SubCategorySubId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BrandId",
                table: "Students",
                newName: "IX_Students_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMasses_ProductId",
                table: "ProductMass",
                newName: "IX_ProductMass_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_ProductId",
                table: "Photo",
                newName: "IX_Photo_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory",
                column: "SubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Size",
                table: "Size",
                column: "SizeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSingle",
                table: "ProductSingle",
                column: "SingleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMass",
                table: "ProductMass",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photo",
                table: "Photo",
                column: "PhotoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Students_ProductId",
                table: "Photo",
                column: "ProductId",
                principalTable: "Students",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdSizes_Students_ProductId",
                table: "ProdSizes",
                column: "ProductId",
                principalTable: "Students",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdSizes_ProductSingle_ProductSingleSingleId",
                table: "ProdSizes",
                column: "ProductSingleSingleId",
                principalTable: "ProductSingle",
                principalColumn: "SingleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdSizes_Size_SizeId",
                table: "ProdSizes",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMass_Students_ProductId",
                table: "ProductMass",
                column: "ProductId",
                principalTable: "Students",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSingle_Students_ProductId",
                table: "ProductSingle",
                column: "ProductId",
                principalTable: "Students",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Brand_BrandId",
                table: "Students",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SubCategory_SubCategorySubId",
                table: "Students",
                column: "SubCategorySubId",
                principalTable: "SubCategory",
                principalColumn: "SubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_Category_CategoryId",
                table: "SubCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
