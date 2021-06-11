using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webtestrevised.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    f_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    l_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emergency_Contact_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emergency_Contact_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    login_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    membership_Start = table.Column<DateTime>(type: "datetime2", nullable: true),
                    membership_End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    payment = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    f_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    l_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emergency_Contact_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emergency_Contact_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    login_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clients_Users_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoursePapers",
                columns: table => new
                {
                    CoursePaperID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePapers", x => x.CoursePaperID);
                    table.ForeignKey(
                        name: "FK_CoursePapers_Users_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    LoginID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.LoginID);
                    table.ForeignKey(
                        name: "FK_Logins_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_StudentID",
                table: "Clients",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePapers_StaffID",
                table: "CoursePapers",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserID",
                table: "Logins",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "CoursePapers");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
