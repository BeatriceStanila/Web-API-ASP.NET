using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations.NZWalksAuthDb
{
    /// <inheritdoc />
    public partial class Alteridentityrolenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a6fed20-e457-43ae-bdbb-698a092d3c8a",
                column: "Name",
                value: "Writer");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bca0745f-ba35-4fa4-b1ad-124caa375bdd",
                column: "Name",
                value: "Reader");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a6fed20-e457-43ae-bdbb-698a092d3c8a",
                column: "Name",
                value: "1a6fed20-e457-43ae-bdbb-698a092d3c8a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bca0745f-ba35-4fa4-b1ad-124caa375bdd",
                column: "Name",
                value: "bca0745f-ba35-4fa4-b1ad-124caa375bdd");
        }
    }
}
