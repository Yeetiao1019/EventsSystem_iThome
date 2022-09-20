using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsSystem_iThome.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaleTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaleTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProgressTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProgressTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SimpleIntro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventsCategory",
                columns: table => new
                {
                    EventsCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventsCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsCategory", x => x.EventsCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "EventsImageUseType",
                columns: table => new
                {
                    EventsImageUseTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UseTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsImageUseType", x => x.EventsImageUseTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EventsImage",
                columns: table => new
                {
                    EventsImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFileSize = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsImage", x => x.EventsImageId);
                    table.ForeignKey(
                        name: "FK_EventsImage_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventsInfo",
                columns: table => new
                {
                    EventsInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationLimitedQty = table.Column<int>(type: "int", nullable: false),
                    EventsApplicationQty = table.Column<int>(type: "int", nullable: false),
                    PersonalSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullIntro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsInfo", x => x.EventsInfoId);
                    table.ForeignKey(
                        name: "FK_EventsInfo_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventsImage_EventsId",
                table: "EventsImage",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsInfo_EventsId",
                table: "EventsInfo",
                column: "EventsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsCategory");

            migrationBuilder.DropTable(
                name: "EventsImage");

            migrationBuilder.DropTable(
                name: "EventsImageUseType");

            migrationBuilder.DropTable(
                name: "EventsInfo");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
