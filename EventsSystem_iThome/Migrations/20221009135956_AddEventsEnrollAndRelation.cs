using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsSystem_iThome.Migrations
{
    public partial class AddEventsEnrollAndRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventsEnroll",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EnrollTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsEnroll", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventsEnroll_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserEventsEnroll",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventsEnrollId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserEventsEnroll", x => new { x.ApplicationUserId, x.EventsEnrollId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserEventsEnroll_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserEventsEnroll_EventsEnroll_EventsEnrollId",
                        column: x => x.EventsEnrollId,
                        principalTable: "EventsEnroll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserEventsEnroll_EventsEnrollId",
                table: "ApplicationUserEventsEnroll",
                column: "EventsEnrollId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsEnroll_EventsId",
                table: "EventsEnroll",
                column: "EventsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserEventsEnroll");

            migrationBuilder.DropTable(
                name: "EventsEnroll");
        }
    }
}
