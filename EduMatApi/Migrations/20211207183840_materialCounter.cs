using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduMatApi.Migrations
{
    public partial class materialCounter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaterialCounter",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2021, 11, 7, 19, 38, 39, 996, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2021, 11, 6, 19, 38, 39, 996, DateTimeKind.Local).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2021, 11, 5, 19, 38, 39, 996, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishDate",
                value: new DateTime(2021, 11, 4, 19, 38, 39, 996, DateTimeKind.Local).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishDate",
                value: new DateTime(2021, 11, 3, 19, 38, 39, 996, DateTimeKind.Local).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishDate",
                value: new DateTime(2021, 11, 2, 19, 38, 39, 996, DateTimeKind.Local).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 7,
                column: "PublishDate",
                value: new DateTime(2021, 11, 1, 19, 38, 39, 996, DateTimeKind.Local).AddTicks(5231));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 8,
                column: "PublishDate",
                value: new DateTime(2021, 10, 31, 19, 38, 39, 996, DateTimeKind.Local).AddTicks(5233));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 9,
                column: "PublishDate",
                value: new DateTime(2021, 10, 30, 19, 38, 39, 996, DateTimeKind.Local).AddTicks(5234));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 10,
                column: "PublishDate",
                value: new DateTime(2021, 10, 29, 19, 38, 39, 996, DateTimeKind.Local).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 11,
                column: "PublishDate",
                value: new DateTime(2021, 10, 28, 19, 38, 39, 996, DateTimeKind.Local).AddTicks(5238));

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 12,
                column: "PublishDate",
                value: new DateTime(2021, 10, 27, 19, 38, 39, 996, DateTimeKind.Local).AddTicks(5240));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialCounter",
                table: "Authors");

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
    }
}
