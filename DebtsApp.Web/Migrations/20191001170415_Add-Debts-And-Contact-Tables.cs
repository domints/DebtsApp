using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DebtsApp.Web.Migrations
{
    public partial class AddDebtsAndContactTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    owner_user_id = table.Column<long>(nullable: false),
                    user_id = table.Column<long>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contacts", x => x.id);
                    table.ForeignKey(
                        name: "fk_contacts_users_owner_user_id",
                        column: x => x.owner_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_contacts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "debts",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    creator_id = table.Column<long>(nullable: false),
                    owed_id = table.Column<long>(nullable: true),
                    owing_id = table.Column<long>(nullable: true),
                    owed_contact_id = table.Column<long>(nullable: true),
                    owing_contact_id = table.Column<long>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_debts", x => x.id);
                    table.ForeignKey(
                        name: "fk_debts_users_creator_id",
                        column: x => x.creator_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_debts_contacts_owed_contact_id",
                        column: x => x.owed_contact_id,
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_debts_users_owed_id",
                        column: x => x.owed_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_debts_contacts_owing_contact_id",
                        column: x => x.owing_contact_id,
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_debts_users_owing_id",
                        column: x => x.owing_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_contacts_owner_user_id",
                table: "contacts",
                column: "owner_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_contacts_user_id",
                table: "contacts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_debts_creator_id",
                table: "debts",
                column: "creator_id");

            migrationBuilder.CreateIndex(
                name: "ix_debts_owed_contact_id",
                table: "debts",
                column: "owed_contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_debts_owed_id",
                table: "debts",
                column: "owed_id");

            migrationBuilder.CreateIndex(
                name: "ix_debts_owing_contact_id",
                table: "debts",
                column: "owing_contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_debts_owing_id",
                table: "debts",
                column: "owing_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "debts");

            migrationBuilder.DropTable(
                name: "contacts");
        }
    }
}
