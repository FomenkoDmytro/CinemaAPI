using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpicVision.Infrastructure_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDurationUnitTableInContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_DurationUnit_DurationUnitId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DurationUnit",
                table: "DurationUnit");

            migrationBuilder.RenameTable(
                name: "DurationUnit",
                newName: "DurationUnits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DurationUnits",
                table: "DurationUnits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_DurationUnits_DurationUnitId",
                table: "Movies",
                column: "DurationUnitId",
                principalTable: "DurationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_DurationUnits_DurationUnitId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DurationUnits",
                table: "DurationUnits");

            migrationBuilder.RenameTable(
                name: "DurationUnits",
                newName: "DurationUnit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DurationUnit",
                table: "DurationUnit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_DurationUnit_DurationUnitId",
                table: "Movies",
                column: "DurationUnitId",
                principalTable: "DurationUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
