using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpicVision.Infrastructure_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddShortNameAndFullNameInDurationUnitTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DurationUnits",
                newName: "ShortName");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "DurationUnits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "DurationUnits");

            migrationBuilder.RenameColumn(
                name: "ShortName",
                table: "DurationUnits",
                newName: "Name");
        }
    }
}
