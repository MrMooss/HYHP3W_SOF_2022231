using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlanner.Data.Migrations
{
    public partial class fix : Migration
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

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d5713237-0072-4766-9002-82631a61a3e1", 0, "5e51d0cb-04e7-4d67-a94a-ac7cc36dd3c9", "test@test.com", true, false, null, null, "TESTUSER", "AQAAAAEAACcQAAAAEImdImVL7KPQ4DWju+PhZnc2MGC8+er0IKPsyANkMYJzVrVpAqdS9VOxKt+cbomRXw==", null, false, "d5713237-0072-4766-9002-82631a61a3e1_testuser", "fb70b9fb-876c-428c-a170-a9cae16d9476", false, "testuser" });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "ConsumptionDate", "Description", "ImageUrl", "MealType", "Name" },
                values: new object[] { "8b7d0902-0c26-4bb1-a309-5734de3419b2", new DateTime(2023, 6, 1, 7, 22, 16, 0, DateTimeKind.Unspecified), "Nagyon teszt", "8b7d0902-0c26-4bb1-a309-5734de3419b2_Test Meal", 0, "Test Meal" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "MealId", "Name" },
                values: new object[] { "6b9219a7-aa8a-44c5-84fb-744f2571b782", "Teszt recept leírása", "8b7d0902-0c26-4bb1-a309-5734de3419b2", "Test Recipe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5713237-0072-4766-9002-82631a61a3e1");

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: "6b9219a7-aa8a-44c5-84fb-744f2571b782");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "8b7d0902-0c26-4bb1-a309-5734de3419b2");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
