using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleChallenge.Infra.Migrations
{
    public partial class AddingMountLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MountLikes",
                schema: "dbo",
                table: "article",
                newName: "mount_likes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mount_likes",
                schema: "dbo",
                table: "article",
                newName: "MountLikes");
        }
    }
}
