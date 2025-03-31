using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpicVision.Infrastructure_DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStraightConnectionMoviesAndHallTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HallMovie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HallMovie",
                columns: table => new
                {
                    HallsId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallMovie", x => new { x.HallsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_HallMovie_Halls_HallsId",
                        column: x => x.HallsId,
                        principalTable: "Halls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HallMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HallMovie_MoviesId",
                table: "HallMovie",
                column: "MoviesId");
        }
    }
}
