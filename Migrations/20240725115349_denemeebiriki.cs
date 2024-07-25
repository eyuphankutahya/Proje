using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje.Migrations
{
    public partial class denemeebiriki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GirisModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GirisModel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GirisModel",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { 1, "admin@gmail.com", "Password", "admin" });

            migrationBuilder.InsertData(
                table: "GirisModel",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { 2, "user@gmail.com", "userpassword", "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GirisModel");
        }
    }
}
