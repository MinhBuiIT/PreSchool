using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLPreschool.Models;

namespace QLPreschool.Data;

public partial class QlTMnContext : IdentityDbContext<AppUser>
{
    public QlTMnContext()
    {
    }

    public QlTMnContext(DbContextOptions<QlTMnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GiangDay> GiangDays { get; set; }

    public virtual DbSet<GiaoVien> GiaoViens { get; set; }

    public virtual DbSet<HocKyNamHoc> HocKyNamHocs { get; set; }

    public virtual DbSet<LoaiLop> LoaiLops { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<MonHoc> MonHocs { get; set; }

    public virtual DbSet<PhieuLienLac> PhieuLienLacs { get; set; }

    public virtual DbSet<PhongHoc> PhongHocs { get; set; }

    public virtual DbSet<PhuHuynh> PhuHuynhs { get; set; }

    public virtual DbSet<TheTrang> TheTrangs { get; set; }

    public virtual DbSet<ThoiGian> ThoiGians { get; set; }

    public virtual DbSet<TreEm> TreEms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MinhBui;Initial Catalog=QL_T_MN;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
        modelBuilder.Entity<GiaoVien>()
                   .HasOne(e => e.User)
                   .WithOne(e => e.GiaoVien)
                   .HasForeignKey<AppUser>(u => u.maGV).IsRequired().OnDelete(DeleteBehavior.Cascade).IsRequired(false);
        modelBuilder.Entity<PhuHuynh>()
                   .HasOne(e => e.User)
                   .WithOne(e => e.PhuHuynh)
                   .HasForeignKey<AppUser>(u => u.maPH).IsRequired().OnDelete(DeleteBehavior.Cascade).IsRequired(false);
        modelBuilder.Entity<GiangDay>(entity =>
        {
            entity.HasKey(e => new { e.HocKy, e.NamHoc, e.MaGv, e.MaLop });

            entity.ToTable("GIANG DAY");

            entity.HasIndex(e => new { e.HocKy, e.NamHoc }, "DAY_O_HOC_KY_FK");

            entity.HasIndex(e => e.MaLop, "GIANG_DAY_O_LOP_FK");

            entity.HasIndex(e => e.MaGv, "GIAO_VIEN_GIANG_DAY_FK");

            entity.Property(e => e.HocKy).HasColumnName("HOC_KY");
            entity.Property(e => e.NamHoc).HasColumnName("NAM_HOC");
            entity.Property(e => e.MaGv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MA_GV");
            entity.Property(e => e.MaLop)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MA_LOP");

            entity.HasOne(d => d.MaGvNavigation).WithMany(p => p.GiangDays)
                .HasForeignKey(d => d.MaGv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GIANG DA_GIAO_VIEN_GIAO VIE");

            entity.HasOne(d => d.MaLopNavigation).WithMany(p => p.GiangDays)
                .HasForeignKey(d => d.MaLop)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GIANG DA_GIANG_DAY_LOP");

            entity.HasOne(d => d.HocKyNamHoc).WithMany(p => p.GiangDays)
                .HasForeignKey(d => new { d.HocKy, d.NamHoc })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GIANG DA_DAY_O_HOC_HOC_KY_N");
        });

        modelBuilder.Entity<GiaoVien>(entity =>
        {
            entity.HasKey(e => e.MaGv).IsClustered(false);

            entity.ToTable("GIAO VIEN");

            entity.Property(e => e.MaGv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MA_GV");
            entity.Property(e => e.ChucVu)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CHUC_VU");
            entity.Property(e => e.SdtGv).HasColumnName("SDT_GV");
            entity.Property(e => e.TenGv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TEN_GV");
        });

        modelBuilder.Entity<HocKyNamHoc>(entity =>
        {
            entity.HasKey(e => new { e.HocKy, e.NamHoc }).IsClustered(false);

            entity.ToTable("HOC_KY_NAM_HOC");

            entity.Property(e => e.HocKy).HasColumnName("HOC_KY");
            entity.Property(e => e.NamHoc).HasColumnName("NAM_HOC");
        });

        modelBuilder.Entity<LoaiLop>(entity =>
        {
            entity.HasKey(e => e.MaLoai).IsClustered(false);

            entity.ToTable("LOAI_LOP");

            entity.Property(e => e.MaLoai)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MA_LOAI");
            entity.Property(e => e.DoTuoiBatDau).HasColumnName("DO_TUOI_BAT_DAU");
            entity.Property(e => e.DoTuoiKetThuc).HasColumnName("DO_TUOI_KET_THUC");
            entity.Property(e => e.TenLoai)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TEN_LOAI");
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.MaLop).IsClustered(false);

            entity.ToTable("LOP");

            entity.HasIndex(e => e.MaLoai, "CO_LOAI_LOP_FK");

            entity.HasIndex(e => e.MaPhong, "HOC_TAI_FK");

            entity.Property(e => e.MaLop)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MA_LOP");
            entity.Property(e => e.MaLoai)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MA_LOAI");
            entity.Property(e => e.MaPhong)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MA_PHONG");
            entity.Property(e => e.SiSo).HasColumnName("SI_SO");
            entity.Property(e => e.TenLop)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TEN_LOP");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.Lops)
                .HasForeignKey(d => d.MaLoai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LOP_CO_LOAI_L_LOAI_LOP");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.Lops)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LOP_HOC_TAI_PHONG HO");

            entity.HasMany(d => d.MaTes).WithMany(p => p.MaLops)
                .UsingEntity<Dictionary<string, object>>(
                    "HocLop",
                    r => r.HasOne<TreEm>().WithMany()
                        .HasForeignKey("MaTe")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_HOC_LOP_HOC_LOP2_TRE EM"),
                    l => l.HasOne<Lop>().WithMany()
                        .HasForeignKey("MaLop")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_HOC_LOP_HOC_LOP_LOP"),
                    j =>
                    {
                        j.HasKey("MaLop", "MaTe").HasName("PK_HOC_LOP");
                        j.ToTable("hoc_lop");
                        j.HasIndex(new[] { "MaTe" }, "HOC_LOP2_FK");
                        j.HasIndex(new[] { "MaLop" }, "HOC_LOP_FK");
                        j.IndexerProperty<string>("MaLop")
                            .HasMaxLength(10)
                            .IsUnicode(false)
                            .HasColumnName("MA_LOP");
                        j.IndexerProperty<string>("MaTe")
                            .HasMaxLength(10)
                            .IsUnicode(false)
                            .HasColumnName("MA_TE");
                    });
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.HasKey(e => e.MaMon).IsClustered(false);

            entity.ToTable("MON HOC");

            entity.Property(e => e.MaMon)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MA_MON");
            entity.Property(e => e.TenMon)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TEN_MON");

            entity.HasMany(d => d.MaLoais).WithMany(p => p.MaMons)
                .UsingEntity<Dictionary<string, object>>(
                    "CoMonHoc",
                    r => r.HasOne<LoaiLop>().WithMany()
                        .HasForeignKey("MaLoai")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CO_MON_H_CO_MON_HO_LOAI_LOP"),
                    l => l.HasOne<MonHoc>().WithMany()
                        .HasForeignKey("MaMon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CO_MON_H_CO_MON_HO_MON HOC"),
                    j =>
                    {
                        j.HasKey("MaMon", "MaLoai").HasName("PK_CO_MON_HOC");
                        j.ToTable("co_mon_hoc");
                        j.HasIndex(new[] { "MaLoai" }, "CO_MON_HOC2_FK");
                        j.HasIndex(new[] { "MaMon" }, "CO_MON_HOC_FK");
                        j.IndexerProperty<string>("MaMon")
                            .HasMaxLength(10)
                            .IsUnicode(false)
                            .HasColumnName("MA_MON");
                        j.IndexerProperty<string>("MaLoai")
                            .HasMaxLength(10)
                            .IsUnicode(false)
                            .HasColumnName("MA_LOAI");
                    });
        });

        modelBuilder.Entity<PhieuLienLac>(entity =>
        {
            entity.HasKey(e => new { e.MaTe, e.Thang, e.Nam });

            entity.ToTable("PHIEU LIEN LAC");

            entity.HasIndex(e => e.MaTe, "CO_PHIEU_LIEN_LAC_FK");

            entity.HasIndex(e => new { e.Thang, e.Nam }, "PHIEU_LIEN_LAC_O_THANG_FK");

            entity.Property(e => e.MaTe)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MA_TE");
            entity.Property(e => e.Thang)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nam)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LoiNhanXet)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Loi_Nhan_Xet");

            entity.HasOne(d => d.MaTeNavigation).WithMany(p => p.PhieuLienLacs)
                .HasForeignKey(d => d.MaTe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PHIEU LI_CO_PHIEU__TRE EM");

            entity.HasOne(d => d.ThoiGian).WithMany(p => p.PhieuLienLacs)
                .HasForeignKey(d => new { d.Thang, d.Nam })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PHIEU LI_PHIEU_LIE_THOI GIA");
        });

        modelBuilder.Entity<PhongHoc>(entity =>
        {
            entity.HasKey(e => e.MaPhong).IsClustered(false);

            entity.ToTable("PHONG HOC");

            entity.Property(e => e.MaPhong)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MA_PHONG");
            entity.Property(e => e.SucChua).HasColumnName("SUC_CHUA");
            entity.Property(e => e.TenPhong)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TEN_PHONG");
        });

        modelBuilder.Entity<PhuHuynh>(entity =>
        {
            entity.HasKey(e => e.MaPh).IsClustered(false);

            entity.ToTable("PHU HUYNH");

            entity.Property(e => e.MaPh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MA_PH");
            entity.Property(e => e.DiaChiPh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DIA_CHI_PH");
            entity.Property(e => e.SdtPhuhuynh).HasColumnName("SDT_PHUHUYNH");
            entity.Property(e => e.TenPh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TEN_PH");
        });

        modelBuilder.Entity<TheTrang>(entity =>
        {
            entity.HasKey(e => new { e.MaTe, e.Thang, e.Nam });

            entity.ToTable("THE TRANG");

            entity.HasIndex(e => e.MaTe, "CO_THE_TRANG_FK");

            entity.HasIndex(e => new { e.Thang, e.Nam }, "THE_TRANG_TAI_THOI_GIAN_FK");

            entity.Property(e => e.MaTe)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MA_TE");
            entity.Property(e => e.Thang)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nam)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CanNang).HasColumnName("Can_nang");
            entity.Property(e => e.ChieuCao).HasColumnName("Chieu_cao");

            entity.HasOne(d => d.MaTeNavigation).WithMany(p => p.TheTrangs)
                .HasForeignKey(d => d.MaTe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_THE TRAN_CO_THE_TR_TRE EM");

            entity.HasOne(d => d.ThoiGian).WithMany(p => p.TheTrangs)
                .HasForeignKey(d => new { d.Thang, d.Nam })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_THE TRAN_THE_TRANG_THOI GIA");
        });

        modelBuilder.Entity<ThoiGian>(entity =>
        {
            entity.HasKey(e => new { e.Thang, e.Nam }).IsClustered(false);

            entity.ToTable("THOI GIAN");

            entity.Property(e => e.Thang)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nam)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<TreEm>(entity =>
        {
            entity.HasKey(e => e.MaTe).IsClustered(false);

            entity.ToTable("TRE EM");

            entity.HasIndex(e => e.MaPh, "LA_PHU_HUYNH_FK");

            entity.Property(e => e.MaTe)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MA_TE");
            entity.Property(e => e.GioiTinh).HasColumnName("GIOI_TINH");
            entity.Property(e => e.MaPh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MA_PH");
            entity.Property(e => e.TenTe)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TEN_TE");

            entity.HasOne(d => d.MaPhNavigation).WithMany(p => p.TreEms)
                .HasForeignKey(d => d.MaPh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TRE EM_LA_PH_PHU HUYN");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
