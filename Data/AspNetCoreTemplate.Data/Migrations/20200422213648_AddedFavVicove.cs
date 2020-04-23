namespace AspNetCoreTemplate.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedFavVicove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavouriteVicoveId",
                table: "VicLikes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FavouriteVicove",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: true),
                    VicType = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    AccountID = table.Column<int>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteVicove", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteVicove_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VicLikes_FavouriteVicoveId",
                table: "VicLikes",
                column: "FavouriteVicoveId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteVicove_AccountID",
                table: "FavouriteVicove",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_VicLikes_FavouriteVicove_FavouriteVicoveId",
                table: "VicLikes",
                column: "FavouriteVicoveId",
                principalTable: "FavouriteVicove",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VicLikes_FavouriteVicove_FavouriteVicoveId",
                table: "VicLikes");

            migrationBuilder.DropTable(
                name: "FavouriteVicove");

            migrationBuilder.DropIndex(
                name: "IX_VicLikes_FavouriteVicoveId",
                table: "VicLikes");

            migrationBuilder.DropColumn(
                name: "FavouriteVicoveId",
                table: "VicLikes");
        }
    }
}
