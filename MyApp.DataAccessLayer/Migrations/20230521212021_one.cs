using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class one : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "postIssue",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BlogPostId",
                table: "BlogIssues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogIssues_BlogPostId",
                table: "BlogIssues",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogIssues_BlogPost_BlogPostId",
                table: "BlogIssues",
                column: "BlogPostId",
                principalTable: "BlogPost",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogIssues_BlogPost_BlogPostId",
                table: "BlogIssues");

            migrationBuilder.DropIndex(
                name: "IX_BlogIssues_BlogPostId",
                table: "BlogIssues");

            migrationBuilder.DropColumn(
                name: "postIssue",
                table: "BlogPost");

            migrationBuilder.DropColumn(
                name: "BlogPostId",
                table: "BlogIssues");
        }
    }
}
