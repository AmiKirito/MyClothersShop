using Microsoft.EntityFrameworkCore.Migrations;

namespace MyClothersShop.Migrations
{
    public partial class OneToManyTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothersImages");

            migrationBuilder.AddColumn<int>(
                name: "ClothId",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Clothers",
                keyColumn: "ClothId",
                keyValue: 1,
                columns: new[] { "Description", "Price" },
                values: new object[] { "You just can wear it anywhere :)", 250 });

            migrationBuilder.UpdateData(
                table: "Clothers",
                keyColumn: "ClothId",
                keyValue: 2,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Really comfortable and suits for any occasion", 500 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                columns: new[] { "ClothId", "PhotoPath" },
                values: new object[] { 1, "original_images/t-short.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2,
                columns: new[] { "ClothId", "PhotoPath" },
                values: new object[] { 2, "original_images/jeans.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ClothId", "PhotoPath" },
                values: new object[,]
                {
                    { 3, 1, "original_images/logo.png" },
                    { 4, 2, "original_images/test.png" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ClothId",
                table: "Images",
                column: "ClothId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Clothers_ClothId",
                table: "Images",
                column: "ClothId",
                principalTable: "Clothers",
                principalColumn: "ClothId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Clothers_ClothId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ClothId",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "ClothId",
                table: "Images");

            migrationBuilder.CreateTable(
                name: "ClothersImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    ClothId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Clothers",
                keyColumn: "ClothId",
                keyValue: 1,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Description about T-Short", 300 });

            migrationBuilder.UpdateData(
                table: "Clothers",
                keyColumn: "ClothId",
                keyValue: 2,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Description about Jeans", 300 });

            migrationBuilder.InsertData(
                table: "ClothersImages",
                columns: new[] { "ImageId", "ClothId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                column: "PhotoPath",
                value: "original_images/jeans.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2,
                column: "PhotoPath",
                value: "original_images/logo.png");

            migrationBuilder.CreateIndex(
                name: "IX_ClothersImages_ClothId",
                table: "ClothersImages",
                column: "ClothId");
        }
    }
}
