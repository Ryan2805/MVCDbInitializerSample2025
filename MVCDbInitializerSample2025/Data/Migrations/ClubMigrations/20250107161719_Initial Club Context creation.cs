using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCDbInitializerSample2025.Data.Migrations.ClubMigrations
{
    /// <inheritdoc />
    public partial class InitialClubContextcreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false),
                    adminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "ClubEvent",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubEvent", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_ClubEvent_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssociatedClub = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    approved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Member_Club_AssociatedClub",
                        column: x => x.AssociatedClub,
                        principalTable: "Club",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Member_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventAttendances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    AttendeeMember = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAttendances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventAttendances_ClubEvent_EventID",
                        column: x => x.EventID,
                        principalTable: "ClubEvent",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventAttendances_Member_AttendeeMember",
                        column: x => x.AttendeeMember,
                        principalTable: "Member",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubEvent_ClubId",
                table: "ClubEvent",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendances_AttendeeMember",
                table: "EventAttendances",
                column: "AttendeeMember");

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendances_EventID",
                table: "EventAttendances",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_AssociatedClub",
                table: "Member",
                column: "AssociatedClub");

            migrationBuilder.CreateIndex(
                name: "IX_Member_StudentID",
                table: "Member",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventAttendances");

            migrationBuilder.DropTable(
                name: "ClubEvent");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
