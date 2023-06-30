using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlanner.Data.Migrations
{
    public partial class base_admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "18f96742-7c34-42ab-9fee-8548c6244e38", 0, "f1edefba-aab2-4634-a41a-d19cff514a9b", "SiteUser", "test@test.com", true, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEKzi1/Pxo8JBbtE2N6dC7zXAOEdLxebCIs0HVhuDDmZ5wNgsZGJqRmdnEZ+PcL2s5Q==", null, false, "18f96742-7c34-42ab-9fee-8548c6244e38_test@test.com", "73e4a173-68aa-4725-92ed-877f9953f520", false, "test@test.com" });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "ConsumptionDate", "Description", "ImageUrl", "MealType", "Name" },
                values: new object[] { "1e8226bd-007e-402f-b9e6-1119a32efdde", new DateTime(2023, 6, 1, 7, 22, 16, 0, DateTimeKind.Unspecified), "Nagyon teszt", "1e8226bd-007e-402f-b9e6-1119a32efdde_Test Meal", 0, "Test Meal" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "18f96742-7c34-42ab-9fee-8548c6244e38" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "MealId", "Name" },
                values: new object[] { "b31d6f0c-aca1-487f-aeca-8a03e0370d6c", "Teszt recept leírása", "1e8226bd-007e-402f-b9e6-1119a32efdde", "Test Recipe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "18f96742-7c34-42ab-9fee-8548c6244e38" });

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: "b31d6f0c-aca1-487f-aeca-8a03e0370d6c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18f96742-7c34-42ab-9fee-8548c6244e38");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "1e8226bd-007e-402f-b9e6-1119a32efdde");

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
    }
}
