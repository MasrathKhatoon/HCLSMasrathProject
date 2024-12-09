using HclsPro.Models;

namespace HclsPro.DataAccess.IRepositories
{
    public interface IAdminTypesRepository
    {
        //Declare a method
        Task<int> InsertAdminTypes(AdminTypes Admt);//Insertion
        Task<List<AdminTypes>> AllAdminTypes();//Read
        Task<AdminTypes> GetAdminTypesByAdminTypeId(int AdminTypeId);//Read
        Task<int> UpdateAdminTypes(AdminTypes Admt);//Update
        Task<int> DeleteAdminTypes(int AdminTypeId);//Delete Perticular data
        Task<int> DeleteAllAdminTypes();//Delete data

    }
}
