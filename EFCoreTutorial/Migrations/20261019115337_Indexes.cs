using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreTutorial.Migrations
{
    /// <inheritdoc />
    public partial class Indexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_Id_Age",
                table: "Students",
                columns: new[] { "Id", "Age" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_ID_StudentId",
                table: "StudentProfiles",
                columns: new[] { "StudentId", "Id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_Id_Age",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_StudentProfiles_ID_StudentId",
                table: "StudentProfiles");
        }
    }
}
