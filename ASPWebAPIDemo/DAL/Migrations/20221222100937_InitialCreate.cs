using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPWebAPIDemo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notes_Notes_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Notes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "StringNoteProperties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    getvalue = table.Column<string>(name: "get_value", type: "nvarchar(max)", nullable: false),
                    getdataType = table.Column<int>(name: "get_dataType", type: "int", nullable: false),
                    NoteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringNoteProperties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StringNoteProperties_Notes_NoteID",
                        column: x => x.NoteID,
                        principalTable: "Notes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ParentID",
                table: "Notes",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_StringNoteProperties_NoteID",
                table: "StringNoteProperties",
                column: "NoteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StringNoteProperties");

            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
