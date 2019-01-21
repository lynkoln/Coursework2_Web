using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingSystem.Migrations
{
    public partial class InitialModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ReceiptNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeOfPayment = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.ReceiptNo);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSlot",
                columns: table => new
                {
                    ParkingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Plate = table.Column<string>(nullable: false),
                    TimeIn = table.Column<DateTime>(nullable: false),
                    TimeOut = table.Column<DateTime>(nullable: true),
                    PaymentReceiptNo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSlot", x => x.ParkingID);
                    table.ForeignKey(
                        name: "FK_ParkingSlot_Payment_PaymentReceiptNo",
                        column: x => x.PaymentReceiptNo,
                        principalTable: "Payment",
                        principalColumn: "ReceiptNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pricing",
                columns: table => new
                {
                    Period = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(nullable: false),
                    PaymentReceiptNo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricing", x => x.Period);
                    table.ForeignKey(
                        name: "FK_Pricing_Payment_PaymentReceiptNo",
                        column: x => x.PaymentReceiptNo,
                        principalTable: "Payment",
                        principalColumn: "ReceiptNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNo = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ParkingSlotParkingID = table.Column<int>(nullable: true),
                    PaymentReceiptNo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customer_ParkingSlot_ParkingSlotParkingID",
                        column: x => x.ParkingSlotParkingID,
                        principalTable: "ParkingSlot",
                        principalColumn: "ParkingID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_Payment_PaymentReceiptNo",
                        column: x => x.PaymentReceiptNo,
                        principalTable: "Payment",
                        principalColumn: "ReceiptNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PositionDiscount",
                columns: table => new
                {
                    Position = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CustomerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionDiscount", x => x.Position);
                    table.ForeignKey(
                        name: "FK_PositionDiscount_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ParkingSlotParkingID",
                table: "Customer",
                column: "ParkingSlotParkingID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PaymentReceiptNo",
                table: "Customer",
                column: "PaymentReceiptNo");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSlot_PaymentReceiptNo",
                table: "ParkingSlot",
                column: "PaymentReceiptNo");

            migrationBuilder.CreateIndex(
                name: "IX_PositionDiscount_CustomerID",
                table: "PositionDiscount",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_PaymentReceiptNo",
                table: "Pricing",
                column: "PaymentReceiptNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "PositionDiscount");

            migrationBuilder.DropTable(
                name: "Pricing");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "ParkingSlot");

            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
