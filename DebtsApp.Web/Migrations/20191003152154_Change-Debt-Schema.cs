using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtsApp.Web.Migrations
{
    public partial class ChangeDebtSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_debts_contacts_owed_contact_id",
                table: "debts");

            migrationBuilder.DropForeignKey(
                name: "fk_debts_users_owed_id",
                table: "debts");

            migrationBuilder.DropForeignKey(
                name: "fk_debts_contacts_owing_contact_id",
                table: "debts");

            migrationBuilder.DropForeignKey(
                name: "fk_debts_users_owing_id",
                table: "debts");

            migrationBuilder.DropIndex(
                name: "ix_debts_owed_contact_id",
                table: "debts");

            migrationBuilder.DropIndex(
                name: "ix_debts_owed_id",
                table: "debts");

            migrationBuilder.DropColumn(
                name: "owed_contact_id",
                table: "debts");

            migrationBuilder.DropColumn(
                name: "owed_id",
                table: "debts");

            migrationBuilder.RenameColumn(
                name: "owing_id",
                table: "debts",
                newName: "other_user_id");

            migrationBuilder.RenameColumn(
                name: "owing_contact_id",
                table: "debts",
                newName: "other_contact_id");

            migrationBuilder.RenameIndex(
                name: "ix_debts_owing_id",
                table: "debts",
                newName: "ix_debts_other_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_debts_owing_contact_id",
                table: "debts",
                newName: "ix_debts_other_contact_id");

            migrationBuilder.AddColumn<bool>(
                name: "is_my_debt",
                table: "debts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "fk_debts_contacts_other_contact_id",
                table: "debts",
                column: "other_contact_id",
                principalTable: "contacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_debts_users_other_user_id",
                table: "debts",
                column: "other_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_debts_contacts_other_contact_id",
                table: "debts");

            migrationBuilder.DropForeignKey(
                name: "fk_debts_users_other_user_id",
                table: "debts");

            migrationBuilder.DropColumn(
                name: "is_my_debt",
                table: "debts");

            migrationBuilder.RenameColumn(
                name: "other_user_id",
                table: "debts",
                newName: "owing_id");

            migrationBuilder.RenameColumn(
                name: "other_contact_id",
                table: "debts",
                newName: "owing_contact_id");

            migrationBuilder.RenameIndex(
                name: "ix_debts_other_user_id",
                table: "debts",
                newName: "ix_debts_owing_id");

            migrationBuilder.RenameIndex(
                name: "ix_debts_other_contact_id",
                table: "debts",
                newName: "ix_debts_owing_contact_id");

            migrationBuilder.AddColumn<long>(
                name: "owed_contact_id",
                table: "debts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "owed_id",
                table: "debts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_debts_owed_contact_id",
                table: "debts",
                column: "owed_contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_debts_owed_id",
                table: "debts",
                column: "owed_id");

            migrationBuilder.AddForeignKey(
                name: "fk_debts_contacts_owed_contact_id",
                table: "debts",
                column: "owed_contact_id",
                principalTable: "contacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_debts_users_owed_id",
                table: "debts",
                column: "owed_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_debts_contacts_owing_contact_id",
                table: "debts",
                column: "owing_contact_id",
                principalTable: "contacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_debts_users_owing_id",
                table: "debts",
                column: "owing_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
