using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheaterBlazor.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingTableIdToSeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingTable_User_UserId",
                table: "BookingTable");

            migrationBuilder.RenameColumn(
                name: "Seatnumber",
                table: "BookingTable",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "BookingTableId",
                table: "Seat",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BookingTable",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "BookingTable",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_BookingTableId",
                table: "Seat",
                column: "BookingTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTable_User_UserId",
                table: "BookingTable",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_BookingTable_BookingTableId",
                table: "Seat",
                column: "BookingTableId",
                principalTable: "BookingTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingTable_User_UserId",
                table: "BookingTable");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_BookingTable_BookingTableId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Seat_BookingTableId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "BookingTableId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "BookingTable");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "BookingTable",
                newName: "Seatnumber");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BookingTable",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTable_User_UserId",
                table: "BookingTable",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
