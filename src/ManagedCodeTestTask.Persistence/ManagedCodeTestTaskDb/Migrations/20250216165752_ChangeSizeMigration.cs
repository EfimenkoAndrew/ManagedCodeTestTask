using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagedCodeTestTask.Persistence.ManagedCodeTestTaskDb.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSizeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Merchant",
                schema: "ManagedCodeTestTask",
                table: "Transactions",
                type: "character varying(550)",
                maxLength: 550,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "ManagedCodeTestTask",
                table: "Transactions",
                type: "character varying(550)",
                maxLength: 550,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                schema: "ManagedCodeTestTask",
                table: "Transactions",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Merchant",
                schema: "ManagedCodeTestTask",
                table: "Transactions",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(550)",
                oldMaxLength: 550);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "ManagedCodeTestTask",
                table: "Transactions",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(550)",
                oldMaxLength: 550);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                schema: "ManagedCodeTestTask",
                table: "Transactions",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }
    }
}
