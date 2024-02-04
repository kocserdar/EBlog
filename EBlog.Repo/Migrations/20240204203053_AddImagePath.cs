using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EBlog.Repo.Migrations
{
    public partial class AddImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 23, 30, 53, 525, DateTimeKind.Local).AddTicks(7825),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 4, 22, 41, 0, 491, DateTimeKind.Local).AddTicks(9875));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 4, 22, 41, 0, 491, DateTimeKind.Local).AddTicks(9875),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 4, 23, 30, 53, 525, DateTimeKind.Local).AddTicks(7825));
        }
    }
}
