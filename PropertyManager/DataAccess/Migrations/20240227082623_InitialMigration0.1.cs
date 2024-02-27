using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "system");

            migrationBuilder.EnsureSchema(
                name: "log");

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                schema: "log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MethodName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InnerMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogType = table.Column<int>(type: "int", nullable: false),
                    MachineInfo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Selling = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyOwnerships",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AskingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceAcquisition = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveTill = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MachineInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyOwnerships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsageLogs",
                schema: "log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MachineInfo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsageLogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "system");

            migrationBuilder.DropTable(
                name: "Log",
                schema: "log");

            migrationBuilder.DropTable(
                name: "Properties",
                schema: "system");

            migrationBuilder.DropTable(
                name: "PropertyOwnerships",
                schema: "system");

            migrationBuilder.DropTable(
                name: "UsageLogs",
                schema: "log");
        }
    }
}
