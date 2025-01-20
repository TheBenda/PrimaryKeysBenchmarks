using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PKS.Benchmarks.Migrations.Migrations.SqlServerMigrations
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombinedTables", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "IntTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UlidBinaryTables",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlidBinaryTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UlidStringTables",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlidStringTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UuidV4Tables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UuidV4Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UuidV7BinaryTables",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UuidV7BinaryTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UuidV7Tables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UuidV7Tables", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CombinedPerson_CreatedOn",
                table: "CombinedTables",
                column: "CreatedOn")
                .Annotation("SqlServer:Clustered", true);
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
                name: "UuidV7BinaryTables");

            migrationBuilder.DropTable(
                name: "UuidV7Tables");
        }
    }
}
