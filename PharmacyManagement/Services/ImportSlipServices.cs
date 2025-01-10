using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;

namespace PharmacyManagement.Services
{
    public interface IImportSlipServices
    {
        Task<dynamic> Modify(Phieunhap phieunhap);
        Task<dynamic> Read();
        Task<dynamic> Delete(int id);
    }

    public class ImportSlipServices : IImportSlipServices
    {
        PharmacyManagementContext _context;

        public ImportSlipServices(PharmacyManagementContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Modify(Phieunhap phieunhap)
        {
            try
            {
                if (phieunhap.Id == 0)
                {
                    await _context.Phieunhaps.AddAsync(phieunhap);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Phieunhap pn = await _context.Phieunhaps.FindAsync(phieunhap.Id);
                    pn.Sophieunhap = phieunhap.Sophieunhap;
                    pn.Ngaynhap = phieunhap.Ngaynhap;
                    pn.Idnhanvien = phieunhap.Idnhanvien;
                    pn.Idnhacungcap = phieunhap.Idnhacungcap;
                    pn.Tongtien = phieunhap.Tongtien;
                    pn.Ghichu = phieunhap.Ghichu;
                    pn.Ngaychinhsua = phieunhap.Ngaychinhsua;
                    _context.Phieunhaps.Update(pn);
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
                var data = await _context.Phieunhaps
                    .Select(x => new
                    {
                        Id = x.Id,
                        Sophieunhap = x.Sophieunhap,
                        Ngaynhap = x.Ngaynhap,
                        Idnhanvien = x.Idnhanvien,
                        Idnhacungcap = x.Idnhacungcap,
                        Tongtien = x.Tongtien,
                        Ghichu = x.Ghichu,
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
                var data = await _context.Phieunhaps.FindAsync(id);
                _context.Phieunhaps.Remove(data);
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
