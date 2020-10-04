using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rovers.Dal.Migrations
{
    public partial class Roversv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rovers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATE_DATE = table.Column<DateTime>(nullable: false),
                    UPDATE_DATE = table.Column<DateTime>(nullable: true),
                    DELETE_DATE = table.Column<DateTime>(nullable: true),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    WAY = table.Column<string>(nullable: true),
                    ROVER_DIRECTIVE = table.Column<string>(nullable: true),
                    IS_ACTIVE = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rovers", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rovers");
        }
    }
}
