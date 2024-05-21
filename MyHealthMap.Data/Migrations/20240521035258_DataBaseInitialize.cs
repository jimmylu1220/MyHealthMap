using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyHealthMap.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseInitialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "City", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "830高雄市鳳山區五甲三路27號", "高雄市", "勁請享用健康廚房-鳳山五甲店", "078210715" },
                    { 2, "830高雄市鳳山區忠誠路27號", "高雄市", "懂吃健康餐廚-五甲店", "0971708796" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Calories", "Description", "ImageUrl", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 435.0, "低脂且高蛋白的雞胸肉\r\n不論是想大口吃肉又想減少身體負擔的你\r\n或者想增肌減脂的你\r\n都會是個不錯的選擇唷", null, "舒肥雞胸餐盒", 105, 1 },
                    { 2, 558.0, "無骨雞腿丁\r\n加入洋蔥木耳紅蘿蔔及杏鮑菇一起拌炒\r\n\r\n逼出蔬菜的鮮甜及雞腿丁的香氣加入調醬融合\r\n口感紮實爽脆還能補充大量膳食纖維\r\n吃起來鹹甜鹹甜像紅燒的味道", null, "醬燒春雞餐盒", 115, 1 },
                    { 3, 525.0, "店家獨門熬煮薑汁與豬肉大火快炒", null, "薑汁燒肉豬", 129, 2 },
                    { 4, 576.0, "煮熟後的嫩雞腿，再用獨家照燒醬燉煮", null, "照燒嫩雞腿", 129, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_RestaurantId",
                table: "Menus",
                column: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
