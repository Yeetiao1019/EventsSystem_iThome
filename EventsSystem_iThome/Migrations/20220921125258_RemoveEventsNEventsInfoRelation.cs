using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsSystem_iThome.Migrations
{
    public partial class RemoveEventsNEventsInfoRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsInfo_Events_EventsId",
                table: "EventsInfo");

            migrationBuilder.DropIndex(
                name: "IX_EventsInfo_EventsId",
                table: "EventsInfo");

            migrationBuilder.DropColumn(
                name: "EventsId",
                table: "EventsInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventsId",
                table: "EventsInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EventsInfo_EventsId",
                table: "EventsInfo",
                column: "EventsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsInfo_Events_EventsId",
                table: "EventsInfo",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
