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
                    F_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    L_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emergency_Contact_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emergency_Contact_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Staff_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Student_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Membership_Start = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Membership_End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Payment = table.Column<bool>(type: "bit", nullable: true)
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
                    F_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    L_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emergency_Contact_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emergency_Contact_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    CoursePaper_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    User_Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Has_Client = table.Column<bool>(type: "bit", nullable: false),
                    Has_CoursePaper = table.Column<bool>(type: "bit", nullable: false),
                    ClientID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CoursePaperID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.LoginID);
                    table.ForeignKey(
                        name: "FK_Logins_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Logins_CoursePapers_CoursePaperID",
                        column: x => x.CoursePaperID,
                        principalTable: "CoursePapers",
                        principalColumn: "CoursePaperID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Logins_ClientID",
                table: "Logins",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_CoursePaperID",
                table: "Logins",
                column: "CoursePaperID");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserID",
                table: "Logins",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "CoursePapers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
