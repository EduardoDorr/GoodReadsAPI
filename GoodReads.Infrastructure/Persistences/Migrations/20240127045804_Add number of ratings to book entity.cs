using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodReads.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addnumberofratingstobookentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfRatings",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRatings",
                table: "Books");
        }
    }
}
