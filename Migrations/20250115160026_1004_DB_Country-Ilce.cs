using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace intro_Address_CRUD_Exam.Migrations
{
    /// <inheritdoc />
    public partial class _1004_DB_CountryIlce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Ilce",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ilce_CountryId",
                table: "Ilce",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ilce_Country_CountryId",
                table: "Ilce",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ilce_Country_CountryId",
                table: "Ilce");

            migrationBuilder.DropIndex(
                name: "IX_Ilce_CountryId",
                table: "Ilce");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Ilce");
        }
    }
}
