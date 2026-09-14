using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingCenter.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    FullName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Specialization = table.Column<string>(type: "varchar(50)", nullable: false),
                    Bio = table.Column<string>(type: "varchar(500)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingTracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingTracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingTracks_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollmets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProgressPercentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TrainingTrackId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollmets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollmets_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollmets_TrainingTracks_TrainingTrackId",
                        column: x => x.TrainingTrackId,
                        principalTable: "TrainingTracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EnrollId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Enrollmets_EnrollId",
                        column: x => x.EnrollId,
                        principalTable: "Enrollmets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Bio", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "FullName", "IsActive", "IsDeleted", "Specialization", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "Senior .NET Backend Instructor", new DateTime(2026, 9, 14, 2, 26, 2, 532, DateTimeKind.Utc).AddTicks(8694), null, null, null, "ahmed.hassan@example.com", "Ahmed Hassan", true, false, ".NET Backend", null, null },
                    { 2, "Angular Instructor", new DateTime(2026, 9, 14, 2, 26, 2, 532, DateTimeKind.Utc).AddTicks(8697), null, null, null, "sara@example.com", "Sara Mohamed", true, false, "Angular", null, null },
                    { 3, "Database Instructor", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "omar.instructor@example.com", "Omar Hassan", true, false, "SQL Server", null, null },
                    { 4, "C# Instructor", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "mariam.instructor@example.com", "Mariam Ali", true, false, "C#", null, null },
                    { 5, "Software Engineering Instructor", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "khaled.instructor@example.com", "Khaled Mostafa", true, false, "Software Engineering", null, null },
                    { 6, "Web Development Instructor", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "nour.instructor@example.com", "Nour Ahmed", true, false, "Web Development", null, null },
                    { 7, "ASP.NET Core API Instructor", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "yara.instructor@example.com", "Yara Mohamed", true, false, "APIs", null, null }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "FullName", "IsActive", "IsDeleted", "PhoneNumber", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 14, 2, 26, 2, 532, DateTimeKind.Utc).AddTicks(8505), null, null, null, "ahmed@example.com", "Ahmed Farag", true, false, "01000000000", null, null },
                    { 2, new DateTime(2026, 9, 14, 2, 26, 2, 532, DateTimeKind.Utc).AddTicks(8508), null, null, null, "mohamed@example.com", "Mohamed Ali", true, false, "01100000000", null, null },
                    { 3, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "omar@example.com", "Omar Khaled", true, false, "01200000000", null, null },
                    { 4, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "youssef@example.com", "Youssef Ahmed", true, false, "01011111111", null, null },
                    { 5, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "mahmoud@example.com", "Mahmoud Hassan", true, false, "01122222222", null, null },
                    { 6, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "mostafa@example.com", "Mostafa Adel", true, false, "01233333333", null, null },
                    { 7, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "karim@example.com", "Karim Samir", true, false, "01044444444", null, null }
                });

            migrationBuilder.InsertData(
                table: "TrainingTracks",
                columns: new[] { "Id", "Capacity", "Code", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "EndDate", "InstructorId", "IsDeleted", "Level", "StartDate", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 30, "DOTNET-BACKEND", new DateTime(2026, 9, 14, 2, 26, 2, 532, DateTimeKind.Utc).AddTicks(8738), null, null, null, "Backend development using ASP.NET Core", new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "Intermediate", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upcoming", "ASP.NET Core Backend", null, null },
                    { 2, 25, "ANGULAR-FE", new DateTime(2026, 9, 14, 2, 26, 2, 532, DateTimeKind.Utc).AddTicks(8741), null, null, null, "Frontend development using Angular", new DateTime(2027, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "Intermediate", new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upcoming", "Angular Frontend", null, null },
                    { 3, 30, "SQL-FUNDAMENTALS", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Database development using SQL Server", new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "Beginner", new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upcoming", "SQL Server Fundamentals", null, null },
                    { 4, 20, "CSHARP-ADVANCED", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Advanced C# programming concepts", new DateTime(2027, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false, "Advanced", new DateTime(2026, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upcoming", "Advanced C#", null, null },
                    { 5, 25, "SOFTWARE-ENG", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Software engineering principles and practices", new DateTime(2027, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, false, "Intermediate", new DateTime(2026, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upcoming", "Software Engineering", null, null },
                    { 6, 35, "WEB-DEVELOPMENT", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Modern web development fundamentals", new DateTime(2027, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, false, "Beginner", new DateTime(2026, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upcoming", "Web Development", null, null },
                    { 7, 25, "ASP-NET-APIS", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Building RESTful APIs using ASP.NET Core", new DateTime(2027, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, false, "Advanced", new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upcoming", "ASP.NET Core APIs", null, null }
                });

            migrationBuilder.InsertData(
                table: "Enrollmets",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EnrollmentDate", "FinalResult", "IsDeleted", "ProgressPercentage", "Status", "StudentId", "TrainingTrackId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 14, 2, 26, 2, 532, DateTimeKind.Utc).AddTicks(8843), null, null, null, new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 25m, "Active", 1, 1, null, null },
                    { 2, new DateTime(2026, 9, 14, 2, 26, 2, 532, DateTimeKind.Utc).AddTicks(8845), null, null, null, new DateTime(2026, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 10m, "Active", 2, 1, null, null },
                    { 3, new DateTime(2026, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2026, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 15m, "Active", 3, 2, null, null },
                    { 4, new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5m, "Active", 4, 3, null, null },
                    { 5, new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0m, "Active", 5, 4, null, null },
                    { 6, new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 10m, "Active", 6, 5, null, null },
                    { 7, new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 20m, "Active", 7, 6, null, null }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EnrollId", "IsDeleted", "Notes", "PaymentDate", "PaymentMethod", "ReferenceNumber", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 5000m, new DateTime(2026, 9, 14, 2, 26, 2, 532, DateTimeKind.Utc).AddTicks(8914), null, null, null, 1, false, "First payment", new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", new Guid("11111111-1111-1111-1111-111111111111"), "Paid", null, null },
                    { 2, 3000m, new DateTime(2026, 9, 14, 2, 26, 2, 532, DateTimeKind.Utc).AddTicks(8930), null, null, null, 1, false, "Second payment", new DateTime(2026, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visa", new Guid("22222222-2222-2222-2222-222222222222"), "Paid", null, null },
                    { 3, 4000m, new DateTime(2026, 9, 14, 2, 26, 2, 532, DateTimeKind.Utc).AddTicks(8934), null, null, null, 2, false, "First payment", new DateTime(2026, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankTransfer", new Guid("33333333-3333-3333-3333-333333333333"), "Paid", null, null },
                    { 4, 2500m, new DateTime(2026, 9, 14, 2, 26, 2, 532, DateTimeKind.Utc).AddTicks(8937), null, null, null, 3, false, "First payment", new DateTime(2026, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "InstaPay", new Guid("44444444-4444-4444-4444-444444444444"), "Paid", null, null },
                    { 5, 3000m, new DateTime(2026, 9, 14, 2, 26, 2, 532, DateTimeKind.Utc).AddTicks(8950), null, null, null, 4, false, "First payment", new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visa", new Guid("55555555-5555-5555-5555-555555555555"), "Paid", null, null },
                    { 6, 2000m, new DateTime(2026, 9, 14, 2, 26, 2, 532, DateTimeKind.Utc).AddTicks(8954), null, null, null, 5, false, "Payment pending", new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", new Guid("66666666-6666-6666-6666-666666666666"), "Pending", null, null },
                    { 7, 3500m, new DateTime(2026, 9, 14, 2, 26, 2, 532, DateTimeKind.Utc).AddTicks(8957), null, null, null, 6, false, "First payment", new DateTime(2026, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mastercard", new Guid("77777777-7777-7777-7777-777777777777"), "Paid", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollmets_StudentId_TrainingTrackId",
                table: "Enrollmets",
                columns: new[] { "StudentId", "TrainingTrackId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollmets_TrainingTrackId",
                table: "Enrollmets",
                column: "TrainingTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Email",
                table: "Instructors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_EnrollId",
                table: "Payments",
                column: "EnrollId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Email",
                table: "Students",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTracks_Code",
                table: "TrainingTracks",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTracks_InstructorId",
                table: "TrainingTracks",
                column: "InstructorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Enrollmets");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TrainingTracks");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
