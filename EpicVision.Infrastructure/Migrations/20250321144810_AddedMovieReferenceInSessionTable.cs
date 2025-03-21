using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpicVision.Infrastructure_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedMovieReferenceInSessionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FristName",
                table: "Producers",
                newName: "FirstName");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MovieId",
                table: "Sessions",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Movies_MovieId",
                table: "Sessions",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Movies_MovieId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_MovieId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Producers",
                newName: "FristName");
        }
    }
}
