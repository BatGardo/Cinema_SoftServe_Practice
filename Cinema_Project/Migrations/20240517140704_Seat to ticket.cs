using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema_Project.Migrations
{
    /// <inheritdoc />
    public partial class Seattoticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "hall",
                table: "ticket",
                newName: "seat_id");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_seat_id",
                table: "ticket",
                column: "seat_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_seat_seat_id",
                table: "ticket",
                column: "seat_id",
                principalTable: "seat",
                principalColumn: "seat_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_seat_seat_id",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_ticket_seat_id",
                table: "ticket");

            migrationBuilder.RenameColumn(
                name: "seat_id",
                table: "ticket",
                newName: "hall");
        }
    }
}
