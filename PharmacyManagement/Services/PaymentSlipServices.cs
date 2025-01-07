using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;

namespace PharmacyManagement.Services
{
    public interface IPaymentSlipServices
    {
        Task<dynamic> Modify(Phieuchi phieuchi);
        Task<dynamic> Read();
        Task<dynamic> Delete(int id);
    }

    public class PaymentSlipServices : IPaymentSlipServices
    {
        PharmacyManagementContext _context;

        public PaymentSlipServices(PharmacyManagementContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Modify(Phieuchi phieuchi)
        {
            try
            {
                if (phieuchi.Id == 0)
                {
                    await _context.Phieuchis.AddAsync(phieuchi);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Phieuchi pc = await _context.Phieuchis.FindAsync(phieuchi.Id);
                    pc.Sophieuchi = phieuchi.Sophieuchi;
                    pc.Ngaychi = phieuchi.Ngaychi;
                    pc.Idnhanvien = phieuchi.Idnhanvien;
                    pc.Tongtienchi = phieuchi.Tongtienchi;
                    pc.Ghichu = phieuchi.Ghichu;
                    _context.Phieuchis.Update(pc);
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
                var data = await _context.Phieuchis
                    .Select(x => new
                    {
                        Id = x.Id,
                        Sophieuchi = x.Sophieuchi,
                        Ngaychi = x.Ngaychi,
                        Idnhanvien = x.Idnhanvien,
                        Tongtienchi = x.Tongtienchi,
                        Ghichu = x.Ghichu,
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
                var data = await _context.Phieuchis.FindAsync(id);
                _context.Phieuchis.Remove(data);
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
