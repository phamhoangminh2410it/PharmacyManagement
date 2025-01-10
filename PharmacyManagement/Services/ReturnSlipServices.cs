using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;

namespace PharmacyManagement.Services
{
    public interface IReturnSlipServices
    {
        Task<dynamic> Modify(Phieudoitra phieudoitra);
        Task<dynamic> Read();
        Task<dynamic> Delete(int id);
    }

    public class ReturnSlipServices : IReturnSlipServices
    {
        PharmacyManagementContext _context;

        public ReturnSlipServices(PharmacyManagementContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Modify(Phieudoitra phieudoitra)
        {
            try
            {
                if (phieudoitra.Id == 0)
                {
                    await _context.Phieudoitras.AddAsync(phieudoitra);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Phieudoitra pdt = await _context.Phieudoitras.FindAsync(phieudoitra.Id);
                    pdt.Sophieudoitra = phieudoitra.Sophieudoitra;
                    pdt.Ngaylap = phieudoitra.Ngaylap;
                    pdt.Ngaygiao = phieudoitra.Ngaygiao;
                    pdt.Idnhanvien = phieudoitra.Idnhanvien;
                    pdt.Tennhacungcap = phieudoitra.Tennhacungcap;
                    pdt.Sodienthoai = phieudoitra.Sodienthoai;
                    pdt.Tongtien = phieudoitra.Tongtien;
                    pdt.Ghichu = phieudoitra.Ghichu;
                    pdt.Idsanpham = phieudoitra.Idsanpham;
                    _context.Phieudoitras.Update(pdt);
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
                var data = await _context.Phieudoitras
                    .Select(x => new
                    {
                        Id = x.Id,
                        Sophieudoitra = x.Sophieudoitra,
                        Ngaylap = x.Ngaylap,
                        Ngaygiao = x.Ngaygiao,
                        Idnhanvien = x.Idnhanvien,
                        Tennhacungcap = x.Tennhacungcap,
                        Sodienthoai = x.Sodienthoai,
                        Tongtien = x.Tongtien,
                        Ghichu = x.Ghichu,
                        Idsanpham = x.Idsanpham,
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
                var data = await _context.Phieudoitras.FindAsync(id);
                _context.Phieudoitras.Remove(data);
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
