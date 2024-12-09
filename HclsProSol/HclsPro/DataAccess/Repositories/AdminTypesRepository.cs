using HclsPro.DataAccess.IRepositories;
using HclsPro.DBContext;
using HclsPro.Models;
using Microsoft.EntityFrameworkCore;

namespace HclsPro.DataAccess.Repositories
{
    public class AdminTypesRepository : IAdminTypesRepository
    {
        //context class object creation
        public HCLSDBContext dbContext;
        public AdminTypesRepository(HCLSDBContext _dbContext)
        { 
            dbContext = _dbContext;
        }

        public async Task<List<AdminTypes>> AllAdminTypes()
        {
            //Read from AdminTypes
            return await dbContext.AdminTypes.ToListAsync();
        }

        public async Task<int> DeleteAdminTypes(int AdminTypeId)
        {
            var Admt = await dbContext.AdminTypes.FindAsync(AdminTypeId);
            dbContext.AdminTypes.Remove(Admt);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAllAdminTypes()
        {
            var admtList = await dbContext.AdminTypes.ToListAsync();
            dbContext.AdminTypes.RemoveRange(admtList);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<AdminTypes> GetAdminTypesByAdminTypeId(int AdminTypeId)
        {
            return await dbContext.AdminTypes.FindAsync(AdminTypeId);
        }

        //Define methods
        public async Task<int> InsertAdminTypes(AdminTypes Admt)
        {
            //Write a logic to insert a AdminTypesData into database
            await dbContext.AdminTypes.AddAsync(Admt);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAdminTypes(AdminTypes Admt)
        {
            dbContext.AdminTypes.Update(Admt);
            return await dbContext.SaveChangesAsync();
        }
    }
}
