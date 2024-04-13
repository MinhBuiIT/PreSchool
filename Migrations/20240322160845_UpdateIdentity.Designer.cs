﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLPreschool.Data;

#nullable disable

namespace QLPreschool.Migrations
{
    [DbContext(typeof(QlTMnContext))]
    [Migration("20240322160845_UpdateIdentity")]
    partial class UpdateIdentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoMonHoc", b =>
                {
                    b.Property<string>("MaMon")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_MON");

                    b.Property<string>("MaLoai")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_LOAI");

                    b.HasKey("MaMon", "MaLoai")
                        .HasName("PK_CO_MON_HOC");

                    b.HasIndex(new[] { "MaLoai" }, "CO_MON_HOC2_FK");

                    b.HasIndex(new[] { "MaMon" }, "CO_MON_HOC_FK");

                    b.ToTable("co_mon_hoc", (string)null);
                });

            modelBuilder.Entity("HocLop", b =>
                {
                    b.Property<string>("MaLop")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_LOP");

                    b.Property<string>("MaTe")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_TE");

                    b.HasKey("MaLop", "MaTe")
                        .HasName("PK_HOC_LOP");

                    b.HasIndex(new[] { "MaTe" }, "HOC_LOP2_FK");

                    b.HasIndex(new[] { "MaLop" }, "HOC_LOP_FK");

                    b.ToTable("hoc_lop", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("QLPreschool.Data.GiangDay", b =>
                {
                    b.Property<int>("HocKy")
                        .HasColumnType("int")
                        .HasColumnName("HOC_KY");

                    b.Property<int>("NamHoc")
                        .HasColumnType("int")
                        .HasColumnName("NAM_HOC");

                    b.Property<string>("MaGv")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_GV");

                    b.Property<string>("MaLop")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_LOP");

                    b.HasKey("HocKy", "NamHoc", "MaGv", "MaLop");

                    b.HasIndex(new[] { "HocKy", "NamHoc" }, "DAY_O_HOC_KY_FK");

                    b.HasIndex(new[] { "MaLop" }, "GIANG_DAY_O_LOP_FK");

                    b.HasIndex(new[] { "MaGv" }, "GIAO_VIEN_GIANG_DAY_FK");

                    b.ToTable("GIANG DAY", (string)null);
                });

            modelBuilder.Entity("QLPreschool.Data.GiaoVien", b =>
                {
                    b.Property<string>("MaGv")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_GV");

                    b.Property<string>("ChucVu")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("CHUC_VU");

                    b.Property<string>("MatkhauGv")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MATKHAU_GV");

                    b.Property<int>("SdtGv")
                        .HasColumnType("int")
                        .HasColumnName("SDT_GV");

                    b.Property<string>("TenGv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TEN_GV");

                    b.HasKey("MaGv");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("MaGv"), false);

                    b.ToTable("GIAO VIEN", (string)null);
                });

            modelBuilder.Entity("QLPreschool.Data.HocKyNamHoc", b =>
                {
                    b.Property<int>("HocKy")
                        .HasColumnType("int")
                        .HasColumnName("HOC_KY");

                    b.Property<int>("NamHoc")
                        .HasColumnType("int")
                        .HasColumnName("NAM_HOC");

                    b.HasKey("HocKy", "NamHoc");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("HocKy", "NamHoc"), false);

                    b.ToTable("HOC_KY_NAM_HOC", (string)null);
                });

            modelBuilder.Entity("QLPreschool.Data.LoaiLop", b =>
                {
                    b.Property<string>("MaLoai")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_LOAI");

                    b.Property<int>("DoTuoiBatDau")
                        .HasColumnType("int")
                        .HasColumnName("DO_TUOI_BAT_DAU");

                    b.Property<int?>("DoTuoiKetThuc")
                        .HasColumnType("int")
                        .HasColumnName("DO_TUOI_KET_THUC");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("TEN_LOAI");

                    b.HasKey("MaLoai");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("MaLoai"), false);

                    b.ToTable("LOAI_LOP", (string)null);
                });

            modelBuilder.Entity("QLPreschool.Data.Lop", b =>
                {
                    b.Property<string>("MaLop")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_LOP");

                    b.Property<string>("MaLoai")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_LOAI");

                    b.Property<string>("MaPhong")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_PHONG");

                    b.Property<int>("SiSo")
                        .HasColumnType("int")
                        .HasColumnName("SI_SO");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("TEN_LOP");

                    b.HasKey("MaLop");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("MaLop"), false);

                    b.HasIndex(new[] { "MaLoai" }, "CO_LOAI_LOP_FK");

                    b.HasIndex(new[] { "MaPhong" }, "HOC_TAI_FK");

                    b.ToTable("LOP", (string)null);
                });

            modelBuilder.Entity("QLPreschool.Data.MonHoc", b =>
                {
                    b.Property<string>("MaMon")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_MON");

                    b.Property<string>("TenMon")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("TEN_MON");

                    b.HasKey("MaMon");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("MaMon"), false);

                    b.ToTable("MON HOC", (string)null);
                });

            modelBuilder.Entity("QLPreschool.Data.PhieuLienLac", b =>
                {
                    b.Property<string>("MaTe")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_TE");

                    b.Property<string>("Thang")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength();

                    b.Property<string>("Nam")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength();

                    b.Property<string>("LoiNhanXet")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Loi_Nhan_Xet");

                    b.HasKey("MaTe", "Thang", "Nam");

                    b.HasIndex(new[] { "MaTe" }, "CO_PHIEU_LIEN_LAC_FK");

                    b.HasIndex(new[] { "Thang", "Nam" }, "PHIEU_LIEN_LAC_O_THANG_FK");

                    b.ToTable("PHIEU LIEN LAC", (string)null);
                });

            modelBuilder.Entity("QLPreschool.Data.PhongHoc", b =>
                {
                    b.Property<string>("MaPhong")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_PHONG");

                    b.Property<int>("SucChua")
                        .HasColumnType("int")
                        .HasColumnName("SUC_CHUA");

                    b.Property<string>("TenPhong")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("TEN_PHONG");

                    b.HasKey("MaPhong");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("MaPhong"), false);

                    b.ToTable("PHONG HOC", (string)null);
                });

            modelBuilder.Entity("QLPreschool.Data.PhuHuynh", b =>
                {
                    b.Property<string>("MaPh")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_PH");

                    b.Property<string>("DiaChiPh")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("DIA_CHI_PH");

                    b.Property<string>("MatkhauPh")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("MATKHAU_PH");

                    b.Property<int>("SdtPhuhuynh")
                        .HasColumnType("int")
                        .HasColumnName("SDT_PHUHUYNH");

                    b.Property<string>("TenPh")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TEN_PH");

                    b.HasKey("MaPh");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("MaPh"), false);

                    b.ToTable("PHU HUYNH", (string)null);
                });

            modelBuilder.Entity("QLPreschool.Data.TheTrang", b =>
                {
                    b.Property<string>("MaTe")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_TE");

                    b.Property<string>("Thang")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength();

                    b.Property<string>("Nam")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength();

                    b.Property<double>("CanNang")
                        .HasColumnType("float")
                        .HasColumnName("Can_nang");

                    b.Property<double>("ChieuCao")
                        .HasColumnType("float")
                        .HasColumnName("Chieu_cao");

                    b.HasKey("MaTe", "Thang", "Nam");

                    b.HasIndex(new[] { "MaTe" }, "CO_THE_TRANG_FK");

                    b.HasIndex(new[] { "Thang", "Nam" }, "THE_TRANG_TAI_THOI_GIAN_FK");

                    b.ToTable("THE TRANG", (string)null);
                });

            modelBuilder.Entity("QLPreschool.Data.ThoiGian", b =>
                {
                    b.Property<string>("Thang")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength();

                    b.Property<string>("Nam")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength();

                    b.HasKey("Thang", "Nam");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Thang", "Nam"), false);

                    b.ToTable("THOI GIAN", (string)null);
                });

            modelBuilder.Entity("QLPreschool.Data.TreEm", b =>
                {
                    b.Property<string>("MaTe")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_TE");

                    b.Property<bool?>("GioiTinh")
                        .HasColumnType("bit")
                        .HasColumnName("GIOI_TINH");

                    b.Property<string>("MaPh")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("MA_PH");

                    b.Property<int>("NamSinhTe")
                        .HasColumnType("int")
                        .HasColumnName("NAM_SINH_TE");

                    b.Property<string>("TenTe")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TEN_TE");

                    b.HasKey("MaTe");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("MaTe"), false);

                    b.HasIndex(new[] { "MaPh" }, "LA_PHU_HUYNH_FK");

                    b.ToTable("TRE EM", (string)null);
                });

            modelBuilder.Entity("QLPreschool.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("maGV")
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.Property<string>("maPH")
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("maGV")
                        .IsUnique()
                        .HasFilter("[maGV] IS NOT NULL");

                    b.HasIndex("maPH")
                        .IsUnique()
                        .HasFilter("[maPH] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("CoMonHoc", b =>
                {
                    b.HasOne("QLPreschool.Data.LoaiLop", null)
                        .WithMany()
                        .HasForeignKey("MaLoai")
                        .IsRequired()
                        .HasConstraintName("FK_CO_MON_H_CO_MON_HO_LOAI_LOP");

                    b.HasOne("QLPreschool.Data.MonHoc", null)
                        .WithMany()
                        .HasForeignKey("MaMon")
                        .IsRequired()
                        .HasConstraintName("FK_CO_MON_H_CO_MON_HO_MON HOC");
                });

            modelBuilder.Entity("HocLop", b =>
                {
                    b.HasOne("QLPreschool.Data.Lop", null)
                        .WithMany()
                        .HasForeignKey("MaLop")
                        .IsRequired()
                        .HasConstraintName("FK_HOC_LOP_HOC_LOP_LOP");

                    b.HasOne("QLPreschool.Data.TreEm", null)
                        .WithMany()
                        .HasForeignKey("MaTe")
                        .IsRequired()
                        .HasConstraintName("FK_HOC_LOP_HOC_LOP2_TRE EM");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("QLPreschool.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QLPreschool.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPreschool.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("QLPreschool.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLPreschool.Data.GiangDay", b =>
                {
                    b.HasOne("QLPreschool.Data.GiaoVien", "MaGvNavigation")
                        .WithMany("GiangDays")
                        .HasForeignKey("MaGv")
                        .IsRequired()
                        .HasConstraintName("FK_GIANG DA_GIAO_VIEN_GIAO VIE");

                    b.HasOne("QLPreschool.Data.Lop", "MaLopNavigation")
                        .WithMany("GiangDays")
                        .HasForeignKey("MaLop")
                        .IsRequired()
                        .HasConstraintName("FK_GIANG DA_GIANG_DAY_LOP");

                    b.HasOne("QLPreschool.Data.HocKyNamHoc", "HocKyNamHoc")
                        .WithMany("GiangDays")
                        .HasForeignKey("HocKy", "NamHoc")
                        .IsRequired()
                        .HasConstraintName("FK_GIANG DA_DAY_O_HOC_HOC_KY_N");

                    b.Navigation("HocKyNamHoc");

                    b.Navigation("MaGvNavigation");

                    b.Navigation("MaLopNavigation");
                });

            modelBuilder.Entity("QLPreschool.Data.Lop", b =>
                {
                    b.HasOne("QLPreschool.Data.LoaiLop", "MaLoaiNavigation")
                        .WithMany("Lops")
                        .HasForeignKey("MaLoai")
                        .IsRequired()
                        .HasConstraintName("FK_LOP_CO_LOAI_L_LOAI_LOP");

                    b.HasOne("QLPreschool.Data.PhongHoc", "MaPhongNavigation")
                        .WithMany("Lops")
                        .HasForeignKey("MaPhong")
                        .IsRequired()
                        .HasConstraintName("FK_LOP_HOC_TAI_PHONG HO");

                    b.Navigation("MaLoaiNavigation");

                    b.Navigation("MaPhongNavigation");
                });

            modelBuilder.Entity("QLPreschool.Data.PhieuLienLac", b =>
                {
                    b.HasOne("QLPreschool.Data.TreEm", "MaTeNavigation")
                        .WithMany("PhieuLienLacs")
                        .HasForeignKey("MaTe")
                        .IsRequired()
                        .HasConstraintName("FK_PHIEU LI_CO_PHIEU__TRE EM");

                    b.HasOne("QLPreschool.Data.ThoiGian", "ThoiGian")
                        .WithMany("PhieuLienLacs")
                        .HasForeignKey("Thang", "Nam")
                        .IsRequired()
                        .HasConstraintName("FK_PHIEU LI_PHIEU_LIE_THOI GIA");

                    b.Navigation("MaTeNavigation");

                    b.Navigation("ThoiGian");
                });

            modelBuilder.Entity("QLPreschool.Data.TheTrang", b =>
                {
                    b.HasOne("QLPreschool.Data.TreEm", "MaTeNavigation")
                        .WithMany("TheTrangs")
                        .HasForeignKey("MaTe")
                        .IsRequired()
                        .HasConstraintName("FK_THE TRAN_CO_THE_TR_TRE EM");

                    b.HasOne("QLPreschool.Data.ThoiGian", "ThoiGian")
                        .WithMany("TheTrangs")
                        .HasForeignKey("Thang", "Nam")
                        .IsRequired()
                        .HasConstraintName("FK_THE TRAN_THE_TRANG_THOI GIA");

                    b.Navigation("MaTeNavigation");

                    b.Navigation("ThoiGian");
                });

            modelBuilder.Entity("QLPreschool.Data.TreEm", b =>
                {
                    b.HasOne("QLPreschool.Data.PhuHuynh", "MaPhNavigation")
                        .WithMany("TreEms")
                        .HasForeignKey("MaPh")
                        .IsRequired()
                        .HasConstraintName("FK_TRE EM_LA_PH_PHU HUYN");

                    b.Navigation("MaPhNavigation");
                });

            modelBuilder.Entity("QLPreschool.Models.AppUser", b =>
                {
                    b.HasOne("QLPreschool.Data.GiaoVien", "GiaoVien")
                        .WithOne("User")
                        .HasForeignKey("QLPreschool.Models.AppUser", "maGV")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QLPreschool.Data.PhuHuynh", "PhuHuynh")
                        .WithOne("User")
                        .HasForeignKey("QLPreschool.Models.AppUser", "maPH")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("GiaoVien");

                    b.Navigation("PhuHuynh");
                });

            modelBuilder.Entity("QLPreschool.Data.GiaoVien", b =>
                {
                    b.Navigation("GiangDays");

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("QLPreschool.Data.HocKyNamHoc", b =>
                {
                    b.Navigation("GiangDays");
                });

            modelBuilder.Entity("QLPreschool.Data.LoaiLop", b =>
                {
                    b.Navigation("Lops");
                });

            modelBuilder.Entity("QLPreschool.Data.Lop", b =>
                {
                    b.Navigation("GiangDays");
                });

            modelBuilder.Entity("QLPreschool.Data.PhongHoc", b =>
                {
                    b.Navigation("Lops");
                });

            modelBuilder.Entity("QLPreschool.Data.PhuHuynh", b =>
                {
                    b.Navigation("TreEms");

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("QLPreschool.Data.ThoiGian", b =>
                {
                    b.Navigation("PhieuLienLacs");

                    b.Navigation("TheTrangs");
                });

            modelBuilder.Entity("QLPreschool.Data.TreEm", b =>
                {
                    b.Navigation("PhieuLienLacs");

                    b.Navigation("TheTrangs");
                });
#pragma warning restore 612, 618
        }
    }
}
