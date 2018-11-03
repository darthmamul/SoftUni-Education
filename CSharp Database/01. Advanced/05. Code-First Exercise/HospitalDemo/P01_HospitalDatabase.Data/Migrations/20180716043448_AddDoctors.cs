using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_HospitalDatabase.Data.Migrations
{
    public partial class AddDoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Visitations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Specialty = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "MedicamentId", "Name" },
                values: new object[,]
                {
                    { 1, "Biseptol" },
                    { 18, "Terramicina Oftalmica" },
                    { 17, "Reglin" },
                    { 16, "Propoven" },
                    { 15, "Primperan" },
                    { 14, "Primolut Nor" },
                    { 13, "Pentrexyl" },
                    { 12, "Olfen" },
                    { 11, "Nistatin" },
                    { 10, "Navidoxine" },
                    { 9, "Fluimucil" },
                    { 8, "Flanax" },
                    { 7, "Efedrin" },
                    { 6, "Duvadilan" },
                    { 5, "Disflatyl" },
                    { 4, "Diclofenaco" },
                    { 3, "Curam" },
                    { 2, "Ciclobenzaprina" },
                    { 19, "Ultran" },
                    { 20, "Viartril-S" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visitations_DoctorId",
                table: "Visitations",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitations_Doctors_DoctorId",
                table: "Visitations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitations_Doctors_DoctorId",
                table: "Visitations");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Visitations_DoctorId",
                table: "Visitations");

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "MedicamentId",
                keyValue: 20);

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Visitations");
        }
    }
}
