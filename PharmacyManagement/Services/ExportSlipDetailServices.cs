using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;

namespace PharmacyManagement.Services
{
    public interface IExportSlipDetailServices
    {
        Task<dynamic> Modify(Chitietphieuxuat ctphieuxuat);
        Task<dynamic> Read();
        Task<dynamic> Delete(int id);
    }

    public class ExportSlipDetailServices : IExportSlipDetailServices
    {
        PharmacyManagementContext _context;

        public ExportSlipDetailServices(PharmacyManagementContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Modify(Chitietphieuxuat ctphieuxuat)
        {
            try
            {
                if (ctphieuxuat.Id == 0)
                {
                    await _context.Chitietphieuxuats.AddAsync(ctphieuxuat);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Chitietphieuxuat ct = await _context.Chitietphieuxuats.FindAsync(ctphieuxuat.Id);
                    ct.Idsanpham = ctphieuxuat.Idsanpham;
                    ct.Soluong = ctphieuxuat.Soluong;
                    ct.Gia = ctphieuxuat.Gia;
                    ct.Thanhtien = ctphieuxuat.Thanhtien;
                    _context.Chitietphieuxuats.Update(ct);
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
                var data = await _context.Chitietphieuxuats
                    .Select(x => new
                    {
                        Id = x.Id,
                        Idsanpham = x.Idsanpham,
                        Soluong = x.Soluong,
                        Gia = x.Gia,
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
                var data = await _context.Chitietphieuxuats.FindAsync(id);
                _context.Chitietphieuxuats.Remove(data);
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
