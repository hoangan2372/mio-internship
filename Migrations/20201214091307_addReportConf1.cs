using Microsoft.EntityFrameworkCore.Migrations;

namespace mio1412.Migrations
{
    public partial class addReportConf1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Report",
                columns: new[] { "Id", "Issues", "Progress", "Task_Name" },
                values: new object[] { 1, "", "", "task 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
