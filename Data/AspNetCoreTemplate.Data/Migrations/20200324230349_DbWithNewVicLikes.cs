namespace AspNetCoreTemplate.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DbWithNewVicLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedAndVicove");

            migrationBuilder.DropTable(
                name: "LikedIdentities");

            migrationBuilder.CreateTable(
                name: "VicLikes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VicId = table.Column<int>(nullable: false),
                    UserAgent = table.Column<string>(nullable: true),
                    IPAdress = table.Column<string>(nullable: true),
                    UserLike = table.Column<bool>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VicLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VicLikes_Vicoves_VicId",
                        column: x => x.VicId,
                        principalTable: "Vicoves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VicLikes_VicId",
                table: "VicLikes",
                column: "VicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VicLikes");

            migrationBuilder.CreateTable(
                name: "LikedIdentities",
                columns: table => new
                {
                    IdentityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikedIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedIdentities", x => x.IdentityId);
                });

            migrationBuilder.CreateTable(
                name: "LikedAndVicove",
                columns: table => new
                {
                    VicId = table.Column<int>(type: "int", nullable: false),
                    LikedId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedAndVicove", x => new { x.VicId, x.LikedId });
                    table.ForeignKey(
                        name: "FK_LikedAndVicove_LikedIdentities_LikedId",
                        column: x => x.LikedId,
                        principalTable: "LikedIdentities",
                        principalColumn: "IdentityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedAndVicove_Vicoves_VicId",
                        column: x => x.VicId,
                        principalTable: "Vicoves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikedAndVicove_LikedId",
                table: "LikedAndVicove",
                column: "LikedId");
        }
    }
}
