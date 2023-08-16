using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPSystem.Migrations
{
    /// <inheritdoc />
    public partial class _1st : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    SaltKey = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

        }
    }
}
