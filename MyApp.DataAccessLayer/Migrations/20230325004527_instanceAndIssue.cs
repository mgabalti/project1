using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class instanceAndIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogIssues",
                columns: table => new
                {
                    IssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogIssues", x => x.IssueId);
                });

            migrationBuilder.CreateTable(
                name: "BlogInstances",
                columns: table => new
                {
                    InstanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstanceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstanceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OccuranceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BlogIssueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogInstances", x => x.InstanceId);
                    table.ForeignKey(
                        name: "FK_BlogInstances_BlogIssues_BlogIssueId",
                        column: x => x.BlogIssueId,
                        principalTable: "BlogIssues",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogInstances_BlogIssueId",
                table: "BlogInstances",
                column: "BlogIssueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogInstances");

            migrationBuilder.DropTable(
                name: "BlogIssues");
        }
    }
}
