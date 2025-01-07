using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;

namespace PharmacyManagement.Services
{
    public interface IPositionServices
    {
        Task<dynamic> Modify(Chucvu chucvu);
        Task<dynamic> Read();
        Task<dynamic> Delete(int id);
    }

    public class PositionServices : IPositionServices
    {
        PharmacyManagementContext _context;

        public PositionServices(PharmacyManagementContext context)
        {
            _context = context;
        }

        public async Task <dynamic> Modify (Chucvu chucvu)
        {
            try
            {
                if (chucvu.Id == 0)
                {
                    await _context.Chucvus.AddAsync(chucvu);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Chucvu cv = await _context.Chucvus.FindAsync(chucvu.Id);
                    cv.Machucvu = chucvu.Machucvu;
                    cv.Tenchucvu = chucvu.Tenchucvu;
                    _context.Chucvus.Update(cv);
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
                var data = await _context.Chucvus
                    .Select(x => new
                    {
                        Id = x.Id,
                        Machucvu = x.Machucvu,
                        Tenchucvu = x.Tenchucvu,
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

        public async Task <dynamic> Delete(int id)
        {
            try
            {
                var data = await _context.Chucvus.FindAsync(id);
                _context.Chucvus.Remove(data);
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
