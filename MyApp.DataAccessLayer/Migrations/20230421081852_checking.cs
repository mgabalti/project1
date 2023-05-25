using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class checking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogPostId",
                table: "PostCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "postimageurl",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_BlogPostId",
                table: "PostCategories",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategories_BlogPost_BlogPostId",
                table: "PostCategories",
                column: "BlogPostId",
                principalTable: "BlogPost",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategories_BlogPost_BlogPostId",
                table: "PostCategories");

            migrationBuilder.DropIndex(
                name: "IX_PostCategories_BlogPostId",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "BlogPostId",
                table: "PostCategories");

            migrationBuilder.AlterColumn<string>(
                name: "postimageurl",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
