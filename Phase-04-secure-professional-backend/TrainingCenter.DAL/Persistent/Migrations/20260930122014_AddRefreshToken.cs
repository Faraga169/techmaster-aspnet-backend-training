using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingCenter.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Enrollmets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "Enrollmets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9333));

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9239));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9418));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9434));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "TrainingTracks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "TrainingTracks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 12, 20, 13, 621, DateTimeKind.Utc).AddTicks(9281));

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "Enrollmets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 4, 40, 35, 163, DateTimeKind.Utc).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "Enrollmets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 4, 40, 35, 163, DateTimeKind.Utc).AddTicks(8404));

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 4, 40, 35, 163, DateTimeKind.Utc).AddTicks(8212));

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 4, 40, 35, 163, DateTimeKind.Utc).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 4, 40, 35, 163, DateTimeKind.Utc).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 4, 40, 35, 163, DateTimeKind.Utc).AddTicks(8493));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 4, 40, 35, 163, DateTimeKind.Utc).AddTicks(8507));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 4, 40, 35, 163, DateTimeKind.Utc).AddTicks(8511));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 4, 40, 35, 163, DateTimeKind.Utc).AddTicks(8514));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 4, 40, 35, 163, DateTimeKind.Utc).AddTicks(8517));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 4, 40, 35, 163, DateTimeKind.Utc).AddTicks(8521));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 4, 40, 35, 163, DateTimeKind.Utc).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 4, 40, 35, 163, DateTimeKind.Utc).AddTicks(8029));

            migrationBuilder.UpdateData(
                table: "TrainingTracks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 4, 40, 35, 163, DateTimeKind.Utc).AddTicks(8339));

            migrationBuilder.UpdateData(
                table: "TrainingTracks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 30, 4, 40, 35, 163, DateTimeKind.Utc).AddTicks(8344));
        }
    }
}
