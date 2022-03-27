using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MortageApp.Web.Migrations
{
    public partial class AddMortgageToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mortgages",
                columns: table => new
                {
                    MortgageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MortgageType = table.Column<int>(type: "int", nullable: false),
                    InterestRepayment = table.Column<int>(type: "int", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TermsInMonths = table.Column<int>(type: "int", nullable: false),
                    CancellationFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstablishmentFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SchemaIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mortgages", x => x.MortgageId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mortgages");
        }
    }
}
