using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace travelblog.Migrations
{
    public partial class RemoveSomePeopleExperienceTableData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "PeopleExperiences",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PeopleExperiences",
                newName: "id");
        }
    }
}
