using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendarApp.Web.Migrations
{
    public partial class EventScheduleParticipationRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowParticipantsRegistration",
                table: "EventSchedule",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "EventParticipant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventScheduleId = table.Column<int>(nullable: false),
                    ParticipantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventParticipant_EventSchedule_EventScheduleId",
                        column: x => x.EventScheduleId,
                        principalTable: "EventSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventParticipant_AppUser_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipant_EventScheduleId",
                table: "EventParticipant",
                column: "EventScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipant_ParticipantId",
                table: "EventParticipant",
                column: "ParticipantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventParticipant");

            migrationBuilder.DropColumn(
                name: "AllowParticipantsRegistration",
                table: "EventSchedule");
        }
    }
}
