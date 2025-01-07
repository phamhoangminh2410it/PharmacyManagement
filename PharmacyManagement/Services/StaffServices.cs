using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;

namespace PharmacyManagement.Services
{
    public interface IStaffServices
    {
        Task<dynamic> Modify(Nhanvien nhanvien);
        Task<dynamic> Read();
        Task<dynamic> Delete(int id);
    }

    public class StaffServices : IStaffServices
    {
        PharmacyManagementContext _context;

        public StaffServices(PharmacyManagementContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Modify(Nhanvien nhanvien)
        {
            try
            {
                if (nhanvien.Id == 0)
                {
                    await _context.Nhanviens.AddAsync(nhanvien);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Nhanvien nv = await _context.Nhanviens.FindAsync(nhanvien.Id);
                    nv.Manhanvien = nhanvien.Manhanvien;
                    nv.Tennhanvien = nhanvien.Tennhanvien;
                    nv.Diachi = nhanvien.Diachi;
                    nv.Sodienthoai = nhanvien.Sodienthoai;
                    nv.Email = nhanvien.Email;
                    nv.Cmnd = nhanvien.Cmnd;
                    nv.Username = nhanvien.Username;
                    nv.Pass = nhanvien.Pass;
                    nv.Idchucvu = nhanvien.Idchucvu;
                    _context.Nhanviens.Update(nv);
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
                var data = await _context.Nhanviens
                    .Select(x => new
                    {
                        Id = x.Id,
                        Manhanvien = x.Manhanvien,
                        Tennhanvien = x.Tennhanvien,
                        Diachi = x.Diachi,
                        Sodienthoai = x.Sodienthoai,
                        Email = x.Email,
                        Cmnd = x.Cmnd,
                        Username = x.Username,
                        Pass = x.Pass,
                        Idchucvu = x.Idchucvu,
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
                var data = await _context.Nhanviens.FindAsync(id);
                _context.Nhanviens.Remove(data);
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
