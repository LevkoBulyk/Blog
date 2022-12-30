using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "text",
                table: "ArticleTexts",
                newName: "Text");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTexts_ArticleId",
                table: "ArticleTexts",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleMedias_ArticleId",
                table: "ArticleMedias",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleMedias_Articles_ArticleId",
                table: "ArticleMedias",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTexts_Articles_ArticleId",
                table: "ArticleTexts",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleMedias_Articles_ArticleId",
                table: "ArticleMedias");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTexts_Articles_ArticleId",
                table: "ArticleTexts");

            migrationBuilder.DropIndex(
                name: "IX_ArticleTexts_ArticleId",
                table: "ArticleTexts");

            migrationBuilder.DropIndex(
                name: "IX_ArticleMedias_ArticleId",
                table: "ArticleMedias");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "ArticleTexts",
                newName: "text");
        }
    }
}
