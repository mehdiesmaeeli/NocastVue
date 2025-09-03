using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoCast.App.Migrations
{
    /// <inheritdoc />
    public partial class serviceexecuter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "ExecutorSocialAccountId",
                table: "ServiceExecutions");

            migrationBuilder.AddColumn<int>(
                name: "CountDo",
                table: "ServiceRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountDo",
                table: "ServiceRequests");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ServiceRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ExecutorSocialAccountId",
                table: "ServiceExecutions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
