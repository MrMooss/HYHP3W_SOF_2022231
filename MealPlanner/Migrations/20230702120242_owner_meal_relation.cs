using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlanner.Migrations
{
    public partial class owner_meal_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "ba971648-3c30-4c8d-8fde-af18fcc2cc44" });

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: "adf7ae93-1041-4ff3-be58-01cf39ae142e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba971648-3c30-4c8d-8fde-af18fcc2cc44");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "f72b9515-2d8d-451c-8894-fc3902416854");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Meals");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Meals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Meals_OwnerId",
                table: "Meals",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_AspNetUsers_OwnerId",
                table: "Meals",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_AspNetUsers_OwnerId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_OwnerId",
                table: "Meals");

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

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Meals");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ba971648-3c30-4c8d-8fde-af18fcc2cc44", 0, "4b97daea-1bc9-446d-b6be-ca370a6e3c8e", "test@test.com", true, false, null, null, "TEST@TEST.COM", "AQAAAAEAACcQAAAAEJ0RLCnybnERwNION2/aUD0OU3cngWdAzACNRHJLiarckAttGZH0/lSJ2haVmM7d7A==", null, false, "ba971648-3c30-4c8d-8fde-af18fcc2cc44_test@test.com", "de2f0e06-9dd4-4daf-a961-4606dfb0de06", false, "test@test.com" });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "ConsumptionDate", "Description", "Email", "ImageUrl", "MealType", "Name" },
                values: new object[] { "f72b9515-2d8d-451c-8894-fc3902416854", new DateTime(2023, 6, 1, 7, 22, 16, 0, DateTimeKind.Unspecified), "Nagyon teszt", "test@test.com", "f72b9515-2d8d-451c-8894-fc3902416854_Test Meal", 0, "Test Meal" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "ba971648-3c30-4c8d-8fde-af18fcc2cc44" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "MealId", "Name" },
                values: new object[] { "adf7ae93-1041-4ff3-be58-01cf39ae142e", "Teszt recept leírása", "f72b9515-2d8d-451c-8894-fc3902416854", "Test Recipe" });
        }
    }
}
