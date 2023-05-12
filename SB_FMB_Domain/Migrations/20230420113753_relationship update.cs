using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SB_FMB_Domain.Migrations
{
    public partial class relationshipupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ThaliStopRequests_ThaliId",
                table: "ThaliStopRequests",
                column: "ThaliId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThaliStopRequests_Thalis_ThaliId",
                table: "ThaliStopRequests",
                column: "ThaliId",
                principalTable: "Thalis",
                principalColumn: "ThaliId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThaliStopRequests_Thalis_ThaliId",
                table: "ThaliStopRequests");

            migrationBuilder.DropIndex(
                name: "IX_ThaliStopRequests_ThaliId",
                table: "ThaliStopRequests");
        }
    }
}
