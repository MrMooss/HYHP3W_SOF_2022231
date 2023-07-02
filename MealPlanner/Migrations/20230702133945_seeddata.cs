using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlanner.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "f9bfd5ff-3a54-43ea-bce4-2f8d9ffad7cc" });

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: "e1ea4908-1b82-4a99-9f9b-f9f7b72383fb");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "f346bf51-d19f-4869-9340-d84285804fcb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9bfd5ff-3a54-43ea-bce4-2f8d9ffad7cc");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "f9bfd5ff-3a54-43ea-bce4-2f8d9ffad7cc", 0, "1d0f4c8a-7eec-4f49-b846-f3bb05102789", "test@test.com", true, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEKeUvpPCmiVu8e+LpoGogmU/xRlq3OeXmVLEd108t8uie5nWJ4IGk1IrVztEruAeYw==", null, false, "f9bfd5ff-3a54-43ea-bce4-2f8d9ffad7cc_test@test.com", "aaf028c9-7d53-43bf-86b5-c43e90ceef3e", false, "test@test.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "f9bfd5ff-3a54-43ea-bce4-2f8d9ffad7cc" });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "ConsumptionDate", "Description", "ImageUrl", "MealType", "Name", "OwnerId" },
                values: new object[] { "f346bf51-d19f-4869-9340-d84285804fcb", new DateTime(2023, 6, 1, 7, 22, 16, 0, DateTimeKind.Unspecified), "Nagyon teszt", "f346bf51-d19f-4869-9340-d84285804fcb_Test Meal", 0, "Test Meal", "f9bfd5ff-3a54-43ea-bce4-2f8d9ffad7cc" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "MealId", "Name" },
                values: new object[] { "e1ea4908-1b82-4a99-9f9b-f9f7b72383fb", "Teszt recept leírása", "f346bf51-d19f-4869-9340-d84285804fcb", "Test Recipe" });
        }
    }
}
