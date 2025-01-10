using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;

namespace PharmacyManagement.Services
{
    public interface IInventorySlipDetailServices
    {
        Task<dynamic> Modify(Chitietphieukiemkho ctphieukiemkho);
        Task<dynamic> Read();
        Task<dynamic> Delete(int id);
    }

    public class InventorySlipDetailServices : IInventorySlipDetailServices
    {
        PharmacyManagementContext _context;

        public InventorySlipDetailServices(PharmacyManagementContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Modify(Chitietphieukiemkho ctphieukiemkho)
        {
            try
            {
                if (ctphieukiemkho.Id == 0)
                {
                    await _context.Chitietphieukiemkhos.AddAsync(ctphieukiemkho);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Chitietphieukiemkho ct = await _context.Chitietphieukiemkhos.FindAsync(ctphieukiemkho.Id);
                    ct.Idsanpham = ctphieukiemkho.Idsanpham;
                    ct.Soluonghientai = ctphieukiemkho.Soluonghientai;
                    ct.Soluongkiemtra = ctphieukiemkho.Soluongkiemtra;
                    _context.Chitietphieukiemkhos.Update(ctphieukiemkho);
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
                var data = await _context.Chitietphieukiemkhos
                    .Select(x => new
                    {
                        Id = x.Id,
                        Idsanpham = x.Idsanpham,
                        Soluonghientai = x.Soluonghientai,
                        Soluongkiemtra = x.Soluongkiemtra,
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
                var data = await _context.Chitietphieukiemkhos.FindAsync(id);
                _context.Chitietphieukiemkhos.Remove(data);
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
