using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;

namespace PharmacyManagement.Services
{
    public interface IImportSlipDetailServices
    {
        Task<dynamic> Modify(Chitietphieunhap ctphieunhap);
        Task<dynamic> Read();
        Task<dynamic> Delete(int id);
    }

    public class ImportSlipDetailServices : IImportSlipDetailServices
    {
        PharmacyManagementContext _context;

        public ImportSlipDetailServices(PharmacyManagementContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Modify(Chitietphieunhap ctphieunhap)
        {
            try
            {
                if (ctphieunhap.Id == 0)
                {
                    await _context.Chitietphieunhaps.AddAsync(ctphieunhap);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Chitietphieunhap ct = await _context.Chitietphieunhaps.FindAsync(ctphieunhap.Id);
                    ct.Idsanpham = ctphieunhap.Idsanpham;
                    ct.Soluong = ctphieunhap.Soluong;
                    ct.Gianhap = ctphieunhap.Gianhap;
                    ct.Thanhtien = ctphieunhap.Thanhtien;
                    _context.Chitietphieunhaps.Update(ct);
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
                var data = await _context.Chitietphieunhaps
                    .Select(x => new
                    {
                        Id = x.Id,
                        Idsanpham = x.Idsanpham,
                        Soluong = x.Soluong,
                        Gianhap = x.Gianhap,
                        Thanhtien = x.Thanhtien
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
                var data = await _context.Chitietphieunhaps.FindAsync(id);
                _context.Chitietphieunhaps.Remove(data);
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
