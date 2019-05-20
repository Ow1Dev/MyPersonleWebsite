using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPersonelWebsite.Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTag_Tags_TagId",
                table: "ProjectTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTag",
                table: "ProjectTag");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTag_TagId",
                table: "ProjectTag");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "ProjectTag");

            migrationBuilder.AddColumn<string>(
                name: "NomalizedTag",
                table: "Tags",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomalizedTag",
                table: "ProjectTag",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HTMLPath",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "NomalizedTag");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTag",
                table: "ProjectTag",
                columns: new[] { "ProjectId", "NomalizedTag" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTag_NomalizedTag",
                table: "ProjectTag",
                column: "NomalizedTag");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTag_Tags_NomalizedTag",
                table: "ProjectTag",
                column: "NomalizedTag",
                principalTable: "Tags",
                principalColumn: "NomalizedTag",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTag_Tags_NomalizedTag",
                table: "ProjectTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTag",
                table: "ProjectTag");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTag_NomalizedTag",
                table: "ProjectTag");

            migrationBuilder.DropColumn(
                name: "NomalizedTag",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "NomalizedTag",
                table: "ProjectTag");

            migrationBuilder.DropColumn(
                name: "HTMLPath",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tags",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "ProjectTag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTag",
                table: "ProjectTag",
                columns: new[] { "ProjectId", "TagId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTag_TagId",
                table: "ProjectTag",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTag_Tags_TagId",
                table: "ProjectTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
