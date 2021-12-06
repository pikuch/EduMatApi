using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduMatApi.Migrations
{
    public partial class RequireCategoryAndAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2021, 11, 6, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2021, 11, 5, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2021, 11, 4, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishDate",
                value: new DateTime(2021, 11, 3, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishDate",
                value: new DateTime(2021, 11, 2, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishDate",
                value: new DateTime(2021, 11, 1, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 7,
                column: "PublishDate",
                value: new DateTime(2021, 10, 31, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 8,
                column: "PublishDate",
                value: new DateTime(2021, 10, 30, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3103));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 9,
                column: "PublishDate",
                value: new DateTime(2021, 10, 29, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3105));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 10,
                column: "PublishDate",
                value: new DateTime(2021, 10, 28, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 11,
                column: "PublishDate",
                value: new DateTime(2021, 10, 27, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3109));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 12,
                column: "PublishDate",
                value: new DateTime(2021, 10, 26, 14, 3, 2, 23, DateTimeKind.Local).AddTicks(3111));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2021, 11, 6, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2021, 11, 5, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2899));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2021, 11, 4, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2901));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishDate",
                value: new DateTime(2021, 11, 3, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2903));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishDate",
                value: new DateTime(2021, 11, 2, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2905));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishDate",
                value: new DateTime(2021, 11, 1, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 7,
                column: "PublishDate",
                value: new DateTime(2021, 10, 31, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2909));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 8,
                column: "PublishDate",
                value: new DateTime(2021, 10, 30, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2911));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 9,
                column: "PublishDate",
                value: new DateTime(2021, 10, 29, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2913));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 10,
                column: "PublishDate",
                value: new DateTime(2021, 10, 28, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2916));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 11,
                column: "PublishDate",
                value: new DateTime(2021, 10, 27, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2917));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 12,
                column: "PublishDate",
                value: new DateTime(2021, 10, 26, 13, 5, 37, 942, DateTimeKind.Local).AddTicks(2919));
        }
    }
}
