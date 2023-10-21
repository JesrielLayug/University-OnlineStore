using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEcommerce.Server.Migrations
{
    public partial class AddingImageData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "ProductImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "ProductImages");
        }
    }
}
