using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESC.AdministrationCore.Infraestrucure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "CitizenMaritalStatus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenMaritalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdDocumentType = table.Column<short>(type: "smallint", nullable: true),
                    DocumentTypeSimmit = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citizens",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    MyDocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Picture = table.Column<byte[]>(type: "image", nullable: true),
                    IdDocumentType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMaritalStatus = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citizens_CitizenMaritalStatus_IdMaritalStatus",
                        column: x => x.IdMaritalStatus,
                        principalSchema: "dbo",
                        principalTable: "CitizenMaritalStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Citizens_DocumentTypes_IdDocumentType",
                        column: x => x.IdDocumentType,
                        principalSchema: "dbo",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "DocumentNumber",
                schema: "dbo",
                table: "Citizens",
                column: "DocumentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_IdDocumentType",
                schema: "dbo",
                table: "Citizens",
                column: "IdDocumentType");

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_IdMaritalStatus",
                schema: "dbo",
                table: "Citizens",
                column: "IdMaritalStatus");

            migrationBuilder.CreateIndex(
                name: "LastName",
                schema: "dbo",
                table: "Citizens",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_Description",
                schema: "dbo",
                table: "DocumentTypes",
                column: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citizens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CitizenMaritalStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DocumentTypes",
                schema: "dbo");
        }
    }
}
