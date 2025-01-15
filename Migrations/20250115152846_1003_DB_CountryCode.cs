using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace intro_Address_CRUD_Exam.Migrations
{
    /// <inheritdoc />
    public partial class _1003_DB_CountryCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Country",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Country");
        }
    }
}
