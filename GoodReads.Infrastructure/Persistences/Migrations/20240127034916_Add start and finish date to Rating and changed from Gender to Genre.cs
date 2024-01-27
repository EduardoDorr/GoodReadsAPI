using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodReads.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddstartandfinishdatetoRatingandchangedfromGendertoGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Books",
                newName: "Genre");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "Ratings",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Ratings",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Books",
                newName: "Gender");
        }
    }
}
