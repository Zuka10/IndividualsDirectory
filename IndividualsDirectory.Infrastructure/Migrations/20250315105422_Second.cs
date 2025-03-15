using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IndividualsDirectory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tbilisi" },
                    { 2, "London" },
                    { 3, "Paris" },
                    { 4, "Berlin" },
                    { 5, "Tokyo" },
                    { 6, "New York" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "BirthDate", "CityId", "FirstName", "Gender", "ImagePath", "LastName", "PersonalNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Local), 1, "John", 0, null, "Doe", "12345678910" },
                    { 2, new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Local), 2, "Jane", 0, null, "Shpilman", "12345678911" },
                    { 3, new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Local), 3, "Jack", 0, null, "Nicholson", "12345678912" },
                    { 4, new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Local), 4, "Jill", 0, null, "James", "12345678913" },
                    { 5, new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Local), 5, "James", 0, null, "Jackson", "12345678914" },
                    { 6, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Local), 6, "Jenny", 0, null, "Smith", "12345678915" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "Number", "NumberType", "PersonId" },
                values: new object[,]
                {
                    { 1, "555-555-555", 0, 1 },
                    { 2, "555-555-556", 0, 2 },
                    { 3, "555-555-557", 0, 3 },
                    { 4, "555-555-558", 0, 4 },
                    { 5, "555-555-559", 0, 5 },
                    { 6, "555-555-560", 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "RelatedIndividuals",
                columns: new[] { "Id", "PersonId", "RelatedPersonId", "Relationship" },
                values: new object[,]
                {
                    { 1, 1, 2, 0 },
                    { 2, 2, 3, 1 },
                    { 3, 3, 4, 1 },
                    { 4, 4, 5, 3 },
                    { 5, 5, 6, 3 },
                    { 6, 6, 1, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RelatedIndividuals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RelatedIndividuals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RelatedIndividuals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RelatedIndividuals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RelatedIndividuals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RelatedIndividuals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
