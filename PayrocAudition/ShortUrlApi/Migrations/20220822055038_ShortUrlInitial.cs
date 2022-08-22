using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShortUrlApi.Migrations
{
    public partial class ShortUrlInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShortUrlRecords",
                columns: table => new
                {
                    ShortUrlRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlUniqueCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortUrlRecords", x => x.ShortUrlRecordId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortUrlRecords");
        }
    }
}
