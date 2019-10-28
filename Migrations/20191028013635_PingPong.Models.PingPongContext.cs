using Microsoft.EntityFrameworkCore.Migrations;

namespace PingPong.Migrations
{
    public partial class PingPongModelsPingPongContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Age = table.Column<short>(nullable: false),
                    SkillLevel = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Age", "FirstName", "LastName", "SkillLevel", "email" },
                values: new object[,]
                {
                    { 1, (short)50, "Uncle", "Bob", 3, "bob@gmail.com" },
                    { 2, (short)40, "Jan", "Kirsten", 2, "jan@gmail.com" },
                    { 3, (short)30, "Lil", "Jen", 0, "jen@gmail.com" },
                    { 4, (short)45, "Big", "Ben", 1, "jan@gmail.com" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
