namespace Wimym.DatabaseContext.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class operationstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    OperationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Recurrent = table.Column<bool>(nullable: false),
                    Observations = table.Column<string>(maxLength: 500, nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    PeriodicityId = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false),
                    OriginId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.OperationId);
                    table.ForeignKey(
                        name: "FK_Operations_AccountingAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AccountingAccounts",
                        principalColumn: "AccountingAccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operations_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operations_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operations_Origins_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origins",
                        principalColumn: "OriginId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operations_Periodicities_PeriodicityId",
                        column: x => x.PeriodicityId,
                        principalTable: "Periodicities",
                        principalColumn: "PeriodicityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operations_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operations_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_AccountId",
                table: "Operations",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_CreatedBy",
                table: "Operations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_DeletedBy",
                table: "Operations",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_OriginId",
                table: "Operations",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_PeriodicityId",
                table: "Operations",
                column: "PeriodicityId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_TagId",
                table: "Operations",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_UpdatedBy",
                table: "Operations",
                column: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");
        }
    }
}
