using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlanner.Migrations
{
    public partial class valami : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "3d201b37-7344-4be7-b792-828786adb6bd" });

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: "ef2627d2-528a-41d6-8d02-cf62ebae4c8a");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "8beeb6ce-114b-4612-9b83-0757f9c296a3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d201b37-7344-4be7-b792-828786adb6bd");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e790b945-69cc-4f29-b7ed-e873b3d956fc", 0, "30203de6-dd94-436e-8ed9-f968a99b0958", "test@test.com", true, false, null, "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAEAACcQAAAAEJU4Lf0KohsO3HbqS+0LeXTloe/6qo935BeQBMu5N8L+zj5tBfb9K1t4bnGudoegzg==", null, false, "https://sofs.blob.core.windows.net/pictures/1f972.png", "a819c192-610a-4e71-8325-513569616efb", false, "test@test.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "e790b945-69cc-4f29-b7ed-e873b3d956fc" });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "ConsumptionDate", "Description", "ImageUrl", "MealType", "Name", "OwnerId" },
                values: new object[] { "2b717072-1663-479f-8e1e-b6a09ca29626", new DateTime(2023, 6, 1, 7, 22, 16, 0, DateTimeKind.Unspecified), "Nagyon teszt", "https://sofs.blob.core.windows.net/pictures/kép_2023-07-02_153831454.png", 0, "Test Meal", "e790b945-69cc-4f29-b7ed-e873b3d956fc" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "MealId", "Name" },
                values: new object[] { "1fc36153-3991-4e8e-8119-fb14a6137dbe", "Teszt recept leírása", "2b717072-1663-479f-8e1e-b6a09ca29626", "Test Recipe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "e790b945-69cc-4f29-b7ed-e873b3d956fc" });

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: "1fc36153-3991-4e8e-8119-fb14a6137dbe");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "2b717072-1663-479f-8e1e-b6a09ca29626");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e790b945-69cc-4f29-b7ed-e873b3d956fc");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3d201b37-7344-4be7-b792-828786adb6bd", 0, "03d814ae-6eff-4c84-9762-33370910c405", "test@test.com", true, false, null, "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAEAACcQAAAAELfvNaYeGrj8jQ9z3DlluXVEPwtTgP+gA7aNK/dTX04ZF8oKANmxn/WwsozIMlI3QQ==", null, false, "https://sofs.blob.core.windows.net/pictures/1f972.png", "9ed7d835-be2a-438c-8e2c-b89e1ca47d24", false, "test@test.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "3d201b37-7344-4be7-b792-828786adb6bd" });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "ConsumptionDate", "Description", "ImageUrl", "MealType", "Name", "OwnerId" },
                values: new object[] { "8beeb6ce-114b-4612-9b83-0757f9c296a3", new DateTime(2023, 6, 1, 7, 22, 16, 0, DateTimeKind.Unspecified), "Nagyon teszt", "https://sofs.blob.core.windows.net/pictures/kép_2023-07-02_153831454.png", 0, "Test Meal", "3d201b37-7344-4be7-b792-828786adb6bd" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "MealId", "Name" },
                values: new object[] { "ef2627d2-528a-41d6-8d02-cf62ebae4c8a", "Teszt recept leírása", "8beeb6ce-114b-4612-9b83-0757f9c296a3", "Test Recipe" });
        }
    }
}
