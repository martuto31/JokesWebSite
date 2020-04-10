namespace AspNetCoreTemplate.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ManyToManyDbVicLiked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedIdentities_Vicoves_VicoveId",
                table: "LikedIdentities");

            migrationBuilder.DropIndex(
                name: "IX_LikedIdentities_VicoveId",
                table: "LikedIdentities");

            migrationBuilder.DropColumn(
                name: "VicoveId",
                table: "LikedIdentities");

            migrationBuilder.CreateTable(
                name: "LikedAndVicove",
                columns: table => new
                {
                    VicId = table.Column<int>(nullable: false),
                    LikedId = table.Column<int>(nullable: false),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedAndVicove");

            migrationBuilder.AddColumn<int>(
                name: "VicoveId",
                table: "LikedIdentities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LikedIdentities_VicoveId",
                table: "LikedIdentities",
                column: "VicoveId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikedIdentities_Vicoves_VicoveId",
                table: "LikedIdentities",
                column: "VicoveId",
                principalTable: "Vicoves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
