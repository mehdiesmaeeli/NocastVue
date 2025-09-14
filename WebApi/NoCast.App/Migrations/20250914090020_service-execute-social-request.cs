using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoCast.App.Migrations
{
    /// <inheritdoc />
    public partial class serviceexecutesocialrequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceExecutions_AspNetUsers_ApplicationUserId",
                table: "ServiceExecutions");

            migrationBuilder.DropIndex(
                name: "IX_ServiceExecutions_ApplicationUserId",
                table: "ServiceExecutions");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ServiceExecutions");

            migrationBuilder.CreateIndex(
                name: "IX_SocialAccounts_UserId",
                table: "SocialAccounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_TargetSocialAccountId",
                table: "ServiceRequests",
                column: "TargetSocialAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceExecutions_ExecutorUserId",
                table: "ServiceExecutions",
                column: "ExecutorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceExecutions_AspNetUsers_ExecutorUserId",
                table: "ServiceExecutions",
                column: "ExecutorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_SocialAccounts_TargetSocialAccountId",
                table: "ServiceRequests",
                column: "TargetSocialAccountId",
                principalTable: "SocialAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialAccounts_AspNetUsers_UserId",
                table: "SocialAccounts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceExecutions_AspNetUsers_ExecutorUserId",
                table: "ServiceExecutions");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_SocialAccounts_TargetSocialAccountId",
                table: "ServiceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialAccounts_AspNetUsers_UserId",
                table: "SocialAccounts");

            migrationBuilder.DropIndex(
                name: "IX_SocialAccounts_UserId",
                table: "SocialAccounts");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequests_TargetSocialAccountId",
                table: "ServiceRequests");

            migrationBuilder.DropIndex(
                name: "IX_ServiceExecutions_ExecutorUserId",
                table: "ServiceExecutions");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "ServiceExecutions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceExecutions_ApplicationUserId",
                table: "ServiceExecutions",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceExecutions_AspNetUsers_ApplicationUserId",
                table: "ServiceExecutions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
