using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drill_01_DbContext___First_Migration.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalRequired = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnrollmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentSummaries_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PaymentSummaries",
                columns: new[] { "Id", "EnrollmentId", "PaymentStatus", "TotalPaid", "TotalRequired" },
                values: new object[,]
                {
                    { 1, 1, "Paid", 10000m, 10000m },
                    { 2, 2, "PartiallyPaid", 4000m, 12000m },
                    { 3, 3, "Pending", 0m, 10000m },
                    { 4, 4, "PartiallyPaid", 7500m, 15000m },
                    { 5, 5, "Paid", 15000m, 15000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSummaries_EnrollmentId",
                table: "PaymentSummaries",
                column: "EnrollmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentSummaries");
        }
    }
}
