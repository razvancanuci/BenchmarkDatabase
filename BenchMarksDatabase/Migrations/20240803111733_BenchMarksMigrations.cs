using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BenchMarksDatabase.Migrations
{
    /// <inheritdoc />
    public partial class BenchMarksMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableGuid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableGuid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableInt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableInt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableUlid",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableUlid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableUlidBinary",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableUlidBinary", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableGuid");

            migrationBuilder.DropTable(
                name: "TableInt");

            migrationBuilder.DropTable(
                name: "TableUlid");

            migrationBuilder.DropTable(
                name: "TableUlidBinary");
        }
    }
}
