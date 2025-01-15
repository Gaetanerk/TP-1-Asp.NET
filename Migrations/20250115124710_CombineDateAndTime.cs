using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPTodoList.Migrations
{
    /// <inheritdoc />
    public partial class CombineDateAndTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "TodoList");

            migrationBuilder.RenameColumn(
                name: "DueTime",
                table: "TodoList",
                newName: "DueDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DueDateTime",
                table: "TodoList",
                newName: "DueTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "TodoList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
