using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateJobFinder.Migrations
{
    /// <inheritdoc />
    public partial class AddedJobpostingUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "JobPosting",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "JobPosting");
        }
    }
}
