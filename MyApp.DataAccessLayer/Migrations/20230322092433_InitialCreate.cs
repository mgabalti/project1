using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_regDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_lastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    user_DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "BlogPost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    posttitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postbodyhtml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postimageurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postpublishdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    postpublish = table.Column<bool>(type: "bit", nullable: false),
                    postauther = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postcategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "BlogPost");

            migrationBuilder.DropTable(
                name: "PostCategories");
        }
    }
}
