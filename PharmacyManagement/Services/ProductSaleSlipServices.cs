using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;

namespace PharmacyManagement.Services
{
    public interface IProductSaleSlipServices
    {
        Task<dynamic> Modify(Phieubansanpham phieuban);
        Task<dynamic> Read();
        Task<dynamic> Delete(int id);
    }

    public class ProductSaleSlipServices : IProductSaleSlipServices
    {
        PharmacyManagementContext _context;

        public ProductSaleSlipServices(PharmacyManagementContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Modify(Phieubansanpham phieuban)
        {
            try
            {
                if (phieuban.Id == 0)
                {
                    await _context.Phieubansanphams.AddAsync(phieuban);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Phieubansanpham pb = await _context.Phieubansanphams.FindAsync(phieuban.Id);
                    pb.Sophieubansanpham = phieuban.Sophieubansanpham;
                    pb.Ngayban = phieuban.Ngayban;
                    pb.Idnhanvien = phieuban.Idnhanvien;
                    pb.Tenkhachhang = phieuban.Tenkhachhang;
                    pb.Sodienthoai = phieuban.Sodienthoai;
                    pb.Tongtien = phieuban.Tongtien;
                    pb.Ghichu = phieuban.Ghichu;
                    _context.Phieubansanphams.Update(pb);
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
                var data = await _context.Phieubansanphams
                    .Select(x => new
                    {
                        Id = x.Id,
                        Sophieubansanpham = x.Sophieubansanpham,
                        Ngayban = x.Ngayban,
                        Idnhanvien = x.Idnhanvien,
                        Tenkhachhang = x.Tenkhachhang,
                        Sodienthoai = x.Sodienthoai,
                        Tongtien = x.Tongtien,
                        Ghichu = x.Ghichu,
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
                var data = await _context.Phieubansanphams.FindAsync(id);
                _context.Phieubansanphams.Remove(data);
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
