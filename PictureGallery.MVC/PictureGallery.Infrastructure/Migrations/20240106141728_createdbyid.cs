using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PictureGallery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createdbyid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Pictures",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_CreatedById",
                table: "Pictures",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_AspNetUsers_CreatedById",
                table: "Pictures",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_AspNetUsers_CreatedById",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_CreatedById",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Pictures");

        }
    }
}
