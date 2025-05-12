using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Topic.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class subscriber6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Subscribers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Subscribers");
        }
    }
}
