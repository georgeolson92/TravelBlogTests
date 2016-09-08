using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace travelblog.Migrations
{
    public partial class AddImagesAndDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Experiences",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Experiences",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Experiences");
        }
    }
}
