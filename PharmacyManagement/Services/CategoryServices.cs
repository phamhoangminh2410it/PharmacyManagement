using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;

namespace PharmacyManagement.Services
{
    public interface ICategoryServices
    {
        Task<dynamic> Modify(Loaisanpham loaisanpham);
        Task<dynamic> Read();
        Task<dynamic> Delete(int id);
    }

    public class CategoryServices : ICategoryServices
    {
        PharmacyManagementContext _context;

        public CategoryServices(PharmacyManagementContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Modify(Loaisanpham loaisanpham)
        {
            try
            {
                if (loaisanpham.Id == 0)
                {
                    await _context.Loaisanphams.AddAsync(loaisanpham);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Loaisanpham lsp = await _context.Loaisanphams.FindAsync(loaisanpham.Id);
                    lsp.Maloaisanpham = loaisanpham.Maloaisanpham;
                    lsp.Tenloaisanpham = loaisanpham.Tenloaisanpham;
                    lsp.Phantramloinhuan = loaisanpham.Phantramloinhuan;
                    _context.Loaisanphams.Update(lsp);
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
                var data = await _context.Loaisanphams
                    .Select(x => new
                    {
                        Id = x.Id,
                        Maloaisanpham = x.Maloaisanpham,
                        Tenloaisanpham = x.Tenloaisanpham,
                        Phantramloinhuan = x.Phantramloinhuan
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
                var data = await _context.Loaisanphams.FindAsync(id);
                _context.Loaisanphams.Remove(data);
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
