using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PKS.Benchmarks.Migrations.Migrations.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class UuidV8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UuidV8Tables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UuidV8Tables", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UuidV8Tables");
        }
    }
}
