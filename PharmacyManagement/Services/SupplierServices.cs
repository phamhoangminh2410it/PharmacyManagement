using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;

namespace PharmacyManagement.Services
{
    public interface ISupplierServices
    {
        Task<dynamic> Modify(Nhacungcap nhacungcap);
        Task<dynamic> Read();
        Task<dynamic> Delete(int id);
    }

    public class SupplierServices : ISupplierServices
    {
        PharmacyManagementContext _context;

        public SupplierServices(PharmacyManagementContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Modify(Nhacungcap nhacungcap)
        {
            try
            {
                if (nhacungcap.Id == 0)
                {
                    await _context.Nhacungcaps.AddAsync(nhacungcap);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Nhacungcap ncc = await _context.Nhacungcaps.FindAsync(nhacungcap.Id);
                    ncc.Manhacungcap = nhacungcap.Manhacungcap;
                    ncc.Tennhacungcap = nhacungcap.Tennhacungcap;
                    ncc.Diachi = nhacungcap.Diachi;
                    ncc.Sodienthoai = nhacungcap.Sodienthoai;
                    ncc.Email = nhacungcap.Email;
                    _context.Nhacungcaps.Update(ncc);
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
                var data = await _context.Nhacungcaps
                    .Select(x => new
                    {
                        Id = x.Id,
                        Manhacungcap = x.Manhacungcap,
                        Tennhacungcap = x.Tennhacungcap,
                        Diachi = x.Diachi,
                        Sodienthoai = x.Sodienthoai,
                        Email = x.Email
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
                var data = await _context.Nhacungcaps.FindAsync(id);
                _context.Nhacungcaps.Remove(data);
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
