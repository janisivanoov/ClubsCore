using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubsCore.Migrations
{
    public partial class ClubsCoreModelsClubsContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "International", "Other" },
                    { 2, "Math", "Academic" },
                    { 3, "Diving", "Sport" },
                    { 4, "Strollers", "Leisure" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali", "Tayari", null },
                    { 2, new DateTime(1963, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dmitry", "Apraksin", null },
                    { 3, new DateTime(2004, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", "Ivanou", null },
                    { 4, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petr", "Petrov", null },
                    { 5, new DateTime(1989, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sidor", "Sidorov", null },
                    { 6, new DateTime(2000, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pambos", "Boss", null },
                    { 7, new DateTime(1998, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christos", "Christou", null },
                    { 8, new DateTime(1999, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Savvas", "Savvou", null }
                });

            migrationBuilder.InsertData(
                table: "StudentClubs",
                columns: new[] { "Id", "ClubId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 3 },
                    { 10, 4, 3 },
                    { 5, 3, 4 },
                    { 6, 2, 5 },
                    { 11, 2, 5 },
                    { 7, 1, 6 },
                    { 12, 2, 6 },
                    { 8, 2, 7 },
                    { 13, 1, 7 },
                    { 9, 3, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentClubs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentClubs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentClubs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentClubs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudentClubs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudentClubs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StudentClubs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StudentClubs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StudentClubs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StudentClubs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StudentClubs",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StudentClubs",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "StudentClubs",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
