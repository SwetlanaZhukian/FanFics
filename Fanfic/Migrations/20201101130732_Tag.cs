using Microsoft.EntityFrameworkCore.Migrations;

namespace Fanfic.Migrations
{
    public partial class Tag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagComposition_Compositions_CompositionId",
                table: "TagComposition");

            migrationBuilder.DropForeignKey(
                name: "FK_TagComposition_Tags_TagId",
                table: "TagComposition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagComposition",
                table: "TagComposition");

            migrationBuilder.RenameTable(
                name: "TagComposition",
                newName: "TagCompositions");

            migrationBuilder.RenameIndex(
                name: "IX_TagComposition_CompositionId",
                table: "TagCompositions",
                newName: "IX_TagCompositions_CompositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagCompositions",
                table: "TagCompositions",
                columns: new[] { "TagId", "CompositionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TagCompositions_Compositions_CompositionId",
                table: "TagCompositions",
                column: "CompositionId",
                principalTable: "Compositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagCompositions_Tags_TagId",
                table: "TagCompositions",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagCompositions_Compositions_CompositionId",
                table: "TagCompositions");

            migrationBuilder.DropForeignKey(
                name: "FK_TagCompositions_Tags_TagId",
                table: "TagCompositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagCompositions",
                table: "TagCompositions");

            migrationBuilder.RenameTable(
                name: "TagCompositions",
                newName: "TagComposition");

            migrationBuilder.RenameIndex(
                name: "IX_TagCompositions_CompositionId",
                table: "TagComposition",
                newName: "IX_TagComposition_CompositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagComposition",
                table: "TagComposition",
                columns: new[] { "TagId", "CompositionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TagComposition_Compositions_CompositionId",
                table: "TagComposition",
                column: "CompositionId",
                principalTable: "Compositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagComposition_Tags_TagId",
                table: "TagComposition",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
