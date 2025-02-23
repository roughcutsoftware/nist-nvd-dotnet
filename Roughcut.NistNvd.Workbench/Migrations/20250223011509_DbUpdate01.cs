using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roughcut.NistNvd.Workbench.Migrations
{
    /// <inheritdoc />
    public partial class DbUpdate01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deprecatedby",
                columns: table => new
                {
                    ModelKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelRowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deprecatedby", x => x.ModelKeyId);
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    ModelKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelRowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.ModelKeyId);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    ModelKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Lang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelRowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.ModelKeyId);
                });

            migrationBuilder.CreateTable(
                name: "Deprecation",
                columns: table => new
                {
                    ModelKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeprecatedbyModelKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelRowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deprecation", x => x.ModelKeyId);
                    table.ForeignKey(
                        name: "FK_Deprecation_Deprecatedby_DeprecatedbyModelKeyId",
                        column: x => x.DeprecatedbyModelKeyId,
                        principalTable: "Deprecatedby",
                        principalColumn: "ModelKeyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reference",
                columns: table => new
                {
                    ModelKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferencesModelKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModelRowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.ModelKeyId);
                    table.ForeignKey(
                        name: "FK_Reference_References_ReferencesModelKeyId",
                        column: x => x.ReferencesModelKeyId,
                        principalTable: "References",
                        principalColumn: "ModelKeyId");
                });

            migrationBuilder.CreateTable(
                name: "Cpe23item",
                columns: table => new
                {
                    ModelKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeprecationModelKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModelRowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cpe23item", x => x.ModelKeyId);
                    table.ForeignKey(
                        name: "FK_Cpe23item_Deprecation_DeprecationModelKeyId",
                        column: x => x.DeprecationModelKeyId,
                        principalTable: "Deprecation",
                        principalColumn: "ModelKeyId");
                });

            migrationBuilder.CreateTable(
                name: "CpeItems",
                columns: table => new
                {
                    ModelKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitleModelKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferencesModelKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cpe23itemModelKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deprecated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deprecation_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelRowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpeItems", x => x.ModelKeyId);
                    table.ForeignKey(
                        name: "FK_CpeItems_Cpe23item_Cpe23itemModelKeyId",
                        column: x => x.Cpe23itemModelKeyId,
                        principalTable: "Cpe23item",
                        principalColumn: "ModelKeyId");
                    table.ForeignKey(
                        name: "FK_CpeItems_References_ReferencesModelKeyId",
                        column: x => x.ReferencesModelKeyId,
                        principalTable: "References",
                        principalColumn: "ModelKeyId");
                    table.ForeignKey(
                        name: "FK_CpeItems_Title_TitleModelKeyId",
                        column: x => x.TitleModelKeyId,
                        principalTable: "Title",
                        principalColumn: "ModelKeyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cpe23item_DeprecationModelKeyId",
                table: "Cpe23item",
                column: "DeprecationModelKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_CpeItems_Cpe23itemModelKeyId",
                table: "CpeItems",
                column: "Cpe23itemModelKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_CpeItems_ReferencesModelKeyId",
                table: "CpeItems",
                column: "ReferencesModelKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_CpeItems_TitleModelKeyId",
                table: "CpeItems",
                column: "TitleModelKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Deprecation_DeprecatedbyModelKeyId",
                table: "Deprecation",
                column: "DeprecatedbyModelKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_ReferencesModelKeyId",
                table: "Reference",
                column: "ReferencesModelKeyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CpeItems");

            migrationBuilder.DropTable(
                name: "Reference");

            migrationBuilder.DropTable(
                name: "Cpe23item");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "Deprecation");

            migrationBuilder.DropTable(
                name: "Deprecatedby");
        }
    }
}
