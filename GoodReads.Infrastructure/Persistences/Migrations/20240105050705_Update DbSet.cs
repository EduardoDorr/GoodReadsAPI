using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodReads.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Book_BookId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_User_UserId",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_User_Email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_UserId",
                table: "Ratings",
                newName: "IX_Ratings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_BookId",
                table: "Ratings",
                newName: "IX_Ratings_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Isbn",
                table: "Books",
                newName: "IX_Books_Isbn");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Books_BookId",
                table: "Ratings",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Books_BookId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "User",
                newName: "IX_User_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_UserId",
                table: "Rating",
                newName: "IX_Rating_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_BookId",
                table: "Rating",
                newName: "IX_Rating_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Isbn",
                table: "Book",
                newName: "IX_Book_Isbn");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Book_BookId",
                table: "Rating",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_User_UserId",
                table: "Rating",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
