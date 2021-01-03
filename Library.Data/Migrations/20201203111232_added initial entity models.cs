using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class addedinitialentitymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomeLibraryBranchID",
                table: "Patrons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LibraryCardID",
                table: "Patrons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LibraryBranches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBranches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BranchHours",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryBranchID = table.Column<int>(type: "int", nullable: true),
                    DayOfWeak = table.Column<int>(type: "int", nullable: false),
                    OpenTime = table.Column<int>(type: "int", nullable: false),
                    CloseTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchHours", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BranchHours_LibraryBranches_LibraryBranchID",
                        column: x => x.LibraryBranchID,
                        principalTable: "LibraryBranches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LibraryAssets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfCopies = table.Column<int>(type: "int", nullable: false),
                    LibraryBranchID = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeweyIndex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryAssets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LibraryAssets_LibraryBranches_LibraryBranchID",
                        column: x => x.LibraryBranchID,
                        principalTable: "LibraryBranches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibraryAssets_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutHistories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryCardID = table.Column<int>(type: "int", nullable: true),
                    LibraryAssetID = table.Column<int>(type: "int", nullable: true),
                    CheckedOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckedIn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_LibraryAssets_LibraryAssetID",
                        column: x => x.LibraryAssetID,
                        principalTable: "LibraryAssets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_LibraryCards_LibraryCardID",
                        column: x => x.LibraryCardID,
                        principalTable: "LibraryCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryAssetID = table.Column<int>(type: "int", nullable: true),
                    LibraryCardID = table.Column<int>(type: "int", nullable: true),
                    Since = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Until = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Checkouts_LibraryAssets_LibraryAssetID",
                        column: x => x.LibraryAssetID,
                        principalTable: "LibraryAssets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkouts_LibraryCards_LibraryCardID",
                        column: x => x.LibraryCardID,
                        principalTable: "LibraryCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Holds",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryAssetID = table.Column<int>(type: "int", nullable: true),
                    LibraryCardID = table.Column<int>(type: "int", nullable: true),
                    HoldPlaced = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Holds_LibraryAssets_LibraryAssetID",
                        column: x => x.LibraryAssetID,
                        principalTable: "LibraryAssets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holds_LibraryCards_LibraryCardID",
                        column: x => x.LibraryCardID,
                        principalTable: "LibraryCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_HomeLibraryBranchID",
                table: "Patrons",
                column: "HomeLibraryBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_LibraryCardID",
                table: "Patrons",
                column: "LibraryCardID");

            migrationBuilder.CreateIndex(
                name: "IX_BranchHours_LibraryBranchID",
                table: "BranchHours",
                column: "LibraryBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_LibraryAssetID",
                table: "CheckoutHistories",
                column: "LibraryAssetID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_LibraryCardID",
                table: "CheckoutHistories",
                column: "LibraryCardID");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_LibraryAssetID",
                table: "Checkouts",
                column: "LibraryAssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_LibraryCardID",
                table: "Checkouts",
                column: "LibraryCardID");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_LibraryAssetID",
                table: "Holds",
                column: "LibraryAssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_LibraryCardID",
                table: "Holds",
                column: "LibraryCardID");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryAssets_LibraryBranchID",
                table: "LibraryAssets",
                column: "LibraryBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryAssets_StatusID",
                table: "LibraryAssets",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibraryBranches_HomeLibraryBranchID",
                table: "Patrons",
                column: "HomeLibraryBranchID",
                principalTable: "LibraryBranches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibraryCards_LibraryCardID",
                table: "Patrons",
                column: "LibraryCardID",
                principalTable: "LibraryCards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibraryBranches_HomeLibraryBranchID",
                table: "Patrons");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibraryCards_LibraryCardID",
                table: "Patrons");

            migrationBuilder.DropTable(
                name: "BranchHours");

            migrationBuilder.DropTable(
                name: "CheckoutHistories");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Holds");

            migrationBuilder.DropTable(
                name: "LibraryAssets");

            migrationBuilder.DropTable(
                name: "LibraryCards");

            migrationBuilder.DropTable(
                name: "LibraryBranches");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Patrons_HomeLibraryBranchID",
                table: "Patrons");

            migrationBuilder.DropIndex(
                name: "IX_Patrons_LibraryCardID",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "HomeLibraryBranchID",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "LibraryCardID",
                table: "Patrons");
        }
    }
}
