using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drill_01_DbContext___First_Migration.Migrations
{
    /// <inheritdoc />
    public partial class AddInstructorsAndTracks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Email", "FullName" },
                values: new object[,]
                {
                    { 1, "ahmed.hassan@example.com", "Ahmed Hassan" },
                    { 2, "mohamed.ali@example.com", "Mohamed Ali" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "Description", "InstructorId", "Name" },
                values: new object[,]
                {
                    { 1, "Backend development using ASP.NET Core", 1, "ASP.NET Backend" },
                    { 2, "Frontend development using Angular", 1, "Angular Frontend" },
                    { 3, "Full Stack development using .NET and Angular", 2, "Full Stack .NET" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_InstructorId",
                table: "Tracks",
                column: "InstructorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
