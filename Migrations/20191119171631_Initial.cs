using Microsoft.EntityFrameworkCore.Migrations;

namespace MyClothersShop.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clothers",
                columns: table => new
                {
                    ClothId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothers", x => x.ClothId);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "ClothersImages",
                columns: table => new
                {
                    ClothId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothersImages", x => new { x.ImageId, x.ClothId });
                    table.ForeignKey(
                        name: "FK_ClothersImages_Clothers_ClothId",
                        column: x => x.ClothId,
                        principalTable: "Clothers",
                        principalColumn: "ClothId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothersImages_Images_ClothId",
                        column: x => x.ClothId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clothers",
                columns: new[] { "ClothId", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Description about T-Short", 300, "T-Short" },
                    { 2, "Description about Jeans", 300, "Jeans" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "PhotoPath" },
                values: new object[,]
                {
                    { 1, "original_images/jeans.jpg" },
                    { 2, "original_images/logo.png" }
                });

            migrationBuilder.InsertData(
                table: "ClothersImages",
                columns: new[] { "ImageId", "ClothId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothersImages_ClothId",
                table: "ClothersImages",
                column: "ClothId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothersImages");

            migrationBuilder.DropTable(
                name: "Clothers");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
