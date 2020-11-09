using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieLab24.Migrations
{
    public partial class ChangeCOM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "CheckedOutMovies",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CheckedOutMovies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "CheckedOutMovies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CheckedOutMovies_MovieID",
                table: "CheckedOutMovies",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckedOutMovies_UserId",
                table: "CheckedOutMovies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckedOutMovies_Movies_MovieID",
                table: "CheckedOutMovies",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckedOutMovies_AspNetUsers_UserId",
                table: "CheckedOutMovies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckedOutMovies_Movies_MovieID",
                table: "CheckedOutMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckedOutMovies_AspNetUsers_UserId",
                table: "CheckedOutMovies");

            migrationBuilder.DropIndex(
                name: "IX_CheckedOutMovies_MovieID",
                table: "CheckedOutMovies");

            migrationBuilder.DropIndex(
                name: "IX_CheckedOutMovies_UserId",
                table: "CheckedOutMovies");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "CheckedOutMovies");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CheckedOutMovies",
                newName: "UserID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "CheckedOutMovies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
