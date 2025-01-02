using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Publisher = table.Column<string>(maxLength: 255, nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    AuthorLastName = table.Column<string>(maxLength: 255, nullable: false),
                    AuthorFirstName = table.Column<string>(maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
