using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VueAsp.Migrations
{
    public partial class DbInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(nullable: false),
                    NameBrand = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    NameCategory = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeId = table.Column<Guid>(nullable: false),
                    SizeUA = table.Column<string>(nullable: true),
                    SizeUSA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    SubId = table.Column<Guid>(nullable: false),
                    NameSub = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.SubId);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    PriceBy = table.Column<float>(nullable: false),
                    BrandId = table.Column<Guid>(nullable: false),
                    SubId = table.Column<Guid>(nullable: false),
                    SubCategorySubId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Students_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_SubCategory_SubCategorySubId",
                        column: x => x.SubCategorySubId,
                        principalTable: "SubCategory",
                        principalColumn: "SubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    PhotoId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    ByteImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photo_Students_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Students",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductMass",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Boxes = table.Column<int>(nullable: false),
                    PairInBoxes = table.Column<int>(nullable: false),
                    PairsTotal = table.Column<int>(nullable: false),
                    priceSale = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMass_Students_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Students",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSingle",
                columns: table => new
                {
                    SingleId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Boxes = table.Column<int>(nullable: false),
                    PairInBoxes = table.Column<int>(nullable: false),
                    PairsTotal = table.Column<int>(nullable: false),
                    PriceSale = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSingle", x => x.SingleId);
                    table.ForeignKey(
                        name: "FK_ProductSingle_Students_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Students",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdSizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    SizeId = table.Column<Guid>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    ProductSingleSingleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdSizes_Students_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Students",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdSizes_ProductSingle_ProductSingleSingleId",
                        column: x => x.ProductSingleSingleId,
                        principalTable: "ProductSingle",
                        principalColumn: "SingleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdSizes_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ProductId",
                table: "Photo",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdSizes_ProductId",
                table: "ProdSizes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdSizes_ProductSingleSingleId",
                table: "ProdSizes",
                column: "ProductSingleSingleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdSizes_SizeId",
                table: "ProdSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMass_ProductId",
                table: "ProductMass",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSingle_ProductId",
                table: "ProductSingle",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_BrandId",
                table: "Students",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SubCategorySubId",
                table: "Students",
                column: "SubCategorySubId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "ProdSizes");

            migrationBuilder.DropTable(
                name: "ProductMass");

            migrationBuilder.DropTable(
                name: "ProductSingle");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
