using HclsPro.DataAccess.IRepositories;
using HclsPro.DBContext;
using HclsPro.Models;
using Microsoft.EntityFrameworkCore;

namespace HclsPro.DataAccess.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public HCLSDBContext dbContext;
        public AdminRepository(HCLSDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<int> DeleteAdmin(int AdminId)
        {
            var adm = await dbContext.Admin.FindAsync(AdminId);
            dbContext.Admin.Remove(adm);
            return await dbContext.SaveChangesAsync();

        }

        public async Task<int> DeleteAllAdmin()
        {
            var admList = await dbContext.Admin.ToListAsync();
            dbContext.Admin.RemoveRange(admList);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<List<Admin>> GetAdminByActiveStatus(bool ActiveStatus)
        {
            return await dbContext.Admin.Where(x => x.ActiveStatus == ActiveStatus).ToListAsync();
        }

        public async Task<Admin> GetAdminByAdminId(int AdminId)
        {
            return await dbContext.Admin.FindAsync(AdminId);
        }

        public async Task<Admin> GetAdminByEmailAndPassword(string Email, string Password)
        {
            return await dbContext.Admin.Where(x=>x.Email==Email && x.Password==Password).SingleOrDefaultAsync();
        }

        public async Task<List<Admin>> GetAllAdmin()
        {
            return await dbContext.Admin.ToListAsync();
        }

        public async Task<int> InsertAdmin(Admin Adm)
        {
            await dbContext.Admin.AddAsync(Adm);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAdmin(Admin Adm)
        {
            dbContext.Admin.Update(Adm);
            return await dbContext.SaveChangesAsync();
        }
    }

       
    }

