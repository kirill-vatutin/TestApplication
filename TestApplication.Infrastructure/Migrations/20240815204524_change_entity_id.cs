using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class change_entity_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_items_categories_category_id",
                table: "items");

            migrationBuilder.DropPrimaryKey(
                name: "pk_items",
                table: "items");

            migrationBuilder.DropPrimaryKey(
                name: "pk_category",
                table: "category");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "items",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "items",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "items",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "count",
                table: "items",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "items",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_time",
                table: "items",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "created_time",
                table: "items",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "items",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "ix_items_category_id",
                table: "items",
                newName: "IX_items_CategoryId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "category",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "category",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "category",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_items",
                table: "items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "Id");

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("229683b2-153f-4736-84e0-8959e6f4acbf"), "Товары для дома: моющие средства, упаковка и прочее", "Хозяйственные товары" },
                    { new Guid("2fdcf39c-8045-4c34-b75b-00ac789f1f32"), "Продукты для вегетарианцев и людей с особыми диетами", "Здоровое питание" },
                    { new Guid("32e43954-c09a-43e0-b645-f830b9b7ae80"), "Замороженные овощи, фрукты и готовые блюда", "Замороженные продукты" },
                    { new Guid("40a6044e-9d25-4c45-864c-e92e323e1749"), "Шоколад, печенье, торты и сладости", "Кондитерские изделия" },
                    { new Guid("5f275912-661e-4c03-8fa4-dc503f8e7a6d"), "Безалкогольные и алкогольные напитки различных брендов", "Напитки" },
                    { new Guid("73c51031-2e4c-4c14-8e3d-d2c10749bc37"), "Молоко, сыр, йогурты и другие молочные изделия", "Молочные продукты" },
                    { new Guid("8e328186-ebd1-48a7-afe7-8c52a3c59707"), "Разнообразные овощи для вашего стола", "Овощи" },
                    { new Guid("9212d152-8963-4061-918a-76e855726282"), "Крупы, макароны, консервированные продукты", "Бакалея" },
                    { new Guid("e0a84c98-896b-4690-b04f-c5db3dfbe238"), "Свежие фрукты всех видов", "Фрукты" },
                    { new Guid("f1345d4c-be75-4ab1-bb8c-d8c78026f409"), "Свежие мясные продукты: говядина, свинина, птица", "Мясные изделия" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_items_category_CategoryId",
                table: "items",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_category_CategoryId",
                table: "items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_items",
                table: "items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("229683b2-153f-4736-84e0-8959e6f4acbf"));

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("2fdcf39c-8045-4c34-b75b-00ac789f1f32"));

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("32e43954-c09a-43e0-b645-f830b9b7ae80"));

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("40a6044e-9d25-4c45-864c-e92e323e1749"));

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("5f275912-661e-4c03-8fa4-dc503f8e7a6d"));

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("73c51031-2e4c-4c14-8e3d-d2c10749bc37"));

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("8e328186-ebd1-48a7-afe7-8c52a3c59707"));

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("9212d152-8963-4061-918a-76e855726282"));

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("e0a84c98-896b-4690-b04f-c5db3dfbe238"));

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "Id",
                keyValue: new Guid("f1345d4c-be75-4ab1-bb8c-d8c78026f409"));

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "items",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "items",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "items",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "items",
                newName: "count");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "items",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "items",
                newName: "updated_time");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "items",
                newName: "created_time");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "items",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_items_CategoryId",
                table: "items",
                newName: "ix_items_category_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "category",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "category",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "category",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_items",
                table: "items",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_category",
                table: "category",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_items_categories_category_id",
                table: "items",
                column: "category_id",
                principalTable: "category",
                principalColumn: "id");
        }
    }
}
