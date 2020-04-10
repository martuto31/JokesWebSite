namespace AspNetCoreTemplate.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdatedRealtionshipsVicoveAndLikedIdentyties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikedIdentyties",
                table: "Vicoves");

            migrationBuilder.CreateTable(
                name: "LikedIdentities",
                columns: table => new
                {
                    IdentityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikedIdentity = table.Column<string>(nullable: true),
                    VicoveId = table.Column<int>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedIdentities", x => x.IdentityId);
                    table.ForeignKey(
                        name: "FK_LikedIdentities_Vicoves_VicoveId",
                        column: x => x.VicoveId,
                        principalTable: "Vicoves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikedIdentities_VicoveId",
                table: "LikedIdentities",
                column: "VicoveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedIdentities");

            migrationBuilder.AddColumn<string>(
                name: "LikedIdentyties",
                table: "Vicoves",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
