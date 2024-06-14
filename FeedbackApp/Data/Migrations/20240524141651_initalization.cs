using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FeedbackApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initalization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "benh_nhan",
                columns: table => new
                {
                    so_dien_thoai = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    ho_ten = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    gioi_tinh = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    tuoi = table.Column<short>(type: "smallint", nullable: false),
                    khoang_cach = table.Column<short>(type: "smallint", nullable: false),
                    su_dung_bhyt = table.Column<bool>(type: "boolean", nullable: true),
                    so_ngay_dieu_tri = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_benh_nhan", x => x.so_dien_thoai);
                });

            migrationBuilder.CreateTable(
                name: "cau_hoi_mo",
                columns: table => new
                {
                    ma_cau_hoi_mo = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ten_cau_hoi_mo = table.Column<string>(type: "text", nullable: false),
                    trang_thai = table.Column<bool>(type: "boolean", nullable: false),
                    thu_tu = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cau_hoi_mo", x => x.ma_cau_hoi_mo);
                });

            migrationBuilder.CreateTable(
                name: "danh_muc_cau_hoi_dong",
                columns: table => new
                {
                    ma_danh_muc_cau_hoi_dong = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    ten_danh_muc_cau_hoi_dong = table.Column<string>(type: "text", nullable: false),
                    trang_thai = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_danh_muc_cau_hoi_dong", x => x.ma_danh_muc_cau_hoi_dong);
                });

            migrationBuilder.CreateTable(
                name: "hoat_dong",
                columns: table => new
                {
                    ma_hoat_dong = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ten_hoat_dong = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoat_dong", x => x.ma_hoat_dong);
                });

            migrationBuilder.CreateTable(
                name: "loai_khao_sat",
                columns: table => new
                {
                    ma_loai_khao_sat = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    ten_loai_khao_sat = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loai_khao_sat", x => x.ma_loai_khao_sat);
                });

            migrationBuilder.CreateTable(
                name: "loai_muc_do_danh_gia",
                columns: table => new
                {
                    ma_loai_muc_do_danh_gia = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    ten_loai_muc_do_danh_gia = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loai_muc_do_danh_gia", x => x.ma_loai_muc_do_danh_gia);
                });

            migrationBuilder.CreateTable(
                name: "nhan_vien",
                columns: table => new
                {
                    ten_dang_nhap = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    mat_khau = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    ho_ten = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    so_dien_thoai = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    thu_dien_tu = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhan_vien", x => x.ten_dang_nhap);
                });

            migrationBuilder.CreateTable(
                name: "cau_hoi_khao_sat_mo",
                columns: table => new
                {
                    ma_loai_khao_sat = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    ma_cau_hoi_dong = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cau_hoi_khao_sat_mo", x => new { x.ma_loai_khao_sat, x.ma_cau_hoi_dong });
                    table.ForeignKey(
                        name: "FK_cau_hoi_khao_sat_mo_cau_hoi_mo_ma_cau_hoi_dong",
                        column: x => x.ma_cau_hoi_dong,
                        principalTable: "cau_hoi_mo",
                        principalColumn: "ma_cau_hoi_mo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cau_hoi_khao_sat_mo_loai_khao_sat_ma_loai_khao_sat",
                        column: x => x.ma_loai_khao_sat,
                        principalTable: "loai_khao_sat",
                        principalColumn: "ma_loai_khao_sat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phan_hoi",
                columns: table => new
                {
                    ma_phan_hoi = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    thoi_gian_thuc_hien = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    so_dien_thoai = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    su_dung_bhyt = table.Column<bool>(type: "boolean", nullable: false),
                    so_ngay_dieu_tri = table.Column<short>(type: "smallint", nullable: false),
                    ma_loai_khao_sat = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phan_hoi", x => x.ma_phan_hoi);
                    table.ForeignKey(
                        name: "FK_phan_hoi_benh_nhan_so_dien_thoai",
                        column: x => x.so_dien_thoai,
                        principalTable: "benh_nhan",
                        principalColumn: "so_dien_thoai",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phan_hoi_loai_khao_sat_ma_loai_khao_sat",
                        column: x => x.ma_loai_khao_sat,
                        principalTable: "loai_khao_sat",
                        principalColumn: "ma_loai_khao_sat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cau_hoi_dong",
                columns: table => new
                {
                    ma_cau_hoi_dong = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ten_cau_hoi_dong = table.Column<string>(type: "text", nullable: false),
                    trang_thai = table.Column<bool>(type: "boolean", nullable: false),
                    thu_tu = table.Column<short>(type: "smallint", nullable: false),
                    ma_danh_muc_cau_hoi_dong = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    ma_loai_muc_do_danh_gia = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cau_hoi_dong", x => x.ma_cau_hoi_dong);
                    table.ForeignKey(
                        name: "FK_cau_hoi_dong_danh_muc_cau_hoi_dong_ma_danh_muc_cau_hoi_dong",
                        column: x => x.ma_danh_muc_cau_hoi_dong,
                        principalTable: "danh_muc_cau_hoi_dong",
                        principalColumn: "ma_danh_muc_cau_hoi_dong",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cau_hoi_dong_loai_muc_do_danh_gia_ma_loai_muc_do_danh_gia",
                        column: x => x.ma_loai_muc_do_danh_gia,
                        principalTable: "loai_muc_do_danh_gia",
                        principalColumn: "ma_loai_muc_do_danh_gia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "muc_do",
                columns: table => new
                {
                    ma_muc_do_diem = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ten_muc_do_diem = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    muc_diem_so = table.Column<short>(type: "smallint", nullable: false),
                    ma_loai_muc_do_danh_gia = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_muc_do", x => x.ma_muc_do_diem);
                    table.ForeignKey(
                        name: "FK_muc_do_loai_muc_do_danh_gia_ma_loai_muc_do_danh_gia",
                        column: x => x.ma_loai_muc_do_danh_gia,
                        principalTable: "loai_muc_do_danh_gia",
                        principalColumn: "ma_loai_muc_do_danh_gia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quyen",
                columns: table => new
                {
                    ten_dang_nhap = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ma_hoat_dong = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quyen", x => new { x.ten_dang_nhap, x.ma_hoat_dong });
                    table.ForeignKey(
                        name: "FK_quyen_hoat_dong_ma_hoat_dong",
                        column: x => x.ma_hoat_dong,
                        principalTable: "hoat_dong",
                        principalColumn: "ma_hoat_dong",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quyen_nhan_vien_ten_dang_nhap",
                        column: x => x.ten_dang_nhap,
                        principalTable: "nhan_vien",
                        principalColumn: "ten_dang_nhap",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chi_tiet_khao_sat_mo",
                columns: table => new
                {
                    ma_cau_hoi_mo = table.Column<short>(type: "smallint", nullable: false),
                    ma_phan_hoi = table.Column<long>(type: "bigint", nullable: false),
                    Conttent = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chi_tiet_khao_sat_mo", x => new { x.ma_phan_hoi, x.ma_cau_hoi_mo });
                    table.ForeignKey(
                        name: "FK_chi_tiet_khao_sat_mo_cau_hoi_mo_ma_cau_hoi_mo",
                        column: x => x.ma_cau_hoi_mo,
                        principalTable: "cau_hoi_mo",
                        principalColumn: "ma_cau_hoi_mo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chi_tiet_khao_sat_mo_phan_hoi_ma_phan_hoi",
                        column: x => x.ma_phan_hoi,
                        principalTable: "phan_hoi",
                        principalColumn: "ma_phan_hoi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cau_hoi_khao_sat_dong",
                columns: table => new
                {
                    ma_loai_khao_sat = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    ma_cau_hoi_dong = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cau_hoi_khao_sat_dong", x => new { x.ma_loai_khao_sat, x.ma_cau_hoi_dong });
                    table.ForeignKey(
                        name: "FK_cau_hoi_khao_sat_dong_cau_hoi_dong_ma_cau_hoi_dong",
                        column: x => x.ma_cau_hoi_dong,
                        principalTable: "cau_hoi_dong",
                        principalColumn: "ma_cau_hoi_dong",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cau_hoi_khao_sat_dong_loai_khao_sat_ma_loai_khao_sat",
                        column: x => x.ma_loai_khao_sat,
                        principalTable: "loai_khao_sat",
                        principalColumn: "ma_loai_khao_sat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chi_tiet_khao_sat_dong",
                columns: table => new
                {
                    ma_cau_hoi_dong = table.Column<short>(type: "smallint", nullable: false),
                    ma_phan_hoi = table.Column<long>(type: "bigint", nullable: false),
                    ma_muc_do_diem = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chi_tiet_khao_sat_dong", x => new { x.ma_phan_hoi, x.ma_cau_hoi_dong });
                    table.ForeignKey(
                        name: "FK_chi_tiet_khao_sat_dong_cau_hoi_dong_ma_cau_hoi_dong",
                        column: x => x.ma_cau_hoi_dong,
                        principalTable: "cau_hoi_dong",
                        principalColumn: "ma_cau_hoi_dong",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chi_tiet_khao_sat_dong_muc_do_ma_muc_do_diem",
                        column: x => x.ma_muc_do_diem,
                        principalTable: "muc_do",
                        principalColumn: "ma_muc_do_diem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chi_tiet_khao_sat_dong_phan_hoi_ma_phan_hoi",
                        column: x => x.ma_phan_hoi,
                        principalTable: "phan_hoi",
                        principalColumn: "ma_phan_hoi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "nhan_vien",
                columns: new[] { "ten_dang_nhap", "thu_dien_tu", "ho_ten", "mat_khau", "so_dien_thoai" },
                values: new object[] { "quockhanh", "khanhhuynh912@gmail.com", "Huỳnh Quốc Khánh", "376235639513033711459238240508416048", "0334190027" });

            migrationBuilder.CreateIndex(
                name: "IX_cau_hoi_dong_ma_danh_muc_cau_hoi_dong",
                table: "cau_hoi_dong",
                column: "ma_danh_muc_cau_hoi_dong");

            migrationBuilder.CreateIndex(
                name: "IX_cau_hoi_dong_ma_loai_muc_do_danh_gia",
                table: "cau_hoi_dong",
                column: "ma_loai_muc_do_danh_gia");

            migrationBuilder.CreateIndex(
                name: "IX_cau_hoi_khao_sat_dong_ma_cau_hoi_dong",
                table: "cau_hoi_khao_sat_dong",
                column: "ma_cau_hoi_dong");

            migrationBuilder.CreateIndex(
                name: "IX_cau_hoi_khao_sat_mo_ma_cau_hoi_dong",
                table: "cau_hoi_khao_sat_mo",
                column: "ma_cau_hoi_dong");

            migrationBuilder.CreateIndex(
                name: "IX_chi_tiet_khao_sat_dong_ma_cau_hoi_dong",
                table: "chi_tiet_khao_sat_dong",
                column: "ma_cau_hoi_dong");

            migrationBuilder.CreateIndex(
                name: "IX_chi_tiet_khao_sat_dong_ma_muc_do_diem",
                table: "chi_tiet_khao_sat_dong",
                column: "ma_muc_do_diem");

            migrationBuilder.CreateIndex(
                name: "IX_chi_tiet_khao_sat_mo_ma_cau_hoi_mo",
                table: "chi_tiet_khao_sat_mo",
                column: "ma_cau_hoi_mo");

            migrationBuilder.CreateIndex(
                name: "IX_muc_do_ma_loai_muc_do_danh_gia",
                table: "muc_do",
                column: "ma_loai_muc_do_danh_gia");

            migrationBuilder.CreateIndex(
                name: "IX_phan_hoi_ma_loai_khao_sat",
                table: "phan_hoi",
                column: "ma_loai_khao_sat");

            migrationBuilder.CreateIndex(
                name: "IX_phan_hoi_so_dien_thoai",
                table: "phan_hoi",
                column: "so_dien_thoai");

            migrationBuilder.CreateIndex(
                name: "IX_quyen_ma_hoat_dong",
                table: "quyen",
                column: "ma_hoat_dong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cau_hoi_khao_sat_dong");

            migrationBuilder.DropTable(
                name: "cau_hoi_khao_sat_mo");

            migrationBuilder.DropTable(
                name: "chi_tiet_khao_sat_dong");

            migrationBuilder.DropTable(
                name: "chi_tiet_khao_sat_mo");

            migrationBuilder.DropTable(
                name: "quyen");

            migrationBuilder.DropTable(
                name: "cau_hoi_dong");

            migrationBuilder.DropTable(
                name: "muc_do");

            migrationBuilder.DropTable(
                name: "cau_hoi_mo");

            migrationBuilder.DropTable(
                name: "phan_hoi");

            migrationBuilder.DropTable(
                name: "hoat_dong");

            migrationBuilder.DropTable(
                name: "nhan_vien");

            migrationBuilder.DropTable(
                name: "danh_muc_cau_hoi_dong");

            migrationBuilder.DropTable(
                name: "loai_muc_do_danh_gia");

            migrationBuilder.DropTable(
                name: "benh_nhan");

            migrationBuilder.DropTable(
                name: "loai_khao_sat");
        }
    }
}
