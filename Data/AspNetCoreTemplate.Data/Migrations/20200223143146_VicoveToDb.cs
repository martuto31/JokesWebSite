namespace AspNetCoreTemplate.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class VicoveToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vicoves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(nullable: true),
                    Content = table.Column<string>(maxLength: 300, nullable: false),
                    Points = table.Column<int>(nullable: false),
                    VicType = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vicoves", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vicoves");
        }
    }
}
