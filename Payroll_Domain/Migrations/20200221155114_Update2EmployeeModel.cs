using Microsoft.EntityFrameworkCore.Migrations;

namespace Payroll_Domain.Migrations
{
    public partial class Update2EmployeeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRecords_Employees_EmmployeeId",
                table: "PaymentRecords");

            migrationBuilder.DropColumn(
                name: "NINo",
                table: "PaymentRecords");

            migrationBuilder.RenameColumn(
                name: "EmmployeeId",
                table: "PaymentRecords",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentRecords_EmmployeeId",
                table: "PaymentRecords",
                newName: "IX_PaymentRecords_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "NationalInsuranceNo",
                table: "Employees",
                newName: "InsuranceNo");

            migrationBuilder.AlterColumn<string>(
                name: "YearofTax",
                table: "TaxYears",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "FIRS",
                table: "PaymentRecords",
                type: "money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AddColumn<decimal>(
                name: "I_No",
                table: "PaymentRecords",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRecords_Employees_EmployeeId",
                table: "PaymentRecords",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRecords_Employees_EmployeeId",
                table: "PaymentRecords");

            migrationBuilder.DropColumn(
                name: "I_No",
                table: "PaymentRecords");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "PaymentRecords",
                newName: "EmmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentRecords_EmployeeId",
                table: "PaymentRecords",
                newName: "IX_PaymentRecords_EmmployeeId");

            migrationBuilder.RenameColumn(
                name: "InsuranceNo",
                table: "Employees",
                newName: "NationalInsuranceNo");

            migrationBuilder.AlterColumn<int>(
                name: "YearofTax",
                table: "TaxYears",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FIRS",
                table: "PaymentRecords",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NINo",
                table: "PaymentRecords",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRecords_Employees_EmmployeeId",
                table: "PaymentRecords",
                column: "EmmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
