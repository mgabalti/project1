using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addcollectitonInInstance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogInstances_BlogIssues_BlogIssueId",
                table: "BlogInstances");

            migrationBuilder.DropIndex(
                name: "IX_BlogInstances_BlogIssueId",
                table: "BlogInstances");

            migrationBuilder.AddColumn<int>(
                name: "BlogInstanceInstanceId",
                table: "BlogIssues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogIssues_BlogInstanceInstanceId",
                table: "BlogIssues",
                column: "BlogInstanceInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogIssues_BlogInstances_BlogInstanceInstanceId",
                table: "BlogIssues",
                column: "BlogInstanceInstanceId",
                principalTable: "BlogInstances",
                principalColumn: "InstanceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogIssues_BlogInstances_BlogInstanceInstanceId",
                table: "BlogIssues");

            migrationBuilder.DropIndex(
                name: "IX_BlogIssues_BlogInstanceInstanceId",
                table: "BlogIssues");

            migrationBuilder.DropColumn(
                name: "BlogInstanceInstanceId",
                table: "BlogIssues");

            migrationBuilder.CreateIndex(
                name: "IX_BlogInstances_BlogIssueId",
                table: "BlogInstances",
                column: "BlogIssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogInstances_BlogIssues_BlogIssueId",
                table: "BlogInstances",
                column: "BlogIssueId",
                principalTable: "BlogIssues",
                principalColumn: "IssueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
