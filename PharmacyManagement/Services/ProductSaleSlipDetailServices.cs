using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;

namespace PharmacyManagement.Services
{
    public interface IProductSaleSlipDetailServices
    {
        Task<dynamic> Modify(Chitietphieubansanpham ctphieuban);
        Task<dynamic> Read();
        Task<dynamic> Delete(int id);
    }

    public class ProductSaleSlipDetailServices : IProductSaleSlipDetailServices
    {
        PharmacyManagementContext _context;

        public ProductSaleSlipDetailServices(PharmacyManagementContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Modify(Chitietphieubansanpham ctphieuban)
        {
            try
            {
                if (ctphieuban.Id == 0)
                {
                    await _context.Chitietphieubansanphams.AddAsync(ctphieuban);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Chitietphieubansanpham ct = await _context.Chitietphieubansanphams.FindAsync(ctphieuban.Id);
                    ct.Idsanpham = ctphieuban.Idsanpham;
                    ct.Soluong = ctphieuban.Soluong;
                    ct.Gia = ctphieuban.Gia;
                    ct.Thanhtien = ctphieuban.Thanhtien;
                    _context.Chitietphieubansanphams.Update(ct);
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
                var data = await _context.Chitietphieubansanphams
                    .Select(x => new
                    {
                        Id = x.Id,
                        Idsanpham = x.Idsanpham,
                        Soluong = x.Soluong,
                        Gia = x.Gia,
                        Thanhtien = x.Thanhtien,
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
                var data = await _context.Chitietphieubansanphams.FindAsync(id);
                _context.Chitietphieubansanphams.Remove(data);
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
