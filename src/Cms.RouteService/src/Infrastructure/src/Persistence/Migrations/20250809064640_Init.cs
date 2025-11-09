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
                name: "post_route",
                schema: "cms-route-service",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_route", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "topic_route",
                schema: "cms-route-service",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topic_route", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_post_route___path",
                schema: "cms-route-service",
                table: "post_route",
                column: "path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_topic_route___path",
                schema: "cms-route-service",
                table: "topic_route",
                column: "path",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "post_route",
                schema: "cms-route-service");

            migrationBuilder.DropTable(
                name: "topic_route",
                schema: "cms-route-service");
        }
    }
}
