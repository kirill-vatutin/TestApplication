using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    price = table.Column<int>(type: "integer", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_items_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { new Guid("025814bb-38b5-4880-aa1d-6596e4ac8c77"), "Свежие мясные продукты: говядина, свинина, птица", "Мясные изделия" },
                    { new Guid("18bcbd45-eff1-4118-83ac-0749aac10df6"), "Разнообразные овощи для вашего стола", "Овощи" },
                    { new Guid("2ba89c24-3911-4ed5-82f7-dfa703ed983e"), "Безалкогольные и алкогольные напитки различных брендов", "Напитки" },
                    { new Guid("3da06e0f-e9af-4a20-aa2f-0faa4494ec92"), "Шоколад, печенье, торты и сладости", "Кондитерские изделия" },
                    { new Guid("46eb7cf3-0ab6-409d-a5ce-c64c9740ea8f"), "Продукты для вегетарианцев и людей с особыми диетами", "Здоровое питание" },
                    { new Guid("4792b989-8bed-474e-9bf0-141ebb64a8ee"), "Крупы, макароны, консервированные продукты", "Бакалея" },
                    { new Guid("9f3bbe21-2c17-4b79-930a-5338b0003e75"), "Товары для дома: моющие средства, упаковка и прочее", "Хозяйственные товары" },
                    { new Guid("ade1ec60-4480-4b29-8651-bac031a71d72"), "Замороженные овощи, фрукты и готовые блюда", "Замороженные продукты" },
                    { new Guid("cd369604-f1e7-4878-abab-b6b23dc7e927"), "Молоко, сыр, йогурты и другие молочные изделия", "Молочные продукты" },
                    { new Guid("fa212a60-0318-4a01-b1a4-88a1eaa07410"), "Свежие фрукты всех видов", "Фрукты" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_items_category_id",
                table: "items",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
