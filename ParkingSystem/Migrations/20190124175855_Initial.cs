using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_ParkingSlot_ParkingSlotParkingID",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Payment_PaymentReceiptNo",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSlot_Payment_PaymentReceiptNo",
                table: "ParkingSlot");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionDiscount_Customer_CustomerID",
                table: "PositionDiscount");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_Payment_PaymentReceiptNo",
                table: "Pricing");

            migrationBuilder.DropIndex(
                name: "IX_Pricing_PaymentReceiptNo",
                table: "Pricing");

            migrationBuilder.DropIndex(
                name: "IX_PositionDiscount_CustomerID",
                table: "PositionDiscount");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ParkingSlotParkingID",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_PaymentReceiptNo",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PaymentReceiptNo",
                table: "Pricing");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "PositionDiscount");

            migrationBuilder.DropColumn(
                name: "ParkingSlotParkingID",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PaymentReceiptNo",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "PaymentReceiptNo",
                table: "ParkingSlot",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingSlot_PaymentReceiptNo",
                table: "ParkingSlot",
                newName: "IX_ParkingSlot_CustomerID");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Pricing",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "PositionDiscount",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Payment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParkingSlotParkingID",
                table: "Payment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PricingPeriod",
                table: "Payment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositionDiscountPosition",
                table: "Customer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CustomerID",
                table: "Payment",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ParkingSlotParkingID",
                table: "Payment",
                column: "ParkingSlotParkingID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PricingPeriod",
                table: "Payment",
                column: "PricingPeriod");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PositionDiscountPosition",
                table: "Customer",
                column: "PositionDiscountPosition");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_PositionDiscount_PositionDiscountPosition",
                table: "Customer",
                column: "PositionDiscountPosition",
                principalTable: "PositionDiscount",
                principalColumn: "Position",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSlot_Customer_CustomerID",
                table: "ParkingSlot",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Customer_CustomerID",
                table: "Payment",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_ParkingSlot_ParkingSlotParkingID",
                table: "Payment",
                column: "ParkingSlotParkingID",
                principalTable: "ParkingSlot",
                principalColumn: "ParkingID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Pricing_PricingPeriod",
                table: "Payment",
                column: "PricingPeriod",
                principalTable: "Pricing",
                principalColumn: "Period",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_PositionDiscount_PositionDiscountPosition",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSlot_Customer_CustomerID",
                table: "ParkingSlot");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Customer_CustomerID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_ParkingSlot_ParkingSlotParkingID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Pricing_PricingPeriod",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CustomerID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_ParkingSlotParkingID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_PricingPeriod",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Customer_PositionDiscountPosition",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "ParkingSlotParkingID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PricingPeriod",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PositionDiscountPosition",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "ParkingSlot",
                newName: "PaymentReceiptNo");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingSlot_CustomerID",
                table: "ParkingSlot",
                newName: "IX_ParkingSlot_PaymentReceiptNo");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Pricing",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<int>(
                name: "PaymentReceiptNo",
                table: "Pricing",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "PositionDiscount",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "PositionDiscount",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParkingSlotParkingID",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentReceiptNo",
                table: "Customer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_PaymentReceiptNo",
                table: "Pricing",
                column: "PaymentReceiptNo");

            migrationBuilder.CreateIndex(
                name: "IX_PositionDiscount_CustomerID",
                table: "PositionDiscount",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ParkingSlotParkingID",
                table: "Customer",
                column: "ParkingSlotParkingID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PaymentReceiptNo",
                table: "Customer",
                column: "PaymentReceiptNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_ParkingSlot_ParkingSlotParkingID",
                table: "Customer",
                column: "ParkingSlotParkingID",
                principalTable: "ParkingSlot",
                principalColumn: "ParkingID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Payment_PaymentReceiptNo",
                table: "Customer",
                column: "PaymentReceiptNo",
                principalTable: "Payment",
                principalColumn: "ReceiptNo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSlot_Payment_PaymentReceiptNo",
                table: "ParkingSlot",
                column: "PaymentReceiptNo",
                principalTable: "Payment",
                principalColumn: "ReceiptNo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionDiscount_Customer_CustomerID",
                table: "PositionDiscount",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_Payment_PaymentReceiptNo",
                table: "Pricing",
                column: "PaymentReceiptNo",
                principalTable: "Payment",
                principalColumn: "ReceiptNo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
