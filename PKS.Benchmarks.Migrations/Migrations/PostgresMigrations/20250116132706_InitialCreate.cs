using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PKS.Benchmarks.Migrations.Migrations.PostgresMigrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CombinedTables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombinedTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UlidBinaryTables",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlidBinaryTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UlidStringTables",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlidStringTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UuidV4Tables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UuidV4Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UuidV7Tables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UuidV7Tables", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CombinedPerson_CreatedOn",
                table: "CombinedTables",
                column: "CreatedOn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CombinedTables");

            migrationBuilder.DropTable(
                name: "IntTables");

            migrationBuilder.DropTable(
                name: "UlidBinaryTables");

            migrationBuilder.DropTable(
                name: "UlidStringTables");

            migrationBuilder.DropTable(
                name: "UuidV4Tables");

            migrationBuilder.DropTable(
                name: "UuidV7Tables");
        }
    }
}
