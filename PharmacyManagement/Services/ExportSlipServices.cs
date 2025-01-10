using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;

namespace PharmacyManagement.Services
{
    public interface IExportSlipServices
    {
        Task<dynamic> Modify(Phieuxuat phieuxuat);
        Task<dynamic> Read();
        Task<dynamic> Delete(int id);
    }

    public class ExportSlipServices : IExportSlipServices
    {
        PharmacyManagementContext _context;

        public ExportSlipServices(PharmacyManagementContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Modify(Phieuxuat phieuxuat)
        {
            try
            {
                if (phieuxuat.Id == 0)
                {
                    await _context.Phieuxuats.AddAsync(phieuxuat);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Phieuxuat px = await _context.Phieuxuats.FindAsync(phieuxuat.Id);
                    px.Sophieuxuat = phieuxuat.Sophieuxuat;
                    px.Ngayxuat = phieuxuat.Ngayxuat;
                    px.Idnhanvien = phieuxuat.Idnhanvien;
                    px.Lydoxuat = phieuxuat.Lydoxuat;
                    px.Tongtien = phieuxuat.Tongtien;
                    px.Ngaychinhsua = phieuxuat.Ngaychinhsua;
                    _context.Phieuxuats.Update(px);
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
                var data = await _context.Phieuxuats
                    .Select(x => new
                    {
                        Id = x.Id,
                        Sophieuxuat = x.Sophieuxuat,
                        Ngayxuat = x.Ngayxuat,
                        Idnhanvien = x.Idnhanvien,
                        Lydoxuat = x.Lydoxuat,
                        Tongtien = x.Tongtien,
                        Ngaychinhsua = x.Ngaychinhsua
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
                var data = await _context.Phieuxuats.FindAsync(id);
                _context.Phieuxuats.Remove(data);
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
