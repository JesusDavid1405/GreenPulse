using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlantCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorDevice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatteryLevel = table.Column<float>(type: "real", nullable: false),
                    LastSeenAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorDevice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantSpecies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantCategoryId = table.Column<int>(type: "int", nullable: false),
                    ScientificName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptSoliMoistureMin = table.Column<float>(type: "real", nullable: false),
                    OptSoliMoistureMax = table.Column<float>(type: "real", nullable: false),
                    OptPHMin = table.Column<float>(type: "real", nullable: false),
                    OptPHMax = table.Column<float>(type: "real", nullable: false),
                    OptSolilTempMin = table.Column<float>(type: "real", nullable: false),
                    OptSolilTempMax = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantSpecies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantSpecies_PlantCategory_PlantCategoryId",
                        column: x => x.PlantCategoryId,
                        principalTable: "PlantCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPlant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PlantSpeciesId = table.Column<int>(type: "int", nullable: false),
                    SensorDeviceId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPlant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPlant_PlantSpecies_PlantSpeciesId",
                        column: x => x.PlantSpeciesId,
                        principalTable: "PlantSpecies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPlant_SensorDevice_SensorDeviceId",
                        column: x => x.SensorDeviceId,
                        principalTable: "SensorDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPlant_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPlantId = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcknowledgedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_UserPlant_UserPlantId",
                        column: x => x.UserPlantId,
                        principalTable: "UserPlant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notification_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "sensorReading",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SensorDeviceId = table.Column<int>(type: "int", nullable: false),
                    UserPlantId = table.Column<int>(type: "int", nullable: false),
                    SoilMoisture = table.Column<float>(type: "real", nullable: false),
                    PH = table.Column<float>(type: "real", nullable: false),
                    SoilTemperature = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sensorReading", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sensorReading_SensorDevice_SensorDeviceId",
                        column: x => x.SensorDeviceId,
                        principalTable: "SensorDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sensorReading_UserPlant_UserPlantId",
                        column: x => x.UserPlantId,
                        principalTable: "UserPlant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PlantCategory",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Plantas con hojas carnosas que almacenan agua.", false, "Suculentas" },
                    { 2, false, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Plantas leñosas de tamaño medio.", false, "Arbustos" },
                    { 3, false, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Árboles que producen frutos comestibles.", false, "Árboles frutales" },
                    { 4, false, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Plantas cultivadas por la belleza de sus flores.", false, "Flores ornamentales" }
                });

            migrationBuilder.InsertData(
                table: "SensorDevice",
                columns: new[] { "Id", "Active", "BatteryLevel", "CreatedAt", "DeviceId", "IsDeleted", "LastSeenAt", "Model", "Status" },
                values: new object[,]
                {
                    { 1, false, 95f, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "DEV-001", false, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SoilSense v1", "online" },
                    { 2, false, 85f, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "DEV-002", false, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SoilSense v1", "offline" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Active", "CreatedAt", "Email", "IsDeleted", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@smartagro.com", false, "admin123", "Administrator", "admin" },
                    { 2, false, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "demo@smartagro.com", false, "demo123", "User", "demo" }
                });

            migrationBuilder.InsertData(
                table: "PlantSpecies",
                columns: new[] { "Id", "Active", "CommonName", "CreatedAt", "IsDeleted", "OptPHMax", "OptPHMin", "OptSoliMoistureMax", "OptSoliMoistureMin", "OptSolilTempMax", "OptSolilTempMin", "PlantCategoryId", "ScientificName" },
                values: new object[,]
                {
                    { 1, false, "Aloe Vera", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 7.5f, 6f, 50f, 30f, 27f, 18f, 1, "Aloe barbadensis miller" },
                    { 2, false, "Romero", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 7.5f, 6f, 60f, 40f, 30f, 15f, 2, "Salvia rosmarinus" },
                    { 3, false, "Mango", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 7.5f, 5.5f, 70f, 50f, 35f, 20f, 3, "Mangifera indica" },
                    { 4, false, "Rosa", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 6.8f, 6f, 70f, 40f, 28f, 15f, 4, "Rosa gallica" }
                });

            migrationBuilder.InsertData(
                table: "UserPlant",
                columns: new[] { "Id", "Active", "CreatedAt", "IsDeleted", "Nickname", "PlantSpeciesId", "SensorDeviceId", "UserId" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mi Aloe", 1, 1, 2 },
                    { 2, false, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Mango Dulce", 3, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "AcknowledgedAt", "Active", "CreatedAt", "IsDeleted", "Level", "Message", "Title", "UserId", "UserPlantId" },
                values: new object[,]
                {
                    { 1, null, false, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Utc), false, "info", "El sensor DEV-001 se ha conectado correctamente.", "Sensor conectado", null, 1 },
                    { 2, null, false, new DateTime(2025, 1, 1, 9, 0, 0, 0, DateTimeKind.Utc), false, "warning", "La humedad del suelo cayó por debajo del 30%.", "Baja humedad detectada", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "sensorReading",
                columns: new[] { "Id", "Active", "CreatedAt", "IsDeleted", "PH", "SensorDeviceId", "SoilMoisture", "SoilTemperature", "UserPlantId" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2025, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), false, 6.5f, 1, 45f, 24f, 1 },
                    { 2, false, new DateTime(2025, 1, 1, 8, 10, 0, 0, DateTimeKind.Utc), false, 6.8f, 2, 35f, 26f, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserPlantId",
                table: "Notification",
                column: "UserPlantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantSpecies_PlantCategoryId",
                table: "PlantSpecies",
                column: "PlantCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_sensorReading_SensorDeviceId",
                table: "sensorReading",
                column: "SensorDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_sensorReading_UserPlantId",
                table: "sensorReading",
                column: "UserPlantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlant_PlantSpeciesId",
                table: "UserPlant",
                column: "PlantSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlant_SensorDeviceId",
                table: "UserPlant",
                column: "SensorDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlant_UserId",
                table: "UserPlant",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "sensorReading");

            migrationBuilder.DropTable(
                name: "UserPlant");

            migrationBuilder.DropTable(
                name: "PlantSpecies");

            migrationBuilder.DropTable(
                name: "SensorDevice");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "PlantCategory");
        }
    }
}
