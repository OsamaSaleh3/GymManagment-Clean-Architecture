using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Admins",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("2150e333-8fdc-42a3-9474-1a3956d46de8"),
                column: "UserId",
                value: new Guid("3350e333-8fdc-42a3-9474-1a3956d46de8"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Admins");
        }
    }
}
