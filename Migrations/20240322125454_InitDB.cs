using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLPreschool.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GIAO VIEN",
                columns: table => new
                {
                    MA_GV = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TEN_GV = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CHUC_VU = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    MATKHAU_GV = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SDT_GV = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIAO VIEN", x => x.MA_GV)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "HOC_KY_NAM_HOC",
                columns: table => new
                {
                    HOC_KY = table.Column<int>(type: "int", nullable: false),
                    NAM_HOC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOC_KY_NAM_HOC", x => new { x.HOC_KY, x.NAM_HOC })
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "LOAI_LOP",
                columns: table => new
                {
                    MA_LOAI = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TEN_LOAI = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    DO_TUOI_BAT_DAU = table.Column<int>(type: "int", nullable: false),
                    DO_TUOI_KET_THUC = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAI_LOP", x => x.MA_LOAI)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "MON HOC",
                columns: table => new
                {
                    MA_MON = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TEN_MON = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MON HOC", x => x.MA_MON)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "PHONG HOC",
                columns: table => new
                {
                    MA_PHONG = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TEN_PHONG = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    SUC_CHUA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHONG HOC", x => x.MA_PHONG)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "PHU HUYNH",
                columns: table => new
                {
                    MA_PH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TEN_PH = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MATKHAU_PH = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SDT_PHUHUYNH = table.Column<int>(type: "int", nullable: false),
                    DIA_CHI_PH = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHU HUYNH", x => x.MA_PH)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "THOI GIAN",
                columns: table => new
                {
                    Thang = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    Nam = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THOI GIAN", x => new { x.Thang, x.Nam })
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "co_mon_hoc",
                columns: table => new
                {
                    MA_MON = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MA_LOAI = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CO_MON_HOC", x => new { x.MA_MON, x.MA_LOAI });
                    table.ForeignKey(
                        name: "FK_CO_MON_H_CO_MON_HO_LOAI_LOP",
                        column: x => x.MA_LOAI,
                        principalTable: "LOAI_LOP",
                        principalColumn: "MA_LOAI");
                    table.ForeignKey(
                        name: "FK_CO_MON_H_CO_MON_HO_MON HOC",
                        column: x => x.MA_MON,
                        principalTable: "MON HOC",
                        principalColumn: "MA_MON");
                });

            migrationBuilder.CreateTable(
                name: "LOP",
                columns: table => new
                {
                    MA_LOP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MA_LOAI = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MA_PHONG = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TEN_LOP = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    SI_SO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOP", x => x.MA_LOP)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_LOP_CO_LOAI_L_LOAI_LOP",
                        column: x => x.MA_LOAI,
                        principalTable: "LOAI_LOP",
                        principalColumn: "MA_LOAI");
                    table.ForeignKey(
                        name: "FK_LOP_HOC_TAI_PHONG HO",
                        column: x => x.MA_PHONG,
                        principalTable: "PHONG HOC",
                        principalColumn: "MA_PHONG");
                });

            migrationBuilder.CreateTable(
                name: "TRE EM",
                columns: table => new
                {
                    MA_TE = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MA_PH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TEN_TE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NAM_SINH_TE = table.Column<int>(type: "int", nullable: false),
                    GIOI_TINH = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRE EM", x => x.MA_TE)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_TRE EM_LA_PH_PHU HUYN",
                        column: x => x.MA_PH,
                        principalTable: "PHU HUYNH",
                        principalColumn: "MA_PH");
                });

            migrationBuilder.CreateTable(
                name: "GIANG DAY",
                columns: table => new
                {
                    HOC_KY = table.Column<int>(type: "int", nullable: false),
                    NAM_HOC = table.Column<int>(type: "int", nullable: false),
                    MA_GV = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MA_LOP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIANG DAY", x => new { x.HOC_KY, x.NAM_HOC, x.MA_GV, x.MA_LOP });
                    table.ForeignKey(
                        name: "FK_GIANG DA_DAY_O_HOC_HOC_KY_N",
                        columns: x => new { x.HOC_KY, x.NAM_HOC },
                        principalTable: "HOC_KY_NAM_HOC",
                        principalColumns: new[] { "HOC_KY", "NAM_HOC" });
                    table.ForeignKey(
                        name: "FK_GIANG DA_GIANG_DAY_LOP",
                        column: x => x.MA_LOP,
                        principalTable: "LOP",
                        principalColumn: "MA_LOP");
                    table.ForeignKey(
                        name: "FK_GIANG DA_GIAO_VIEN_GIAO VIE",
                        column: x => x.MA_GV,
                        principalTable: "GIAO VIEN",
                        principalColumn: "MA_GV");
                });

            migrationBuilder.CreateTable(
                name: "hoc_lop",
                columns: table => new
                {
                    MA_LOP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MA_TE = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOC_LOP", x => new { x.MA_LOP, x.MA_TE });
                    table.ForeignKey(
                        name: "FK_HOC_LOP_HOC_LOP2_TRE EM",
                        column: x => x.MA_TE,
                        principalTable: "TRE EM",
                        principalColumn: "MA_TE");
                    table.ForeignKey(
                        name: "FK_HOC_LOP_HOC_LOP_LOP",
                        column: x => x.MA_LOP,
                        principalTable: "LOP",
                        principalColumn: "MA_LOP");
                });

            migrationBuilder.CreateTable(
                name: "PHIEU LIEN LAC",
                columns: table => new
                {
                    MA_TE = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Thang = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    Nam = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    Loi_Nhan_Xet = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHIEU LIEN LAC", x => new { x.MA_TE, x.Thang, x.Nam });
                    table.ForeignKey(
                        name: "FK_PHIEU LI_CO_PHIEU__TRE EM",
                        column: x => x.MA_TE,
                        principalTable: "TRE EM",
                        principalColumn: "MA_TE");
                    table.ForeignKey(
                        name: "FK_PHIEU LI_PHIEU_LIE_THOI GIA",
                        columns: x => new { x.Thang, x.Nam },
                        principalTable: "THOI GIAN",
                        principalColumns: new[] { "Thang", "Nam" });
                });

            migrationBuilder.CreateTable(
                name: "THE TRANG",
                columns: table => new
                {
                    MA_TE = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Thang = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    Nam = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    Chieu_cao = table.Column<double>(type: "float", nullable: false),
                    Can_nang = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THE TRANG", x => new { x.MA_TE, x.Thang, x.Nam });
                    table.ForeignKey(
                        name: "FK_THE TRAN_CO_THE_TR_TRE EM",
                        column: x => x.MA_TE,
                        principalTable: "TRE EM",
                        principalColumn: "MA_TE");
                    table.ForeignKey(
                        name: "FK_THE TRAN_THE_TRANG_THOI GIA",
                        columns: x => new { x.Thang, x.Nam },
                        principalTable: "THOI GIAN",
                        principalColumns: new[] { "Thang", "Nam" });
                });

            migrationBuilder.CreateIndex(
                name: "CO_MON_HOC_FK",
                table: "co_mon_hoc",
                column: "MA_MON");

            migrationBuilder.CreateIndex(
                name: "CO_MON_HOC2_FK",
                table: "co_mon_hoc",
                column: "MA_LOAI");

            migrationBuilder.CreateIndex(
                name: "DAY_O_HOC_KY_FK",
                table: "GIANG DAY",
                columns: new[] { "HOC_KY", "NAM_HOC" });

            migrationBuilder.CreateIndex(
                name: "GIANG_DAY_O_LOP_FK",
                table: "GIANG DAY",
                column: "MA_LOP");

            migrationBuilder.CreateIndex(
                name: "GIAO_VIEN_GIANG_DAY_FK",
                table: "GIANG DAY",
                column: "MA_GV");

            migrationBuilder.CreateIndex(
                name: "HOC_LOP_FK",
                table: "hoc_lop",
                column: "MA_LOP");

            migrationBuilder.CreateIndex(
                name: "HOC_LOP2_FK",
                table: "hoc_lop",
                column: "MA_TE");

            migrationBuilder.CreateIndex(
                name: "CO_LOAI_LOP_FK",
                table: "LOP",
                column: "MA_LOAI");

            migrationBuilder.CreateIndex(
                name: "HOC_TAI_FK",
                table: "LOP",
                column: "MA_PHONG");

            migrationBuilder.CreateIndex(
                name: "CO_PHIEU_LIEN_LAC_FK",
                table: "PHIEU LIEN LAC",
                column: "MA_TE");

            migrationBuilder.CreateIndex(
                name: "PHIEU_LIEN_LAC_O_THANG_FK",
                table: "PHIEU LIEN LAC",
                columns: new[] { "Thang", "Nam" });

            migrationBuilder.CreateIndex(
                name: "CO_THE_TRANG_FK",
                table: "THE TRANG",
                column: "MA_TE");

            migrationBuilder.CreateIndex(
                name: "THE_TRANG_TAI_THOI_GIAN_FK",
                table: "THE TRANG",
                columns: new[] { "Thang", "Nam" });

            migrationBuilder.CreateIndex(
                name: "LA_PHU_HUYNH_FK",
                table: "TRE EM",
                column: "MA_PH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "co_mon_hoc");

            migrationBuilder.DropTable(
                name: "GIANG DAY");

            migrationBuilder.DropTable(
                name: "hoc_lop");

            migrationBuilder.DropTable(
                name: "PHIEU LIEN LAC");

            migrationBuilder.DropTable(
                name: "THE TRANG");

            migrationBuilder.DropTable(
                name: "MON HOC");

            migrationBuilder.DropTable(
                name: "HOC_KY_NAM_HOC");

            migrationBuilder.DropTable(
                name: "GIAO VIEN");

            migrationBuilder.DropTable(
                name: "LOP");

            migrationBuilder.DropTable(
                name: "TRE EM");

            migrationBuilder.DropTable(
                name: "THOI GIAN");

            migrationBuilder.DropTable(
                name: "LOAI_LOP");

            migrationBuilder.DropTable(
                name: "PHONG HOC");

            migrationBuilder.DropTable(
                name: "PHU HUYNH");
        }
    }
}
