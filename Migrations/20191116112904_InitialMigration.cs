using Microsoft.EntityFrameworkCore.Migrations;

namespace MyClothersShop.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clothers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clothers",
                columns: new[] { "Id", "Description", "PhotoPath", "Price", "Title" },
                values: new object[] { 1, "You can wear it anyhwere", "~/images/t-short.jpg", 150, "T-Short" });

            migrationBuilder.InsertData(
                table: "Clothers",
                columns: new[] { "Id", "Description", "PhotoPath", "Price", "Title" },
                values: new object[] { 2, "This jeans are very comfortable for any occasion", "~/images/jeans.jpg", 300, "Jeans" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clothers");
        }
    }
}
