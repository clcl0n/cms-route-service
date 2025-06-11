using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cms.RouteService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cms-route-service");

            migrationBuilder.CreateTable(
                name: "route_prefix",
                schema: "cms-route-service",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    prefix = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_route_prefix", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "post_route",
                schema: "cms-route-service",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    route_prefix_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_route", x => x.id);
                    table.ForeignKey(
                        name: "FK_post_route_route_prefix_route_prefix_id",
                        column: x => x.route_prefix_id,
                        principalSchema: "cms-route-service",
                        principalTable: "route_prefix",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "cms-route-service",
                table: "route_prefix",
                columns: new[] { "id", "prefix" },
                values: new object[] { new Guid("bb8c0612-4601-49e0-b9af-bd5b90593c9f"), "posts" });

            migrationBuilder.CreateIndex(
                name: "IX_post_route_route_prefix_id",
                schema: "cms-route-service",
                table: "post_route",
                column: "route_prefix_id");

            migrationBuilder.CreateIndex(
                name: "IX_route___path",
                schema: "cms-route-service",
                table: "post_route",
                column: "path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_route_prefix___prefix",
                schema: "cms-route-service",
                table: "route_prefix",
                column: "prefix",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "post_route",
                schema: "cms-route-service");

            migrationBuilder.DropTable(
                name: "route_prefix",
                schema: "cms-route-service");
        }
    }
}
