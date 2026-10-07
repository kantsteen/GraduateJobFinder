using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateJobFinder.Migrations
{
    /// <inheritdoc />
    public partial class AddProgrammingLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPostingProgrammingLanguage",
                columns: table => new
                {
                    JobPostingsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProgrammingLanguagesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostingProgrammingLanguage", x => new { x.JobPostingsId, x.ProgrammingLanguagesId });
                    table.ForeignKey(
                        name: "FK_JobPostingProgrammingLanguage_JobPosting_JobPostingsId",
                        column: x => x.JobPostingsId,
                        principalTable: "JobPosting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobPostingProgrammingLanguage_ProgrammingLanguage_ProgrammingLanguagesId",
                        column: x => x.ProgrammingLanguagesId,
                        principalTable: "ProgrammingLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPostingProgrammingLanguage_ProgrammingLanguagesId",
                table: "JobPostingProgrammingLanguage",
                column: "ProgrammingLanguagesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingLanguage_Name",
                table: "ProgrammingLanguage",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPostingProgrammingLanguage");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguage");
        }
    }
}
