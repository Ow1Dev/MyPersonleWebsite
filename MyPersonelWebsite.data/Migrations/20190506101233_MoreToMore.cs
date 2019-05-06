using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPersonelWebsite.Data.Migrations
{
    public partial class MoreToMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Tags_TagId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TagId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Tags",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ProjectId",
                table: "Tags",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Projects_ProjectId",
                table: "Tags",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Projects_ProjectId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ProjectId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TagId",
                table: "Projects",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Tags_TagId",
                table: "Projects",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
