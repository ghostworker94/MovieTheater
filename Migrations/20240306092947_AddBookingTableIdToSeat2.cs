using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheaterBlazor.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingTableIdToSeat2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_BookingTable_BookingTableId",
                table: "Seat");

            migrationBuilder.AlterColumn<int>(
                name: "BookingTableId",
                table: "Seat",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_BookingTable_BookingTableId",
                table: "Seat",
                column: "BookingTableId",
                principalTable: "BookingTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_BookingTable_BookingTableId",
                table: "Seat");

            migrationBuilder.AlterColumn<int>(
                name: "BookingTableId",
                table: "Seat",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_BookingTable_BookingTableId",
                table: "Seat",
                column: "BookingTableId",
                principalTable: "BookingTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
