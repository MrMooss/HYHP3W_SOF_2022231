using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlanner.Data.Migrations
{
    public partial class seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "NormalUser", "NORMALUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "323b36d2-ede2-4c14-8d6e-19b5c2eb5516", 0, "d6c47f8c-da63-4188-9195-9968a10081d3", "SiteUser", "test@test.com", true, false, null, null, "TESTUSER", "AQAAAAEAACcQAAAAEKgzLbvY/knWql5DXGcvjPKXYvWj9Eh9Dkt8tG08HK023K2RVl+otMLCsyAOuRAdrA==", null, false, "323b36d2-ede2-4c14-8d6e-19b5c2eb5516_testuser", "160ec5f7-455b-4392-ad54-795eb11b484b", false, "testuser" });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "ConsumptionDate", "Description", "ImageUrl", "MealType", "Name" },
                values: new object[] { "a3969a54-99f4-4dca-a725-fbd91c7c61b6", new DateTime(2023, 6, 1, 7, 22, 16, 0, DateTimeKind.Unspecified), "Nagyon teszt", "a3969a54-99f4-4dca-a725-fbd91c7c61b6_Test Meal", 0, "Test Meal" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "MealId", "Name" },
                values: new object[] { "d270f8f3-3c6e-4dba-b8bc-5744410617db", "Teszt recept leírása", "a3969a54-99f4-4dca-a725-fbd91c7c61b6", "Test Recipe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "323b36d2-ede2-4c14-8d6e-19b5c2eb5516");

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: "d270f8f3-3c6e-4dba-b8bc-5744410617db");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "a3969a54-99f4-4dca-a725-fbd91c7c61b6");
        }
    }
}
