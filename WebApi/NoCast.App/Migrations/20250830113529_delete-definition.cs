using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoCast.App.Migrations
{
    /// <inheritdoc />
    public partial class deletedefinition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceExecution_AspNetUsers_ApplicationUserId",
                table: "ServiceExecution");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceExecution_ServiceRequest_ServiceRequestId",
                table: "ServiceExecution");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequest_AspNetUsers_ApplicationUserId",
                table: "ServiceRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransaction_Wallets_WalletId",
                table: "WalletTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletTransaction",
                table: "WalletTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceRequest",
                table: "ServiceRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceExecution",
                table: "ServiceExecution");

            migrationBuilder.DropColumn(
                name: "ServiceDefinitionId",
                table: "ServiceRequest");

            migrationBuilder.RenameTable(
                name: "WalletTransaction",
                newName: "WalletTransactions");

            migrationBuilder.RenameTable(
                name: "ServiceRequest",
                newName: "ServiceRequests");

            migrationBuilder.RenameTable(
                name: "ServiceExecution",
                newName: "ServiceExecutions");

            migrationBuilder.RenameIndex(
                name: "IX_WalletTransaction_WalletId",
                table: "WalletTransactions",
                newName: "IX_WalletTransactions_WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceRequest_ApplicationUserId",
                table: "ServiceRequests",
                newName: "IX_ServiceRequests_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceExecution_ServiceRequestId",
                table: "ServiceExecutions",
                newName: "IX_ServiceExecutions_ServiceRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceExecution_ApplicationUserId",
                table: "ServiceExecutions",
                newName: "IX_ServiceExecutions_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ServiceRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ServiceRequests",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ServiceRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletTransactions",
                table: "WalletTransactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceRequests",
                table: "ServiceRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceExecutions",
                table: "ServiceExecutions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AIContentRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prompt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIContentRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentGatewayLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GatewayRefId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentGatewayLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Platform = table.Column<int>(type: "int", nullable: false),
                    ProfileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialAccounts", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceExecutions_AspNetUsers_ApplicationUserId",
                table: "ServiceExecutions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceExecutions_ServiceRequests_ServiceRequestId",
                table: "ServiceExecutions",
                column: "ServiceRequestId",
                principalTable: "ServiceRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_AspNetUsers_ApplicationUserId",
                table: "ServiceRequests",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransactions_Wallets_WalletId",
                table: "WalletTransactions",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceExecutions_AspNetUsers_ApplicationUserId",
                table: "ServiceExecutions");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceExecutions_ServiceRequests_ServiceRequestId",
                table: "ServiceExecutions");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_AspNetUsers_ApplicationUserId",
                table: "ServiceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransactions_Wallets_WalletId",
                table: "WalletTransactions");

            migrationBuilder.DropTable(
                name: "AIContentRequests");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PaymentGatewayLogs");

            migrationBuilder.DropTable(
                name: "SocialAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletTransactions",
                table: "WalletTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceRequests",
                table: "ServiceRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceExecutions",
                table: "ServiceExecutions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ServiceRequests");

            migrationBuilder.RenameTable(
                name: "WalletTransactions",
                newName: "WalletTransaction");

            migrationBuilder.RenameTable(
                name: "ServiceRequests",
                newName: "ServiceRequest");

            migrationBuilder.RenameTable(
                name: "ServiceExecutions",
                newName: "ServiceExecution");

            migrationBuilder.RenameIndex(
                name: "IX_WalletTransactions_WalletId",
                table: "WalletTransaction",
                newName: "IX_WalletTransaction_WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceRequests_ApplicationUserId",
                table: "ServiceRequest",
                newName: "IX_ServiceRequest_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceExecutions_ServiceRequestId",
                table: "ServiceExecution",
                newName: "IX_ServiceExecution_ServiceRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceExecutions_ApplicationUserId",
                table: "ServiceExecution",
                newName: "IX_ServiceExecution_ApplicationUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceDefinitionId",
                table: "ServiceRequest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletTransaction",
                table: "WalletTransaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceRequest",
                table: "ServiceRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceExecution",
                table: "ServiceExecution",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceExecution_AspNetUsers_ApplicationUserId",
                table: "ServiceExecution",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceExecution_ServiceRequest_ServiceRequestId",
                table: "ServiceExecution",
                column: "ServiceRequestId",
                principalTable: "ServiceRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequest_AspNetUsers_ApplicationUserId",
                table: "ServiceRequest",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransaction_Wallets_WalletId",
                table: "WalletTransaction",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
