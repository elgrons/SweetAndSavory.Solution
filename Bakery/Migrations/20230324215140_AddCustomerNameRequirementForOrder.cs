using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakery.Migrations
{
    public partial class AddCustomerNameRequirementForOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTreat_Order_OrderId",
                table: "OrderTreat");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTreat_Treats_TreatId",
                table: "OrderTreat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderTreat",
                table: "OrderTreat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "OrderTreat",
                newName: "OrderTreats");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderTreat_TreatId",
                table: "OrderTreats",
                newName: "IX_OrderTreats_TreatId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderTreat_OrderId",
                table: "OrderTreats",
                newName: "IX_OrderTreats_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Customer",
                keyValue: null,
                column: "Customer",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Customer",
                table: "Orders",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderTreats",
                table: "OrderTreats",
                column: "OrderTreatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTreats_Orders_OrderId",
                table: "OrderTreats",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTreats_Treats_TreatId",
                table: "OrderTreats",
                column: "TreatId",
                principalTable: "Treats",
                principalColumn: "TreatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTreats_Orders_OrderId",
                table: "OrderTreats");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTreats_Treats_TreatId",
                table: "OrderTreats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderTreats",
                table: "OrderTreats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "OrderTreats",
                newName: "OrderTreat");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_OrderTreats_TreatId",
                table: "OrderTreat",
                newName: "IX_OrderTreat_TreatId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderTreats_OrderId",
                table: "OrderTreat",
                newName: "IX_OrderTreat_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Customer",
                table: "Order",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderTreat",
                table: "OrderTreat",
                column: "OrderTreatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTreat_Order_OrderId",
                table: "OrderTreat",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTreat_Treats_TreatId",
                table: "OrderTreat",
                column: "TreatId",
                principalTable: "Treats",
                principalColumn: "TreatId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
