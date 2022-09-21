using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsSystem_iThome.Migrations
{
    public partial class SetEventsNEventsInfoRelationFluentAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventsInfoOfEventsId",
                table: "EventsInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EventsInfo_EventsInfoOfEventsId",
                table: "EventsInfo",
                column: "EventsInfoOfEventsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsInfo_Events_EventsInfoOfEventsId",
                table: "EventsInfo",
                column: "EventsInfoOfEventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsInfo_Events_EventsInfoOfEventsId",
                table: "EventsInfo");

            migrationBuilder.DropIndex(
                name: "IX_EventsInfo_EventsInfoOfEventsId",
                table: "EventsInfo");

            migrationBuilder.DropColumn(
                name: "EventsInfoOfEventsId",
                table: "EventsInfo");
        }
    }
}
