using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoCast.App.Migrations
{
    /// <inheritdoc />
    public partial class servicerequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "ServiceRequests",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ServiceRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "ServiceRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "Type",
                table: "ServiceRequests",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ServiceRequests");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ServiceRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}
