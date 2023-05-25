using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class instance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "postInstance",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BlogPostId",
                table: "BlogInstances",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogInstances_BlogPostId",
                table: "BlogInstances",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogInstances_BlogPost_BlogPostId",
                table: "BlogInstances",
                column: "BlogPostId",
                principalTable: "BlogPost",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogInstances_BlogPost_BlogPostId",
                table: "BlogInstances");

            migrationBuilder.DropIndex(
                name: "IX_BlogInstances_BlogPostId",
                table: "BlogInstances");

            migrationBuilder.DropColumn(
                name: "postInstance",
                table: "BlogPost");

            migrationBuilder.DropColumn(
                name: "BlogPostId",
                table: "BlogInstances");
        }
    }
}
