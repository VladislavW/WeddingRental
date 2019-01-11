using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _0001_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TerritoryId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Territory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_TerritoryId",
                table: "User",
                column: "TerritoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Territory_TerritoryId",
                table: "User",
                column: "TerritoryId",
                principalTable: "Territory",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Territory_TerritoryId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Territory");

            migrationBuilder.DropIndex(
                name: "IX_User_TerritoryId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TerritoryId",
                table: "User");
        }
    }
}
