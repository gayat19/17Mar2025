using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApplication.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Email",
                table: "Doctors",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Users_Email",
                table: "Doctors",
                column: "Email",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Users_Email",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_Email",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Doctors");
        }
    }
}
 