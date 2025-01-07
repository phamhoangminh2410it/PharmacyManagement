using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PharmacyManagement.Models.Entities;

public partial class PharmacyManagementContext : DbContext
{
    public PharmacyManagementContext()
    {
    }

    public PharmacyManagementContext(DbContextOptions<PharmacyManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Baocaotonkho> Baocaotonkhos { get; set; }

    public virtual DbSet<Chitietphieubansanpham> Chitietphieubansanphams { get; set; }

    public virtual DbSet<Chitietphieukiemkho> Chitietphieukiemkhos { get; set; }

    public virtual DbSet<Chitietphieunhap> Chitietphieunhaps { get; set; }

    public virtual DbSet<Chitietphieuxuat> Chitietphieuxuats { get; set; }

    public virtual DbSet<Chucvu> Chucvus { get; set; }

    public virtual DbSet<Loaisanpham> Loaisanphams { get; set; }

    public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Phieubansanpham> Phieubansanphams { get; set; }

    public virtual DbSet<Phieuchi> Phieuchis { get; set; }

    public virtual DbSet<Phieudoitra> Phieudoitras { get; set; }

    public virtual DbSet<Phieukiemkho> Phieukiemkhos { get; set; }

    public virtual DbSet<Phieunhap> Phieunhaps { get; set; }

    public virtual DbSet<Phieuxuat> Phieuxuats { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    public virtual DbSet<Thamso> Thamsos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Connection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Baocaotonkho>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BAOCAOTO__3214EC2763E893C6");

            entity.ToTable("BAOCAOTONKHO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idsanpham).HasColumnName("IDSANPHAM");
            entity.Property(e => e.Ngaylap)
                .HasMaxLength(255)
                .HasColumnName("NGAYLAP");
            entity.Property(e => e.Soluongnhap).HasColumnName("SOLUONGNHAP");
            entity.Property(e => e.Soluongtoncuoi).HasColumnName("SOLUONGTONCUOI");
            entity.Property(e => e.Soluongtondau).HasColumnName("SOLUONGTONDAU");
            entity.Property(e => e.Soluongxuat).HasColumnName("SOLUONGXUAT");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Baocaotonkhos)
                .HasForeignKey(d => d.Idsanpham)
                .HasConstraintName("FK__BAOCAOTON__IDSAN__6383C8BA");
        });

        modelBuilder.Entity<Chitietphieubansanpham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CHITIETP__3214EC27A06A88F9");

            entity.ToTable("CHITIETPHIEUBANSANPHAM");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Gia).HasColumnName("GIA");
            entity.Property(e => e.Idsanpham).HasColumnName("IDSANPHAM");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Thanhtien).HasColumnName("THANHTIEN");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Chitietphieubansanphams)
                .HasForeignKey(d => d.Idsanpham)
                .HasConstraintName("FK__CHITIETPH__IDSAN__60A75C0F");
        });

        modelBuilder.Entity<Chitietphieukiemkho>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CHITIETP__3214EC27FCD051CB");

            entity.ToTable("CHITIETPHIEUKIEMKHO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idsanpham).HasColumnName("IDSANPHAM");
            entity.Property(e => e.Soluonghientai).HasColumnName("SOLUONGHIENTAI");
            entity.Property(e => e.Soluongkiemtra).HasColumnName("SOLUONGKIEMTRA");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Chitietphieukiemkhos)
                .HasForeignKey(d => d.Idsanpham)
                .HasConstraintName("FK__CHITIETPH__IDSAN__5AEE82B9");
        });

        modelBuilder.Entity<Chitietphieunhap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CHITIETP__3214EC272FCBA1A1");

            entity.ToTable("CHITIETPHIEUNHAP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Gianhap).HasColumnName("GIANHAP");
            entity.Property(e => e.Idsanpham).HasColumnName("IDSANPHAM");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Thanhtien).HasColumnName("THANHTIEN");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Chitietphieunhaps)
                .HasForeignKey(d => d.Idsanpham)
                .HasConstraintName("FK__CHITIETPH__IDSAN__5DCAEF64");
        });

        modelBuilder.Entity<Chitietphieuxuat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CHITIETP__3214EC27F255F812");

            entity.ToTable("CHITIETPHIEUXUAT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Gia).HasColumnName("GIA");
            entity.Property(e => e.Idsanpham).HasColumnName("IDSANPHAM");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Thanhtien).HasColumnName("THANHTIEN");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Chitietphieuxuats)
                .HasForeignKey(d => d.Idsanpham)
                .HasConstraintName("FK__CHITIETPH__IDSAN__5812160E");
        });

        modelBuilder.Entity<Chucvu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CHUCVU__3214EC27B998D4B3");

            entity.ToTable("CHUCVU");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Machucvu)
                .HasMaxLength(10)
                .HasColumnName("MACHUCVU");
            entity.Property(e => e.Tenchucvu)
                .HasMaxLength(255)
                .HasColumnName("TENCHUCVU");
        });

        modelBuilder.Entity<Loaisanpham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOAISANP__3214EC270C5DC23B");

            entity.ToTable("LOAISANPHAM");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Maloaisanpham)
                .HasMaxLength(10)
                .HasColumnName("MALOAISANPHAM");
            entity.Property(e => e.Phantramloinhuan).HasColumnName("PHANTRAMLOINHUAN");
            entity.Property(e => e.Tenloaisanpham)
                .HasMaxLength(255)
                .HasColumnName("TENLOAISANPHAM");
        });

        modelBuilder.Entity<Nhacungcap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NHACUNGC__3214EC278A7A29AB");

            entity.ToTable("NHACUNGCAP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Diachi)
                .HasMaxLength(255)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Manhacungcap)
                .HasMaxLength(10)
                .HasColumnName("MANHACUNGCAP");
            entity.Property(e => e.Sodienthoai)
                .HasMaxLength(20)
                .HasColumnName("SODIENTHOAI");
            entity.Property(e => e.Tennhacungcap)
                .HasMaxLength(255)
                .HasColumnName("TENNHACUNGCAP");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NHANVIEN__3214EC27D790F23E");

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasColumnName("AVATAR");
            entity.Property(e => e.Cmnd)
                .HasMaxLength(20)
                .HasColumnName("CMND");
            entity.Property(e => e.Diachi)
                .HasMaxLength(255)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Idchucvu).HasColumnName("IDCHUCVU");
            entity.Property(e => e.Manhanvien)
                .HasMaxLength(10)
                .HasColumnName("MANHANVIEN");
            entity.Property(e => e.Pass)
                .HasMaxLength(255)
                .HasColumnName("PASS");
            entity.Property(e => e.Sodienthoai)
                .HasMaxLength(20)
                .HasColumnName("SODIENTHOAI");
            entity.Property(e => e.Tennhanvien)
                .HasMaxLength(255)
                .HasColumnName("TENNHANVIEN");
            entity.Property(e => e.Trangthai).HasColumnName("TRANGTHAI");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.IdchucvuNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.Idchucvu)
                .HasConstraintName("FK__NHANVIEN__IDCHUC__398D8EEE");
        });

        modelBuilder.Entity<Phieubansanpham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PHIEUBAN__3214EC27E613BAFF");

            entity.ToTable("PHIEUBANSANPHAM");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(255)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Idnhanvien).HasColumnName("IDNHANVIEN");
            entity.Property(e => e.Ngayban)
                .HasMaxLength(255)
                .HasColumnName("NGAYBAN");
            entity.Property(e => e.Sodienthoai)
                .HasMaxLength(20)
                .HasColumnName("SODIENTHOAI");
            entity.Property(e => e.Sophieubansanpham)
                .HasMaxLength(10)
                .HasColumnName("SOPHIEUBANSANPHAM");
            entity.Property(e => e.Tenkhachhang)
                .HasMaxLength(255)
                .HasColumnName("TENKHACHHANG");
            entity.Property(e => e.Tongtien).HasColumnName("TONGTIEN");
            entity.Property(e => e.Trangthai).HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.IdnhanvienNavigation).WithMany(p => p.Phieubansanphams)
                .HasForeignKey(d => d.Idnhanvien)
                .HasConstraintName("FK__PHIEUBANS__IDNHA__5535A963");
        });

        modelBuilder.Entity<Phieuchi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PHIEUCHI__3214EC27409B8D79");

            entity.ToTable("PHIEUCHI");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(255)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Idnhanvien).HasColumnName("IDNHANVIEN");
            entity.Property(e => e.Ngaychi)
                .HasMaxLength(255)
                .HasColumnName("NGAYCHI");
            entity.Property(e => e.Sophieuchi)
                .HasMaxLength(10)
                .HasColumnName("SOPHIEUCHI");
            entity.Property(e => e.Tongtienchi).HasColumnName("TONGTIENCHI");

            entity.HasOne(d => d.IdnhanvienNavigation).WithMany(p => p.Phieuchis)
                .HasForeignKey(d => d.Idnhanvien)
                .HasConstraintName("FK__PHIEUCHI__IDNHAN__44FF419A");
        });

        modelBuilder.Entity<Phieudoitra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PHIEUDOI__3214EC2741D7FFB0");

            entity.ToTable("PHIEUDOITRA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(255)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Idnhanvien).HasColumnName("IDNHANVIEN");
            entity.Property(e => e.Idsanpham).HasColumnName("IDSANPHAM");
            entity.Property(e => e.Ngaygiao)
                .HasMaxLength(255)
                .HasColumnName("NGAYGIAO");
            entity.Property(e => e.Ngaylap)
                .HasMaxLength(255)
                .HasColumnName("NGAYLAP");
            entity.Property(e => e.Sodienthoai)
                .HasMaxLength(20)
                .HasColumnName("SODIENTHOAI");
            entity.Property(e => e.Sophieudoitra)
                .HasMaxLength(10)
                .HasColumnName("SOPHIEUDOITRA");
            entity.Property(e => e.Tennhacungcap)
                .HasMaxLength(255)
                .HasColumnName("TENNHACUNGCAP");
            entity.Property(e => e.Tongtien).HasColumnName("TONGTIEN");

            entity.HasOne(d => d.IdnhanvienNavigation).WithMany(p => p.Phieudoitras)
                .HasForeignKey(d => d.Idnhanvien)
                .HasConstraintName("FK__PHIEUDOIT__IDNHA__48CFD27E");

            entity.HasOne(d => d.IdsanphamNavigation).WithMany(p => p.Phieudoitras)
                .HasForeignKey(d => d.Idsanpham)
                .HasConstraintName("FK__PHIEUDOIT__IDSAN__47DBAE45");
        });

        modelBuilder.Entity<Phieukiemkho>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PHIEUKIE__3214EC27B0524EA5");

            entity.ToTable("PHIEUKIEMKHO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(255)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Idnhanvien).HasColumnName("IDNHANVIEN");
            entity.Property(e => e.Ngaychinhsua)
                .HasMaxLength(255)
                .HasColumnName("NGAYCHINHSUA");
            entity.Property(e => e.Ngaykiemkho)
                .HasMaxLength(255)
                .HasColumnName("NGAYKIEMKHO");
            entity.Property(e => e.Sophieukiemkho)
                .HasMaxLength(10)
                .HasColumnName("SOPHIEUKIEMKHO");
            entity.Property(e => e.Trangthai).HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.IdnhanvienNavigation).WithMany(p => p.Phieukiemkhos)
                .HasForeignKey(d => d.Idnhanvien)
                .HasConstraintName("FK__PHIEUKIEM__IDNHA__4BAC3F29");
        });

        modelBuilder.Entity<Phieunhap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PHIEUNHA__3214EC27785EBB9E");

            entity.ToTable("PHIEUNHAP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(255)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Idnhacungcap).HasColumnName("IDNHACUNGCAP");
            entity.Property(e => e.Idnhanvien).HasColumnName("IDNHANVIEN");
            entity.Property(e => e.Ngaychinhsua)
                .HasMaxLength(255)
                .HasColumnName("NGAYCHINHSUA");
            entity.Property(e => e.Ngaynhap)
                .HasMaxLength(255)
                .HasColumnName("NGAYNHAP");
            entity.Property(e => e.Sophieunhap)
                .HasMaxLength(10)
                .HasColumnName("SOPHIEUNHAP");
            entity.Property(e => e.Tongtien).HasColumnName("TONGTIEN");
            entity.Property(e => e.Trangthai).HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.IdnhacungcapNavigation).WithMany(p => p.Phieunhaps)
                .HasForeignKey(d => d.Idnhacungcap)
                .HasConstraintName("FK__PHIEUNHAP__IDNHA__4F7CD00D");

            entity.HasOne(d => d.IdnhanvienNavigation).WithMany(p => p.Phieunhaps)
                .HasForeignKey(d => d.Idnhanvien)
                .HasConstraintName("FK__PHIEUNHAP__IDNHA__4E88ABD4");
        });

        modelBuilder.Entity<Phieuxuat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PHIEUXUA__3214EC27AF8B982A");

            entity.ToTable("PHIEUXUAT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idnhanvien).HasColumnName("IDNHANVIEN");
            entity.Property(e => e.Lydoxuat)
                .HasMaxLength(255)
                .HasColumnName("LYDOXUAT");
            entity.Property(e => e.Ngaychinhsua)
                .HasMaxLength(255)
                .HasColumnName("NGAYCHINHSUA");
            entity.Property(e => e.Ngayxuat)
                .HasMaxLength(255)
                .HasColumnName("NGAYXUAT");
            entity.Property(e => e.Sophieuxuat)
                .HasMaxLength(10)
                .HasColumnName("SOPHIEUXUAT");
            entity.Property(e => e.Tongtien).HasColumnName("TONGTIEN");
            entity.Property(e => e.Trangthai).HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.IdnhanvienNavigation).WithMany(p => p.Phieuxuats)
                .HasForeignKey(d => d.Idnhanvien)
                .HasConstraintName("FK__PHIEUXUAT__IDNHA__52593CB8");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SANPHAM__3214EC27CCD0A0A1");

            entity.ToTable("SANPHAM");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Donvitinh)
                .HasMaxLength(255)
                .HasColumnName("DONVITINH");
            entity.Property(e => e.Giaban).HasColumnName("GIABAN");
            entity.Property(e => e.Giamgia).HasColumnName("GIAMGIA");
            entity.Property(e => e.Hinhanh)
                .HasMaxLength(255)
                .HasColumnName("HINHANH");
            entity.Property(e => e.Idloaisanpham).HasColumnName("IDLOAISANPHAM");
            entity.Property(e => e.Masanpham)
                .HasMaxLength(10)
                .HasColumnName("MASANPHAM");
            entity.Property(e => e.Mota)
                .HasMaxLength(255)
                .HasColumnName("MOTA");
            entity.Property(e => e.Soluongton).HasColumnName("SOLUONGTON");
            entity.Property(e => e.Tensanpham)
                .HasMaxLength(255)
                .HasColumnName("TENSANPHAM");
            entity.Property(e => e.Thogiansudung)
                .HasMaxLength(255)
                .HasColumnName("THOGIANSUDUNG");
            entity.Property(e => e.Thoigiansanxuat)
                .HasMaxLength(255)
                .HasColumnName("THOIGIANSANXUAT");
            entity.Property(e => e.Trangthai).HasColumnName("TRANGTHAI");
            entity.Property(e => e.Xuatxu)
                .HasMaxLength(255)
                .HasColumnName("XUATXU");

            entity.HasOne(d => d.IdloaisanphamNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.Idloaisanpham)
                .HasConstraintName("FK__SANPHAM__IDLOAIS__403A8C7D");
        });

        modelBuilder.Entity<Thamso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__THAMSO__3214EC27512AF702");

            entity.ToTable("THAMSO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Giatri).HasColumnName("GIATRI");
            entity.Property(e => e.Mathamso)
                .HasMaxLength(10)
                .HasColumnName("MATHAMSO");
            entity.Property(e => e.Ngayapdung)
                .HasMaxLength(255)
                .HasColumnName("NGAYAPDUNG");
            entity.Property(e => e.Tenthamso)
                .HasMaxLength(255)
                .HasColumnName("TENTHAMSO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
