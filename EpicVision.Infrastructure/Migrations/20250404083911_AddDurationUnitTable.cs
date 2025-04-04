using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpicVision.Infrastructure_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDurationUnitTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DurationUnit",
                table: "Movies",
                newName: "DurationUnitId");

            migrationBuilder.CreateTable(
                name: "DurationUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DurationUnit", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DurationUnitId",
                table: "Movies",
                column: "DurationUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_DurationUnit_DurationUnitId",
                table: "Movies",
                column: "DurationUnitId",
                principalTable: "DurationUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_DurationUnit_DurationUnitId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "DurationUnit");

            migrationBuilder.DropIndex(
                name: "IX_Movies_DurationUnitId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "DurationUnitId",
                table: "Movies",
                newName: "DurationUnit");
        }
    }
}
