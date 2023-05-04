using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vira.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RenamePhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MobileNumber",
                table: "Users",
                newName: "LandlineTelephone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LandlineTelephone",
                table: "Users",
                newName: "MobileNumber");
        }
    }
}
