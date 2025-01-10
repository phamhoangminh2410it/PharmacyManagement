using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;

namespace PharmacyManagement.Services
{
    public interface IInventorySlipServices
    {
        Task<dynamic> Modify(Phieukiemkho phieukiemkho);
        Task<dynamic> Read();
        Task<dynamic> Delete(int id);
    }

    public class InventorySlipServices : IInventorySlipServices
    {
        PharmacyManagementContext _context;

        public InventorySlipServices(PharmacyManagementContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Modify(Phieukiemkho phieukiemkho)
        {
            try
            {
                if (phieukiemkho.Id == 0)
                {
                    await _context.Phieukiemkhos.AddAsync(phieukiemkho);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Phieukiemkho pkk = await _context.Phieukiemkhos.FindAsync(phieukiemkho.Id);
                    pkk.Sophieukiemkho = phieukiemkho.Sophieukiemkho;
                    pkk.Ngaykiemkho = phieukiemkho.Ngaykiemkho;
                    pkk.Idnhanvien = phieukiemkho.Idnhanvien;
                    pkk.Ghichu = phieukiemkho.Ghichu;
                    pkk.Ngaychinhsua = phieukiemkho.Ngaychinhsua;
                    _context.Phieukiemkhos.Update(pkk);
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
                var data = await _context.Phieukiemkhos
                    .Select(x => new
                    {
                        Id = x.Id,
                        Sophieukiemkho = x.Sophieukiemkho,
                        Ngaykiemkho = x.Ngaykiemkho,
                        Idnhanvien = x.Idnhanvien,
                        Ghichu = x.Ghichu,
                        Ngaychinhsua = x.Ngaychinhsua,
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
                var data = await _context.Phieukiemkhos.FindAsync(id);
                _context.Phieukiemkhos.Remove(data);
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
