using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieLab24.Migrations
{
    public partial class InitialMovieMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Genre = table.Column<string>(maxLength: 20, nullable: true),
                    Year = table.Column<string>(nullable: true),
                    Actors = table.Column<string>(nullable: true),
                    Directors = table.Column<string>(nullable: true),
                    Runtime = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Actors", "Directors", "Genre", "Runtime", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Sacha Baron Cohen", "Larry Charles", "Comedy", 84.0, "Borat", "2006" },
                    { 3, "John Cleese", "Terry Gilliam, Terry Jones", "Comedy", 92.0, "Monty Python and the Holy Grail", "1975" },
                    { 4, "Reese Witherspoon", "Robert Luketic", "Comedy", 96.0, "Legally Blonde", "2001" },
                    { 6, "Ansel Elgort, Kevin Spacey", "Edgar Wright", "Action", 113.0, "Baby Driver", "2017" },
                    { 7, "Robert Downey Jr, Chris Evans", "Joss Whedon", "Action", 143.0, "The Avengers", "2012" },
                    { 8, "John Travolta, Samuel Jackson, Uma Thurman", "Quentin Tarantino", "Action", 154.0, "Pulp Fiction", "1994" },
                    { 9, "Judith O'Dea, Duane Jones", "George Romero", "Horror", 96.0, "Night of the Living Dead", "1968" },
                    { 10, "Jodie Foster, Anthony Hopkins", "Jonathan Demme", "Horror", 118.0, "Silence of the Lambs", "1991" },
                    { 11, "Essie Davis, Noah Wiseman", "Jennifer Kent", "Horror", 94.0, "The Babadook", "2014" },
                    { 12, "Kevin Spacey, Annette Bening", "Sam Mendes", "Drama", 122.0, "American Beauty", "1996" },
                    { 13, "Tom Hanks", "Robert Zemeckis", "Drama", 142.0, "Forrest Gump", "1994" },
                    { 14, "Dev Patel, Freida Pinto", "Danny Boyle", "Drama", 120.0, "Slumdog Millionaire", "2008" },
                    { 15, "Chris Evans, Song Kang-ho", "Bong Joon-ho", "SciFi", 126.0, "Snowpiercer", "2013" },
                    { 2, "Natalie Portman, Hugo Weaving", "James McTeigue", "SciFi", 133.0, "V for Vendetta", "2006" },
                    { 5, "Charlton Heston", "Richard Fleischer", "SciFi", 97.0, "Soylent Green", "1973" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
