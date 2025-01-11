using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace intro_Address_CRUD_Exam.Migrations
{
    /// <inheritdoc />
    public partial class _1002_DB_Create_Edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tanim",
                table: "Ilce",
                newName: "Descp");

            migrationBuilder.RenameColumn(
                name: "SehirId",
                table: "Ilce",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "Tanim",
                table: "Country",
                newName: "Descp");

            migrationBuilder.RenameColumn(
                name: "UlkeId",
                table: "City",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "Tanim",
                table: "City",
                newName: "Descp");

            migrationBuilder.CreateIndex(
                name: "IX_Ilce_CityId",
                table: "Ilce",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_IlceId",
                table: "Address",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_SehirId",
                table: "Address",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UlkeId",
                table: "Address",
                column: "UlkeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_SehirId",
                table: "Address",
                column: "SehirId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Country_UlkeId",
                table: "Address",
                column: "UlkeId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Ilce_IlceId",
                table: "Address",
                column: "IlceId",
                principalTable: "Ilce",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ilce_City_CityId",
                table: "Ilce",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_SehirId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Country_UlkeId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Ilce_IlceId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Ilce_City_CityId",
                table: "Ilce");

            migrationBuilder.DropIndex(
                name: "IX_Ilce_CityId",
                table: "Ilce");

            migrationBuilder.DropIndex(
                name: "IX_City_CountryId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_Address_IlceId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_SehirId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_UlkeId",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Descp",
                table: "Ilce",
                newName: "Tanim");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Ilce",
                newName: "SehirId");

            migrationBuilder.RenameColumn(
                name: "Descp",
                table: "Country",
                newName: "Tanim");

            migrationBuilder.RenameColumn(
                name: "Descp",
                table: "City",
                newName: "Tanim");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "City",
                newName: "UlkeId");
        }
    }
}
