using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTT.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTk = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "chuas",
                columns: table => new
                {
                    chuaid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    capnhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngaythanhlap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tenchua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trutri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chuas", x => x.chuaid);
                });

            migrationBuilder.CreateTable(
                name: "daotrangs",
                columns: table => new
                {
                    daotrangid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    daketthuc = table.Column<bool>(type: "bit", nullable: false),
                    noidung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    noitochuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sothanhvienthamgia = table.Column<int>(type: "int", nullable: false),
                    thoigiantochuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nguoitrutri = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_daotrangs", x => x.daotrangid);
                });

            migrationBuilder.CreateTable(
                name: "kieuthanhviens",
                columns: table => new
                {
                    kieuthanhvienid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenkieu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kieuthanhviens", x => x.kieuthanhvienid);
                });

            migrationBuilder.CreateTable(
                name: "phattus",
                columns: table => new
                {
                    phantuid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    anhchup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dahoantuc = table.Column<bool>(type: "bit", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gioitinh = table.Column<int>(type: "int", nullable: false),
                    ho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngaycapnhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngayhoantuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngayxuatgia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phapdanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sodienthoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tendem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chuaid = table.Column<int>(type: "int", nullable: false),
                    kieuthanhvienid = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phattus", x => x.phantuid);
                    table.ForeignKey(
                        name: "FK_phattus_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phattus_chuas_chuaid",
                        column: x => x.chuaid,
                        principalTable: "chuas",
                        principalColumn: "chuaid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phattus_kieuthanhviens_kieuthanhvienid",
                        column: x => x.kieuthanhvienid,
                        principalTable: "kieuthanhviens",
                        principalColumn: "kieuthanhvienid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dondangkys",
                columns: table => new
                {
                    dondangkyid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ngayguidon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngayxuly = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nguoixuly = table.Column<int>(type: "int", nullable: false),
                    trangthaidon = table.Column<int>(type: "int", nullable: false),
                    daotrangid = table.Column<int>(type: "int", nullable: false),
                    phatuid = table.Column<int>(type: "int", nullable: false),
                    phattuphantuid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dondangkys", x => x.dondangkyid);
                    table.ForeignKey(
                        name: "FK_dondangkys_daotrangs_daotrangid",
                        column: x => x.daotrangid,
                        principalTable: "daotrangs",
                        principalColumn: "daotrangid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dondangkys_phattus_phattuphantuid",
                        column: x => x.phattuphantuid,
                        principalTable: "phattus",
                        principalColumn: "phantuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phattudaotrangs",
                columns: table => new
                {
                    phattudaotrangid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dathamgia = table.Column<bool>(type: "bit", nullable: false),
                    lydokhongthamgia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    daotrangid = table.Column<int>(type: "int", nullable: false),
                    phattuid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phattudaotrangs", x => x.phattudaotrangid);
                    table.ForeignKey(
                        name: "FK_phattudaotrangs_daotrangs_daotrangid",
                        column: x => x.daotrangid,
                        principalTable: "daotrangs",
                        principalColumn: "daotrangid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phattudaotrangs_phattus_phattuid",
                        column: x => x.phattuid,
                        principalTable: "phattus",
                        principalColumn: "phantuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "token",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stoken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expired = table.Column<bool>(type: "bit", nullable: false),
                    revoked = table.Column<bool>(type: "bit", nullable: false),
                    token_type = table.Column<int>(type: "int", nullable: false),
                    phattuid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_token", x => x.id);
                    table.ForeignKey(
                        name: "FK_token_phattus_phattuid",
                        column: x => x.phattuid,
                        principalTable: "phattus",
                        principalColumn: "phantuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dondangkys_daotrangid",
                table: "dondangkys",
                column: "daotrangid");

            migrationBuilder.CreateIndex(
                name: "IX_dondangkys_phattuphantuid",
                table: "dondangkys",
                column: "phattuphantuid");

            migrationBuilder.CreateIndex(
                name: "IX_phattudaotrangs_daotrangid",
                table: "phattudaotrangs",
                column: "daotrangid");

            migrationBuilder.CreateIndex(
                name: "IX_phattudaotrangs_phattuid",
                table: "phattudaotrangs",
                column: "phattuid");

            migrationBuilder.CreateIndex(
                name: "IX_phattus_AdminId",
                table: "phattus",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_phattus_chuaid",
                table: "phattus",
                column: "chuaid");

            migrationBuilder.CreateIndex(
                name: "IX_phattus_kieuthanhvienid",
                table: "phattus",
                column: "kieuthanhvienid");

            migrationBuilder.CreateIndex(
                name: "IX_token_phattuid",
                table: "token",
                column: "phattuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dondangkys");

            migrationBuilder.DropTable(
                name: "phattudaotrangs");

            migrationBuilder.DropTable(
                name: "token");

            migrationBuilder.DropTable(
                name: "daotrangs");

            migrationBuilder.DropTable(
                name: "phattus");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "chuas");

            migrationBuilder.DropTable(
                name: "kieuthanhviens");
        }
    }
}
