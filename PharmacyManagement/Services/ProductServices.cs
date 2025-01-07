using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;

namespace PharmacyManagement.Services
{
    public interface IProductServices
    {
        Task<dynamic> Modify(Sanpham sanpham);
        Task<dynamic> Read();
        Task<dynamic> Delete(int id);
    }

    public class ProductServices : IProductServices
    {
        PharmacyManagementContext _context;

        public ProductServices(PharmacyManagementContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Modify(Sanpham sanpham)
        {
            try
            {
                if (sanpham.Id == 0)
                {
                    await _context.Sanphams.AddAsync(sanpham);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Sanpham sp = await _context.Sanphams.FindAsync(sanpham.Id);
                    sp.Masanpham = sanpham.Masanpham;
                    sp.Tensanpham = sanpham.Tensanpham;
                    sp.Giaban = sanpham.Giaban;
                    sp.Giamgia = sanpham.Giamgia;
                    sp.Soluongton = sanpham.Soluongton;
                    sp.Donvitinh = sanpham.Donvitinh;
                    sp.Mota = sanpham.Mota;
                    sp.Xuatxu = sanpham.Xuatxu;
                    sp.Thoigiansanxuat = sanpham.Thoigiansanxuat;
                    sp.Thogiansudung = sanpham.Thogiansudung;
                    sp.Idloaisanpham = sanpham.Idloaisanpham;
                    _context.Sanphams.Update(sp);
                }
                await _context.SaveChangesAsync();
                return new
                {
                    status = 200,
                    message = "Thanh cong"
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    message = ex.Message
                };
            }
        }

        public async Task<dynamic> Read()
        {
            try
            {
                var data = await _context.Sanphams
                    .Select(x => new
                    {
                        Id = x.Id,
                        Masanpham = x.Masanpham,
                        Tensanpham = x.Tensanpham,
                        Giaban = x.Giaban,
                        Giamgia = x.Giamgia,
                        Soluongton = x.Soluongton,
                        Donvitinh = x.Donvitinh,
                        Mota = x.Mota,
                        Xuatxu = x.Xuatxu,
                        Thoigiansanxuat = x.Thoigiansanxuat,
                        Thoigiansudung = x.Thogiansudung,
                        Idloaisanpham = x.Idloaisanpham
                    }).ToListAsync();
                return new
                {
                    status = 200,
                    data = data
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    message = ex.Message
                };
            }
        }

        public async Task<dynamic> Delete(int id)
        {
            try
            {
                var data = await _context.Sanphams.FindAsync(id);
                _context.Sanphams.Remove(data);
                await _context.SaveChangesAsync();
                return new
                {
                    status = 200,
                    message = "Thanh cong"
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    message = ex.Message
                };
            }
        }
    }
}
