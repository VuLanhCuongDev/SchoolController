using Microsoft.EntityFrameworkCore;

namespace SchoolController.Models
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CanBoDaoTao> CanBoDaoTaos { get; set; } = null!;
        public virtual DbSet<ChuyenNganh> ChuyenNganhs { get; set; } = null!;
        public virtual DbSet<DiemSo> DiemSos { get; set; } = null!;
        public virtual DbSet<GiangVien> GiangViens { get; set; } = null!;
        public virtual DbSet<GiangVienMonHoc> GiangVienMonHocs { get; set; } = null!;
        public virtual DbSet<Lop> Lops { get; set; } = null!;
        public virtual DbSet<MonHoc> MonHocs { get; set; } = null!;
        public virtual DbSet<PhuHuynh> PhuHuynhs { get; set; } = null!;
        public virtual DbSet<SinhVien> SinhViens { get; set; } = null!;
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                _ = optionsBuilder.UseSqlServer("Server=ACER\\SQLEXPRESS;Initial Catalog= School ;Persist Security Info=True;User ID=sa;Password=191023");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<CanBoDaoTao>(entity =>
            {
                _ = entity.HasKey(e => e.MaCanBoDaoTao)
                    .HasName("PK__CanBoDao__FE8E73BB7C1B2D7E");

                _ = entity.ToTable("CanBoDaoTao");

                _ = entity.Property(e => e.MaCanBoDaoTao)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.Property(e => e.NgaySinh).HasColumnType("date");

                _ = entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.Property(e => e.TenCanBoDaoTao).HasMaxLength(50);

                _ = entity.Property(e => e.TenTaiKhoan)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            _ = modelBuilder.Entity<ChuyenNganh>(entity =>
            {
                _ = entity.HasKey(e => e.MaChuyenNganh)
                    .HasName("PK__ChuyenNg__20FEA98DC91055B3");

                _ = entity.ToTable("ChuyenNganh");

                _ = entity.Property(e => e.MaChuyenNganh)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.Property(e => e.TenChuyenNganh).HasMaxLength(50);

                _ = entity.HasMany(d => d.MaMonHocs)
                    .WithMany(p => p.MaChuyenNganhs)
                    .UsingEntity<Dictionary<string, object>>(
                        "ChuyenNganhMonHoc",
                        l => l.HasOne<MonHoc>().WithMany().HasForeignKey("MaMonHoc").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MonHoc_ChuyenNganh-MonHoc"),
                        r => r.HasOne<ChuyenNganh>().WithMany().HasForeignKey("MaChuyenNganh").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ChuyenNganh_ChuyenNganh-MonHoc"),
                        j =>
                        {
                            _ = j.HasKey("MaChuyenNganh", "MaMonHoc").HasName("PK__ChuyenNg__C4ECDEBA686552D9");

                            _ = j.ToTable("ChuyenNganh-MonHoc");

                            _ = j.IndexerProperty<string>("MaChuyenNganh").HasMaxLength(10).IsUnicode(false);

                            _ = j.IndexerProperty<string>("MaMonHoc").HasMaxLength(10).IsUnicode(false);
                        });
            });

            _ = modelBuilder.Entity<DiemSo>(entity =>
            {
                _ = entity.HasKey(e => new { e.MaSinhVien, e.MaMonHoc })
                    .HasName("PK__DiemSo__7788904241170C8D");

                _ = entity.ToTable("DiemSo");

                _ = entity.Property(e => e.MaSinhVien)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.Property(e => e.MaMonHoc)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.Property(e => e.MaGiangVien)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.Property(e => e.MaLop)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.HasOne(d => d.MaGiangVienNavigation)
                    .WithMany(p => p.DiemSos)
                    .HasForeignKey(d => d.MaGiangVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GiangVien_DiemSo");

                _ = entity.HasOne(d => d.MaLopNavigation)
                    .WithMany(p => p.DiemSos)
                    .HasForeignKey(d => d.MaLop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lop_DiemSo");

                _ = entity.HasOne(d => d.MaMonHocNavigation)
                    .WithMany(p => p.DiemSos)
                    .HasForeignKey(d => d.MaMonHoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MonHoc_DiemSo");

                _ = entity.HasOne(d => d.MaSinhVienNavigation)
                    .WithMany(p => p.DiemSos)
                    .HasForeignKey(d => d.MaSinhVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SinhVien_DiemSo");
            });

            _ = modelBuilder.Entity<GiangVien>(entity =>
            {
                _ = entity.HasKey(e => e.MaGiangVien)
                    .HasName("PK__GiangVie__C03BEEBAE2407F02");

                _ = entity.ToTable("GiangVien");

                _ = entity.Property(e => e.MaGiangVien)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.Property(e => e.NgaySinh).HasColumnType("date");

                _ = entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.Property(e => e.TenGiangVien).HasMaxLength(50);

                _ = entity.Property(e => e.TenTaiKhoan)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            _ = modelBuilder.Entity<GiangVienMonHoc>(entity =>
            {
                _ = entity.HasKey(e => new { e.MaGiangVien, e.MaMonHoc })
                    .HasName("PK__GiangVie__2429998D4AC1E0C5");

                _ = entity.ToTable("GiangVien-MonHoc");

                _ = entity.Property(e => e.MaGiangVien)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.Property(e => e.MaMonHoc)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.HasOne(d => d.MaGiangVienNavigation)
                    .WithMany(p => p.GiangVienMonHocs)
                    .HasForeignKey(d => d.MaGiangVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GiangVien_GiangVien-MonHoc");

                _ = entity.HasOne(d => d.MaMonHocNavigation)
                    .WithMany(p => p.GiangVienMonHocs)
                    .HasForeignKey(d => d.MaMonHoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MonHoc_GiangVien-MonHoc");
            });

            _ = modelBuilder.Entity<Lop>(entity =>
            {
                _ = entity.HasKey(e => e.MaLop)
                    .HasName("PK__Lop__3B98D27384FCF829");

                _ = entity.ToTable("Lop");

                _ = entity.Property(e => e.MaLop)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            _ = modelBuilder.Entity<MonHoc>(entity =>
            {
                _ = entity.HasKey(e => e.MaMonHoc)
                    .HasName("PK__MonHoc__4127737FA7C147F0");

                _ = entity.ToTable("MonHoc");

                _ = entity.Property(e => e.MaMonHoc)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.Property(e => e.TenMonHoc).HasMaxLength(50);
            });

            _ = modelBuilder.Entity<PhuHuynh>(entity =>
            {
                _ = entity.HasKey(e => e.MaPhuHuynh)
                    .HasName("PK__PhuHuynh__D53239A76EF5C06F");

                _ = entity.ToTable("PhuHuynh");

                _ = entity.Property(e => e.MaPhuHuynh)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.Property(e => e.NgaySinh).HasColumnType("date");

                _ = entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.Property(e => e.TenPhuHuynh).HasMaxLength(50);

                _ = entity.Property(e => e.TenTaiKhoan)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            _ = modelBuilder.Entity<SinhVien>(entity =>
            {
                _ = entity.HasKey(e => e.MaSinhVien)
                    .HasName("PK__SinhVien__939AE7753627B8E0");

                _ = entity.ToTable("SinhVien");

                _ = entity.Property(e => e.MaSinhVien)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.Property(e => e.MaPhuHuynh)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.Property(e => e.NgaySinh).HasColumnType("date");

                _ = entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                _ = entity.Property(e => e.TenSinhVien).HasMaxLength(50);

                _ = entity.Property(e => e.TenTaiKhoan)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                _ = entity.HasOne(d => d.MaPhuHuynhNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.MaPhuHuynh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhuHuynh_SinhVien");
            });

            _ = modelBuilder.Entity<TaiKhoan>(entity =>
            {
                _ = entity.HasKey(e => e.TenTaiKhoan)
                    .HasName("PK__TaiKhoan__B106EAF93AD4A02A");

                _ = entity.ToTable("TaiKhoan");

                _ = entity.Property(e => e.TenTaiKhoan)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                _ = entity.Property(e => e.MatKhau)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
